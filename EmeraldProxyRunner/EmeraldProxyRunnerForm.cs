using EmeraldProxyRunner.Properties;
using HttpProxyServer;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmeraldProxyRunner
{
    public partial class EmeraldProxyRunnerForm : Form
    {
        ProxyServer _emeraldProxyServer = null;


        public EmeraldProxyRunnerForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = true;
            btnStart.Enabled = false;

            Task.Run(() => RunHttpListner());
        }

        private void RunHttpListner()
        {
            if (!Directory.Exists(Settings.Default.FilesPath))
                Directory.CreateDirectory(Settings.Default.FilesPath);

            DeleteFolderContent(Path.Combine(Settings.Default.FilesPath, Settings.Default.OriginalFiles));
            DeleteFolderContent(Path.Combine(Settings.Default.FilesPath, Settings.Default.EditedFiles));

            var sourceUrl = string.Format("http://{0}/{1}/", System.Environment.MachineName, Settings.Default.WebApplicationName);
            var destinationUrl = string.Format("http://{0}/{1}/", "localhost", Settings.Default.WebApplicationName);
            _emeraldProxyServer = new ProxyServer(destinationUrl, sourceUrl);
            _emeraldProxyServer.Start();
        }

        private void DeleteFolderContent(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            DirectoryInfo di = new DirectoryInfo(folderPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _emeraldProxyServer.Stop();

            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
    }
}
