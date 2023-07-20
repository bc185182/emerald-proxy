using EmeraldProxy.Properties;
using System;
using System.IO;
using System.Threading;

namespace HttpProxyServer
{
    class EditedFilesWatcher
    {
        FileSystemWatcher _watcher;

        public string FileContent { get; set; }

        public void StartFileWatcher()
        {
            // Create a new FileSystemWatcher and set its properties.
            _watcher = new FileSystemWatcher();
            _watcher.Path = Path.Combine(Settings.Default.FilesPath, Settings.Default.EditedFiles);
            /* Watch for changes in LastAccess and LastWrite times, and  the renaming of files or directories. */
            _watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            // Only watch text files.
            _watcher.Filter = "*.*";

            // Add event handlers.
            _watcher.Created += new FileSystemEventHandler(OnChanged);

            // Begin watching.
            _watcher.EnableRaisingEvents = true;
        }

        public void StopFileWatcher()
        {
            _watcher.EnableRaisingEvents = false;
        }

        // Define the event handlers.
        private void OnChanged(object source, FileSystemEventArgs e)
        {
            while(FileLocked(e.FullPath))
            {
                Thread.Sleep(100);
            }

            FileContent = File.ReadAllText(e.FullPath);
        }

        public static bool FileLocked(string FileName)
        {
            FileStream fs = null;

            try
            {
                // NOTE: This doesn't handle situations where file is opened for writing by another process but put into write shared mode, it will not throw an exception and won't show it as write locked
                fs = File.Open(FileName, FileMode.Open, FileAccess.ReadWrite, FileShare.None); // If we can't open file for reading and writing then it's locked by another process for writing
            }
            catch (Exception)
            {
                return true; // This file has been locked
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return false;
        }
    }
}
