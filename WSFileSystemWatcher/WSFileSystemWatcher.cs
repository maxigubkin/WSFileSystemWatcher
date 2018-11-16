using System;
using System.IO;
using System.ServiceProcess;

namespace WSFileSystemWatcher
{
    public partial class WSFileSystemWatcher : ServiceBase
    {
        public WSFileSystemWatcher()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            WriteToFile("FileSystemWatcher Service started!");

            // Set path to the directory for which you want to monitor
            FileSystemWatcher fsw = new FileSystemWatcher();
            try
            {
                fsw.Path = ConfigInfo.DirToMonitor;
            }
            catch (ArgumentException ex)
            {
                WriteToFile(string.Format("FileSystemWatcher Service failed. {0}", ex.Message));
                return;
            }

            // Set targets of the observation
            fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // Watch for subfolders
            fsw.IncludeSubdirectories = ConfigInfo.WatchSubDir;

            // Add event handlers
            fsw.Changed += new FileSystemEventHandler(OnChanged);
            fsw.Created += new FileSystemEventHandler(OnChanged);
            fsw.Deleted += new FileSystemEventHandler(OnChanged);
            fsw.Renamed += new RenamedEventHandler(OnRenamed);

            // Start monitoring the catalog
            fsw.EnableRaisingEvents = true;
        }

        protected override void OnStop()
        {
            WriteToFile("FileSystemWatcher Service stoped!");
        }

        static void OnChanged(object sender, FileSystemEventArgs e)
        {
            WriteToFile(string.Format("{0} {1}", e.ChangeType, e.FullPath));
        }

        static void OnRenamed(object sender, RenamedEventArgs e)
        {
            WriteToFile(string.Format("Renamed {0} to {1}", e.OldFullPath, e.FullPath));
        }

        static void WriteToFile(string info)
        {
            using (var tw = new StreamWriter(ConfigInfo.LogFile, true))
            {
                    tw.WriteLine(DateTime.Now + " " + info);
            }
        }
    }
}
