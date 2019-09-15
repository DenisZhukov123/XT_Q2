using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Newtonsoft.Json;
using System.IO;

namespace _6._1_Users_and_awards.WEB.Models
{
    public enum Roles
    {
        Admin,
        User,
        Guest
    }
    public class MyRoleProvider : RoleProvider
    {
        public static string Path { get; private set; }
        public static Dictionary<string, Roles> UserRoles = new Dictionary<string, Roles>();
        public override bool IsUserInRole(string username, string roleName)
        {
            if (username == "admin" && roleName == "Admin")
                return true;
            else return false;
        }

        public static Roles StringToRole(string role)
        {
            switch (role)
            {
                case "Admin": return Roles.Admin;
                case "User": return Roles.User;
                default: return Roles.User;
            }
        }
        public static void RecordFilesRoles(Dictionary<string, Roles> UR)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            string ListOfUserRoles = JsonConvert.SerializeObject(UR, Formatting.Indented);
            File.WriteAllText(Path + @"App_Data" + @"\UR.json", ListOfUserRoles);
        }
        public static void RecordFilesPass(Dictionary<string, Roles> UR, string password)
        {
            using (StreamWriter sr1 = File.AppendText(Path + @"App_Data" + @"\password.txt"))
            {
                string LP = UR.Keys.Last() + ";" + password;
                sr1.WriteLine(LP);
            }
        }

        public static bool CreateUser(string login, string pass)
        {
            ReadFiles();
            if (UserRoles.ContainsKey(login))
                return false;
            UserRoles.Add(login, Roles.User);
            RecordFilesRoles(UserRoles);
            RecordFilesPass(UserRoles, pass);
            return true;
        }

        public static bool EditUser(string login, string role)
        {
            UserRoles[login] = StringToRole(role);
            RecordFilesRoles(UserRoles);
            return true;
        }

        public static void ReadFiles()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            if (File.Exists(Path + @"App_Data" + @"\UR.json"))
            {
                Dictionary<string, Roles> UR = new Dictionary<string, Roles>();
                string ListOfUserRoles = File.ReadAllText(Path + @"App_Data" + @"\UR.json");
                UR = JsonConvert.DeserializeObject<Dictionary<string, Roles>>(ListOfUserRoles);
                UserRoles = UR;
            }
            else
            {
                if(!UserRoles.ContainsKey("admin"))
                    UserRoles.Add("admin", Roles.Admin);
                RecordFilesRoles(UserRoles);
            }
        }
        public static string GetAnotherRole(string name)
        {
            switch (GetRole(name))
            {
                case "Admin": return "User";
                case "User": return "Admin";
                default: return "Guest";
            }
        }

        public static bool CheckLogin(string username)
        {
            if (UserRoles.ContainsKey(username))
            {
                return true;
            }
            else return false;
        }
        
        public static string GetRole(string username)
        {
            if (UserRoles.ContainsKey(username))
            {
                switch (UserRoles[username])
                {
                    case Roles.Admin: return "Admin";
                    case Roles.User: return "User";
                    default: return "Guest";
                }
            }
            else return "Guest";
        }
        public override string[] GetRolesForUser(string username)
        {
            if(username.Length!=0)
            {
                ReadFiles();
                switch (UserRoles[username])
                {
                    case Roles.Admin: return new[] { "Admin" };
                    case Roles.User: return new[] { "User" };
                    default: return new[] { "Guest" };
                }
            }
            else return new[] { "Guest" };
        }
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}