using EmeraldProxyManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EmeraldProxyManager
{
    public partial class RtiEditor : Form
    {
        public string EditedContent { get; set; }

        public List<Operation> Operations { get; set; }

        public List<Operation> _relevantOperations;

        public RtiEditor(string originalContent, RtiType rtiType, string serviceName, List<Operation> operations)
        {
            InitializeComponent();

            Operations = operations;
            _relevantOperations = Operations.Where(o => o.ServiceName == serviceName && o.RtiType == rtiType).ToList();
            //var fileContent = XPathHelper.PerformOperations(originalContent, _relevantOperations);
            rtbContent.Text = originalContent;
            XmlHelper.HighlightRTF(rtbContent);
            txbServiceName.Text = serviceName;
            txbRtiType.Text = rtiType == RtiType.Request ? "Request" : "Response";
            
            DisplayOperations();
        }

        private void DisplayOperations()
        {
            lvOperations.Items.Clear();

            foreach (Operation operation in _relevantOperations)
            {
                ListViewItem item = new ListViewItem(operation.OperationType.ToString());
                lvOperations.Items.Add(item);
            }
        }

        private void RtiEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            EditedContent = rtbContent.Text;
        }

        private void btnGetXPath_Click(object sender, EventArgs e)
        {
            if (rtbContent.SelectedText == null || rtbContent.SelectedText.Length == 0)
            {
                return;
            }

            txbXPath.Text = XPathHelper.FindXPath(rtbContent.Text, rtbContent.SelectedText);
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            if (txbRtiType.Text == "" || txbServiceName.Text == "" || txbXPath.Text == "" || cmbOperationType.Text == "" || txbContent.Text == "")
            {
                MessageBox.Show("Not all information was supplied");
                return;
            }

            var rtiType = txbRtiType.Text == "Request" ? RtiType.Request : RtiType.Response;
            Operation operation = new Operation
            {
                RtiType = rtiType,
                ServiceName = txbServiceName.Text,
                XPath = txbXPath.Text,
                OperationType = GetOperationType(),
                Content = txbContent.Text
            };

            Operations.Add(operation);
            SaveOperations();

            _relevantOperations = Operations.Where(o => o.ServiceName == txbServiceName.Text && o.RtiType == rtiType).ToList();
            DisplayOperations();
        }

        private void SaveOperations()
        {
            var filePath = Path.Combine(Settings.Default.FilesPath, "Operation.xml");
            if (File.Exists(filePath))
                File.Delete(filePath);

            var writer = new XmlSerializer(typeof(List<Operation>));
            var file = new StreamWriter(filePath);
            writer.Serialize(file, Operations);
            file.Close();
        }

        private OperationType GetOperationType()
        {
            switch (cmbOperationType.Text)
            {
                case "AddNode":
                    return OperationType.AddNode;
                case "UpdateValue":
                    return OperationType.UpdateValue;
                case "DeleteNode":
                    return OperationType.DeleteNode;
                case "RepalceFullRti":
                    return OperationType.RepalceFullRti;
                default:
                    return OperationType.UpdateValue;
            }
        }

        private void lvOperations_MouseClick(object sender, MouseEventArgs e)
        {
            var operation = _relevantOperations[lvOperations.SelectedIndices[0]];

            txbXPath.Text = operation.XPath;
            cmbOperationType.Text = operation.OperationType.ToString();
            txbContent.Text = operation.Content;
        }

        private void lvOperations_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (Keys.Delete != e.KeyCode) return;
            foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
            {
                Operations.RemoveAll(o => o.OperationType.ToString() == listViewItem.Text);
                _relevantOperations.RemoveAll(o => o.OperationType.ToString() == listViewItem.Text);
            }
            DisplayOperations();
            SaveOperations();
        }
    }
}
