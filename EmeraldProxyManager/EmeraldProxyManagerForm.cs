using EmeraldProxyManager.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace EmeraldProxyManager
{
    public partial class EmeraldProxyManagerForm : Form
    {
        public static string OriginalFilesPath = Path.Combine(Settings.Default.FilesPath, Settings.Default.OriginalFiles);
        public static string EditedFilesPath = Path.Combine(Settings.Default.FilesPath, Settings.Default.EditedFiles);
        
        private List<string> RequestServicesToDebug;
        private List<string> ResponseServicesToDebug;

        private List<string> RequestServicesToEdit;
        private List<string> ResponseServicesToEdit;

        private List<Operation> AllOperations;
        private List<Operation> RelevantOperations;

        private RtiType RtiType = RtiType.Request;
        private string ServiceName = "";
        private bool sent;

        public EmeraldProxyManagerForm()
        {
            InitializeComponent();

            this.fileSystemWatcher.Path = OriginalFilesPath;
            this.fileSystemWatcher.SynchronizingObject = this;
            this.fileSystemWatcher.Created += new FileSystemEventHandler(this.fileSystemWatcher1_Created);

            RequestServicesToDebug = new List<string>();
            ResponseServicesToDebug = new List<string>();

            RequestServicesToEdit = new List<string>();
            ResponseServicesToEdit = new List<string>();

            AllOperations = GetOperationsFromConfiguration();

            LoadEditedServices();
        }

        private void LoadEditedServices()
        {
            lvEditRequests.Items.Clear();

            foreach (string service in AllOperations.Where(o => o.RtiType == RtiType.Request)
                            .Select(p => p.ServiceName).Distinct())
            {
                ListViewItem item = new ListViewItem(service);
                lvEditRequests.Items.Add(item);
            }

            lvEditResponses.Items.Clear();

            foreach (string service in AllOperations.Where(o => o.RtiType == RtiType.Response)
                            .Select(p => p.ServiceName).Distinct())
            {
                ListViewItem item = new ListViewItem(service);
                lvEditResponses.Items.Add(item);
            }

        }

        private List<Operation> GetOperationsFromConfiguration()
        {
            if (!File.Exists(Path.Combine(Settings.Default.FilesPath, "Operation.xml")))
                return new List<Operation>();

            var filePath = Path.Combine(Settings.Default.FilesPath, "Operation.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Operation>));
            StreamReader reader = new StreamReader(filePath);
            XmlReader xmlReader = XmlReader.Create(reader);
            var operations = (List<Operation>)serializer.Deserialize(xmlReader);
            xmlReader.Close();
            reader.Close();
            return operations;
        }

        private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            Thread.Sleep(50);

            ReloadListsViews();

            sent = false;
            SetType(e.Name);
            SetServiceName(e.Name);

            if (!ServiceNeedToBeUpdateManually(e.Name))
            {
                RelevantOperations = AllOperations.Where(o => o.ServiceName == ServiceName && o.RtiType == RtiType).ToList();
                if (RelevantOperations.Any())
                {
                    UpdateRti(e);
                    sent = true;
                }
                else
                {
                    File.Copy(e.FullPath, Path.Combine(EditedFilesPath, e.Name));
                    sent = true;
                }
            }
            else
            {
                if (RtiType == RtiType.Request)
                    lvRequests.Items[lvRequests.Items.Count - 1].ForeColor = Color.Red;
                else
                    lvResponses.Items[lvResponses.Items.Count - 1].ForeColor = Color.Red;
            }
        }

        private void UpdateRti(FileSystemEventArgs e)
        {
            var fileContent = File.ReadAllText(e.FullPath);
            fileContent = XmlHelper.FormatAsXML(fileContent);
            fileContent = XmlHelper.DeleteFirstLineIfNeeded(fileContent);
            
            fileContent = XPathHelper.PerformOperations(fileContent, RelevantOperations);

            File.WriteAllText(Path.Combine(EditedFilesPath, e.Name), fileContent);
        }

        private void SetType(string name)
        {
            RtiType = name.Contains("_Request") ? RtiType.Request : RtiType.Response;
        }

        private void SetServiceName(string name)
        {
            if (RtiType == RtiType.Request)
                ServiceName = GetServiceName(name.Replace("_Request.xml", ""));
            else
                ServiceName = GetServiceName(name.Replace("_Response.xml", ""));
        }

        private void ReloadListsViews()
        {
            LoadRequests();
            LoadResponses();
        }

        private void LoadRequests()
        {
            lvRequests.Items.Clear();
            rtbRequest.Text = "";

            string[] files = Directory.GetFiles(OriginalFilesPath);
            foreach (string file in files)
            {
                if (file.Contains("Response"))
                    continue;

                string fileName = Path.GetFileNameWithoutExtension(file);
                fileName = fileName.Replace("_Request", "");
                ListViewItem item = new ListViewItem(fileName);
                item.Tag = file;
                lvRequests.Items.Add(item);
            }
        }

        private void LoadResponses()
        {
            lvResponses.Items.Clear();
            rtbResponse.Text = "";

            string[] files = Directory.GetFiles(OriginalFilesPath);
            foreach (string file in files)
            {
                if (file.Contains("Request"))
                    continue;

                string fileName = Path.GetFileNameWithoutExtension(file);
                fileName = fileName.Replace("_Response", "");
                ListViewItem item = new ListViewItem(fileName);
                item.Tag = file;
                lvResponses.Items.Add(item);
            }
        }

        #region Requests

        private void btnRequestDebug_Click(object sender, EventArgs e)
        {
            RequestServicesToDebug.Add(GetServiceName(lvRequests.SelectedItems[0].Text));
            DisplayDebugRequests();
        }

        private void btnRequestStopDebug_Click(object sender, EventArgs e)
        {
            RequestServicesToDebug.Remove(lvDebugRequests.SelectedItems[0].Text);
            DisplayDebugRequests();
        }

        private void DisplayDebugRequests()
        {
            lvDebugRequests.Items.Clear();

            foreach (string request in RequestServicesToDebug)
            {
                ListViewItem item = new ListViewItem(request);
                lvDebugRequests.Items.Add(item);
            }
        }

        private void btnRequestEdit_Click(object sender, EventArgs e)
        {
            RequestServicesToEdit.Add(GetServiceName(lvRequests.SelectedItems[0].Text));
            DisplayEditRequests();
        }

        private void btnRequestStopEdit_Click(object sender, EventArgs e)
        {
            RequestServicesToEdit.Remove(lvEditRequests.SelectedItems[0].Text);
            DisplayEditRequests();
        }

        private void DisplayEditRequests()
        {
            lvEditRequests.Items.Clear();

            foreach (string request in RequestServicesToEdit)
            {
                ListViewItem item = new ListViewItem(request);
                lvEditRequests.Items.Add(item);
            }
        }

        #endregion

        #region Responses

        private void btnResponseDebug_Click(object sender, EventArgs e)
        {
            ResponseServicesToDebug.Add(GetServiceName(lvResponses.SelectedItems[0].Text));
            DisplayDebugResponses();
        }

        private void btnResponseStopDebug_Click(object sender, EventArgs e)
        {
            ResponseServicesToDebug.Remove(lvDebugResponses.SelectedItems[0].Text);
            DisplayDebugResponses();
        }

        private void DisplayDebugResponses()
        {
            lvDebugResponses.Items.Clear();

            foreach (string request in ResponseServicesToDebug)
            {
                ListViewItem item = new ListViewItem(request);
                lvDebugResponses.Items.Add(item);
            }
        }

        private void btnResponseEdit_Click(object sender, EventArgs e)
        {
            ResponseServicesToEdit.Add(GetServiceName(lvResponses.SelectedItems[0].Text));
            DisplayEditResponses();
        }

        private void btnResponseStopEdit_Click(object sender, EventArgs e)
        {
            ResponseServicesToEdit.Remove(lvEditResponses.SelectedItems[0].Text);
            DisplayEditResponses();
        }

        private void DisplayEditResponses()
        {
            lvEditResponses.Items.Clear();

            foreach (string request in ResponseServicesToEdit)
            {
                ListViewItem item = new ListViewItem(request);
                lvEditResponses.Items.Add(item);
            }
        }

        #endregion

        private string GetServiceName(string text)
        {
            return text.Split('_')[1];
        }

        private bool ServiceNeedToBeUpdateManually(string name)
        {
            if (RtiType == RtiType.Request && RequestServicesToDebug.Contains(ServiceName))
            {
                return true;
            }

            if (RtiType == RtiType.Response && ResponseServicesToDebug.Contains(ServiceName))
            {
                return true;
            }

            return false;
        }

        private void lvRequests_MouseClick(object sender, MouseEventArgs e)
        {
            var fileContent = File.ReadAllText(Path.Combine(OriginalFilesPath, lvRequests.SelectedItems[0].Text + "_Request.xml"));
            fileContent = XmlHelper.FormatAsXML(fileContent);
            fileContent = XmlHelper.DeleteFirstLineIfNeeded(fileContent);
            rtbRequest.Text = fileContent;
            XmlHelper.HighlightRTF(rtbRequest);
            txbRequestServiceName.Text = GetServiceName(lvRequests.SelectedItems[0].Text);
        }

        private void lvResponses_MouseClick(object sender, MouseEventArgs e)
        {
            var fileContent = File.ReadAllText(Path.Combine(OriginalFilesPath, lvResponses.SelectedItems[0].Text + "_Response.xml"));
            fileContent = XmlHelper.FormatAsXML(fileContent);
            fileContent = XmlHelper.DeleteFirstLineIfNeeded(fileContent);
            rtbResponse.Text = fileContent;
            XmlHelper.HighlightRTF(rtbResponse);
            txbResponseServiceName.Text = GetServiceName(lvResponses.SelectedItems[0].Text);
        }

        private void btnSendEditedRequest_Click(object sender, EventArgs e)
        {
            if (sent)
                return;

            if (!lvRequests.SelectedIndices.Contains(lvRequests.Items.Count - 1))
                return;

            File.WriteAllText(Path.Combine(EditedFilesPath, lvRequests.SelectedItems[0].Text + "_Request.xml"), rtbRequest.Text);
        }

        private void btnSendEditedResponse_Click(object sender, EventArgs e)
        {
            if (sent)
                return;

            if (!lvResponses.SelectedIndices.Contains(lvResponses.Items.Count - 1))
                return;

            File.WriteAllText(Path.Combine(EditedFilesPath, lvResponses.SelectedItems[0].Text + "_Response.xml"), rtbResponse.Text);
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            RtiEditor rtiEditor = new RtiEditor(rtbRequest.Text, RtiType.Request, txbRequestServiceName.Text, AllOperations);

            rtiEditor.ShowDialog();

            AllOperations = rtiEditor.Operations;
            LoadEditedServices();

            //rtbRequest.Text = XmlHelper.FormatAsXML(rtiEditor.EditedContent);
            //XmlHelper.HighlightRTF(rtbRequest);
        }

        private void btnEditResponse_Click(object sender, EventArgs e)
        {
            RtiEditor rtiEditor = new RtiEditor(rtbResponse.Text, RtiType.Response, txbResponseServiceName.Text, AllOperations);

            rtiEditor.ShowDialog();
            AllOperations = rtiEditor.Operations;
            LoadEditedServices();

            //rtbResponse.Text = XmlHelper.FormatAsXML(rtiEditor.EditedContent);
            //XmlHelper.HighlightRTF(rtbResponse);
        }
    }

    public class HighlightColors
    {
        public static Color HC_NODE = Color.Firebrick;
        public static Color HC_STRING = Color.Blue;
        public static Color HC_ATTRIBUTE = Color.Red;
        public static Color HC_COMMENT = Color.GreenYellow;
        public static Color HC_INNERTEXT = Color.Black;
    }
}
