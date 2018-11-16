using System.ServiceProcess;

namespace WSFileSystemWatcher
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new WSFileSystemWatcher()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
