using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;


namespace _6._1_Users_and_awards.WEB.Models
{
    public static class Auth
    {
        public static string Path { get; private set; }
        public static Dictionary<string,string> LP()
        {
            Dictionary<string, string> logpass = new Dictionary<string, string>();
            if (File.Exists(Path + @"App_Data" + @"\\password.txt"))
            {
                string[] alltable = File.ReadAllLines(Path + @"App_Data" + @"\\password.txt");
                foreach (string s in alltable)
                {
                    string[] LPTable = s.Split(';');
                    logpass.Add(LPTable[0], LPTable[1]);
                }
            }
            else
            {
                using (StreamWriter sr1 = File.CreateText(Path + @"App_Data" + @"\password.txt"))
                {
                    string LP = "admin;admin";
                    sr1.WriteLine(LP);
                }
                logpass.Add("admin", "admin");
            }
            return logpass;
        }
        public static bool CanLogin(string login, string password)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            Dictionary<string, string> logpass = new Dictionary<string, string>();
            logpass = LP();
            if(login.Length!=0)
            {
                if (logpass.ContainsKey(login))
                {
                    if (logpass[login] == password)
                        return true;
                    else return false;

                }
                else return false;
            }
            else return true;
        }
    }
}