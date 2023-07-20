using EmeraldProxyManager.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace EmeraldProxyManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Directory.Exists(Settings.Default.FilesPath))
                Directory.CreateDirectory(Settings.Default.FilesPath);

            if (!Directory.Exists(Path.Combine(Settings.Default.FilesPath, Settings.Default.OriginalFiles)))
                Directory.CreateDirectory(Path.Combine(Settings.Default.FilesPath, Settings.Default.OriginalFiles));

            if (!Directory.Exists(Path.Combine(Settings.Default.FilesPath, Settings.Default.EditedFiles)))
                Directory.CreateDirectory(Path.Combine(Settings.Default.FilesPath, Settings.Default.EditedFiles));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new EmeraldProxyManagerForm());
        }
    }
}
