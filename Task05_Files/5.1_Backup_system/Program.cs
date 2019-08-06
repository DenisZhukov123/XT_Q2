using System;
using System.IO;
using System.Collections.Generic;

namespace _5._1_Backup_system
{
    public static class Monitoring
    {
        private static string PathForMonitoring;
        public static void MonitoringOn(string Path)
        {
            PathForMonitoring = Path;
            string NowTime = DateTime.Now.ToString();
            CreateSnapShot(NowTime, true);
            Run();
        }
        public static void WriteLog(string timelog, bool NewLog, string Act)
        {
            if (NewLog)
            {
                using (StreamWriter sr = File.CreateText(PathForMonitoring + "\\changes.log"))
                {
                    sr.WriteLine(($"{timelog} create new backup point"));
                }
                using (StreamWriter sr = File.CreateText(PathForMonitoring + "\\point.log"))
                {
                    sr.WriteLine(($"{timelog}"));
                }
            }
            else
            {
                using (StreamWriter sr = File.AppendText(PathForMonitoring + "\\changes.log"))
                {
                    sr.WriteLine($"{timelog} {Act}");
                }
                using (StreamWriter sr = File.AppendText(PathForMonitoring + "\\point.log"))
                {
                    sr.WriteLine(($"{timelog}"));
                }
            }
            
        }
        public static void CreateSnapShot(string NowTime, bool NewLog)
        {
            string NameFolderSnap = "\\[Snap " + NowTime.Replace(':', '.') + "]";
            string PathNow = PathForMonitoring + NameFolderSnap;
            try
            {
                Directory.CreateDirectory(PathNow);
            }
            catch
            {
                throw new ArgumentException("Error! Cann't create snapshot directory!");
            }
            CopyFiles(PathForMonitoring, PathNow);
            WriteLog(NowTime, NewLog, "");
        }
        public static void CopyFiles(string PathSource, string PathDest)
        {
            DirectoryInfo dir = new DirectoryInfo(PathSource);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + PathSource);
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!Directory.Exists(PathDest))
            {
                Directory.CreateDirectory(PathDest);
            }
            FileInfo[] files = dir.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(PathDest, file.Name);
                file.CopyTo(temppath, true);
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                if(!(subdir.ToString().Contains('[')))
                {
                    string temppath = Path.Combine(PathDest, subdir.Name);
                    CopyFiles(subdir.FullName, temppath);
                }
            }
        }
        public static void Run()
        {
            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = PathForMonitoring;
                watcher.IncludeSubdirectories = true;
                watcher.NotifyFilter = NotifyFilters.LastWrite
                                     | NotifyFilters.FileName
                                     | NotifyFilters.DirectoryName;
                watcher.Filter = "*.txt";
                watcher.Changed += OnChanged;
                watcher.Created += OnCreated;
                watcher.Deleted += OnDeleted;
                watcher.Renamed += OnRenamed;
                watcher.EnableRaisingEvents = true;
                Console.Clear();
                Console.WriteLine("Monitoring is On. (Press 'q' to exit from monitoring)");
                while (Console.Read() != 'q') ;
            }
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            string NowTime = DateTime.Now.ToString();
            WriteLog(NowTime, false, $"File: {e.FullPath} { e.ChangeType}");
            Monitoring.CreateSnapShot(NowTime, false);
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            string NowTime = DateTime.Now.ToString();
            WriteLog(NowTime, false, $"File: {e.OldFullPath} renamed to {e.FullPath}");
            Monitoring.CreateSnapShot(NowTime, false);
        }
        private static void OnCreated(object source, FileSystemEventArgs e)
        {
            string NowTime = DateTime.Now.ToString();
            WriteLog(NowTime, false, $"File: {e.FullPath} created");
            Monitoring.CreateSnapShot(NowTime, false);
        }
        private static void OnDeleted(object source, FileSystemEventArgs e)
        {
            string NowTime = DateTime.Now.ToString();
            WriteLog(NowTime, false, $"File: {e.FullPath} deleted");
            Monitoring.CreateSnapShot(NowTime, false);
        }
    }
    public static class Backup
    {
        private static List<DateTime> ListPointBackup;
        private static DateTime PointForBackup;

        public static void GetPointBackup(string Path)
        {
            Console.Clear();
            ListPointBackup = new List<DateTime>();
            try
            {
                using (StreamReader sr = File.OpenText(Path + "\\point.log"))
                {
                    while (!sr.EndOfStream)
                    {
                        ListPointBackup.Add(DateTime.Parse(sr.ReadLine()));
                    }
                }
            }
            catch
            {
                Console.WriteLine("No point found! Please press any key");
                Console.ReadKey();
                return;
            }
            ChoosePointBackup(Path);
        }

        public static DateTime EnterPointToBackup()
        {
            Console.WriteLine("Please enter date to recovery (dd.mm.yyyy hh:mm:ss):");
            while (true)
            {
                DateTime value;
                if (DateTime.TryParse(Console.ReadLine(), out value) == true)
                {
                    return value;
                }
                else Console.WriteLine("Input error! Try again:");
            }
        }
        public static void ChoosePointBackup(string Path)
        {
            if (ListPointBackup != null)
            {
                Console.WriteLine("You can choose next point for backup:");
                foreach (var item in ListPointBackup)
                    Console.WriteLine(item);
                while (true)
                {
                    DateTime value = EnterPointToBackup();
                    foreach (var item in ListPointBackup)
                    {
                        if (value >= item)
                        {
                            PointForBackup = item;
                        }
                    }
                    if (PointForBackup.Year!=1)
                    {
                        Console.WriteLine("You choose next point to backup: {0}", PointForBackup);
                        string PathDest = Path;
                        string PathSource = PathDest + "\\[Snap " + PointForBackup.ToString().Replace(':', '.') + "]";
                        StartBackup(PathSource, PathDest);
                        Console.WriteLine("Recovery is done!");
                        Console.ReadLine();
                        break;
                    }
                    else Console.WriteLine("The point with the specified parameters is not found! Try again");
                }
            }
            else
            {
                Console.WriteLine("No point found! Please press any key");
                Console.ReadLine();
            } 
        }
        public static void StartBackup(string PathSource, string PathDest)
        {
            DirectoryInfo dir = new DirectoryInfo(PathSource);
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: ");
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles("*.txt");
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(PathDest, file.Name);
                file.CopyTo(temppath, true);
            }
            foreach (DirectoryInfo subdir in dirs)
            {
                if (!(subdir.ToString().Contains('[')))
                {
                    string temppath = Path.Combine(PathDest, subdir.Name);
                    StartBackup(subdir.FullName, temppath);
                }
            }
        }
    }
    class Program
    {
        static public string EnterAndCheckPath()
        {
            string path;
            Console.WriteLine("Enter path for folder:");
            while (true)
            {
                path = Console.ReadLine();
                if (!Directory.Exists(path))
                    Console.WriteLine("Directory is not found! Try again:");
                else break;
            }
            return path;
        }
        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Select the program mode:");
            Console.WriteLine("1: Monitoring mode");
            Console.WriteLine("2: Backup mode");
            Console.WriteLine("3: Exit");
        }

        static public int SelectMode()
        {
            int mode;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out mode) && (mode >= 1 && mode <= 3))
                    return mode;
                else
                {
                    Console.WriteLine("Input error! Try again:");
                }
            }
        }

        static void Main()
        {
            string Path = EnterAndCheckPath();
            while (true)
            {
                PrintMenu();
                switch (SelectMode())
                {
                    case 1:
                        {
                            Monitoring.MonitoringOn(Path);
                            break;
                        };
                    case 2:
                        {
                            Backup.GetPointBackup(Path);
                            break;
                        }
                    case 3:
                        {
                            return;
                        }
                }
            }   
        }
    }  
}
