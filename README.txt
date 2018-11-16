About Program
---------------------------
Windows service which monitors file system activity in configured folder and logs it.

Configuration of this program can be done in ConfigInfo class:
LogFile - Log file in whitch you want to write activities.
DirToMonitor - Directory whitch you want to monitor.
WatchSubDir - Watch sub directorys?

Install the service
---------------------------
1. Open Developer Command Prompt for Visual Studio with administrative credentials. If you’re using a mouse, right-click on Developer Command Prompt for VS 2017 in the Windows Start menu, and then choose More > Run as Administrator.
2. In the Developer Command Prompt window, navigate to the folder that contains your project's output (by default, it's the \bin\Debug subdirectory of your project).
3. Enter the following command: installutil.exe WSFileSystemWatcher.exe

If it installs successfully now you can start this service in windows Services.


Uninstall the service
---------------------------
1. Open Developer Command Prompt for Visual Studio with administrative credentials.
2. In the command prompt window, navigate to the folder that contains your project's output (by default, it's the \bin\Debug subdirectory of your project).
3. Enter the following command: installutil.exe /u WSFileSystemWatcher.exe

If the service uninstalls successfully, installutil.exe reports that your service was successfully removed. 
