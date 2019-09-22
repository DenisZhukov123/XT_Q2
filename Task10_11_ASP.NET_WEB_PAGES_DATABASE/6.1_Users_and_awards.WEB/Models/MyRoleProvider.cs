using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;

namespace _6._1_Users_and_awards.WEB.Models
{
    public enum Roles
    {
        Admin=0,
        User=1,
        Guest=2
    }
    public class MyRoleProvider : RoleProvider
    {

        //private static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
        public static string SAttr { get; set; } = ConfigurationManager.AppSettings["Mode"];
       
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

        public static void RecordDbRoles(Dictionary<string, Roles> UR)
        {
            Path = AppDomain.CurrentDomain.BaseDirectory;
            string ListOfUserRoles = JsonConvert.SerializeObject(UR, Formatting.Indented);
            File.WriteAllText(Path + @"App_Data" + @"\UR.json", ListOfUserRoles);
        }

        public static void RecordFilesPass(Dictionary<string, Roles> UR, string password)
        {
            using (StreamWriter sr1 = File.AppendText(Path + @"App_Data" + @"\password.txt"))
            {
                string LP = UR.Keys.Last() + ";" + Crypt.CalcHash(password);
                sr1.WriteLine(LP);
            }
        }

        public static bool CreateUser(string login, string pass)
        {
            switch (SAttr)
            {
                case "0":
                    {
                        string sqlExpression = "CreateUser";

                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlParameter loginParam = new SqlParameter
                            {
                                ParameterName = "@Login",
                                Value = login
                            };
                            command.Parameters.Add(loginParam);
                            SqlParameter passParam = new SqlParameter
                            {
                                ParameterName = "@Password",
                                Value = Crypt.CalcHash(pass)
                            };
                            command.Parameters.Add(passParam);
                            SqlParameter roleParam = new SqlParameter
                            {
                                ParameterName = "@Role",
                                Value = 1
                            };
                            command.Parameters.Add(roleParam);
                            int number = command.ExecuteNonQuery();
                            if (number > 0)
                                return true;
                            else return false;
                        }
                    }

                case "1":
                    {
                        ReadFiles();
                        if (UserRoles.ContainsKey(login))
                            return false;
                        UserRoles.Add(login, Roles.User);
                        RecordFilesRoles(UserRoles);
                        RecordFilesPass(UserRoles, pass);
                        return true;
                    }
                default: return false;
            }
        }

        public static bool EditUser(string login, string role)
        {
            switch (SAttr)
            {
                case "0":
                    {
                        string sqlExpression = "ChangeRole";

                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlParameter loginParam = new SqlParameter
                            {
                                ParameterName = "@Login",
                                Value = login
                            };
                            command.Parameters.Add(loginParam);
                            SqlParameter roleParam = new SqlParameter
                            {
                                ParameterName = "@Role",
                                Value = StringToRole(role)
                            };
                            command.Parameters.Add(roleParam);
                            int number = command.ExecuteNonQuery();
                            if (number > 0)
                                return true;
                            else return false;
                        }
                    }
                case "1":
                    {
                        UserRoles[login] = StringToRole(role);
                        RecordFilesRoles(UserRoles);
                        return true;
                    }
                default: return false;
            }              
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
            switch (SAttr)
            {
                case "0":
                    {
                        string sqlExpression = "CheckLogin";

                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlParameter loginParam = new SqlParameter
                            {
                                ParameterName = "@Login",
                                Value = username
                            };
                            command.Parameters.Add(loginParam);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                                return true;
                            else return false;
                        }
                    }
                case "1":
                    {
                        if (UserRoles.ContainsKey(username))
                        {
                            return true;
                        }
                        else return false;
                    }
                default: return false;
            }
        }
        
        public static string GetRole(string username)
        {
            switch (SAttr)
            {
                case "0":
                    {
                        string sqlExpression = "CheckLogin";

                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlParameter loginParam = new SqlParameter
                            {
                                ParameterName = "@Login",
                                Value = username
                            };
                            command.Parameters.Add(loginParam);
                            SqlDataReader reader = command.ExecuteReader();
                            if (reader.Read())
                            {
                                switch ((int)reader.GetValue(2))
                                {
                                    case 0: return "Admin";
                                    case 1: return "User";
                                    default: return "Guest";
                                }
                            }
                            return "Guest";
                        }
                    }
                case "1":
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
                default: return "Guest";
            }
          
        }

        public override string[] GetRolesForUser(string username)
        {
            if(username.Length!=0)
            {
                switch (SAttr)
                {
                    case "0":
                        {
                            string sqlExpression = "CheckLogin";

                            using (SqlConnection connection = new SqlConnection(_connectionString))
                            {
                                connection.Open();
                                SqlCommand command = new SqlCommand(sqlExpression, connection);
                                command.CommandType = System.Data.CommandType.StoredProcedure;
                                SqlParameter loginParam = new SqlParameter
                                {
                                    ParameterName = "@Login",
                                    Value = username
                                };
                                command.Parameters.Add(loginParam);
                                SqlDataReader reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    switch ((int)reader.GetValue(2))
                                    {
                                        case 0: return new[] { "Admin" };
                                        case 1: return new[] { "User" };
                                        default: return new[] { "Guest" };
                                    }
                                }
                                return new[] { "Guest" };
                            }
                        }
                    case "1":
                        {
                            ReadFiles();
                            switch (UserRoles[username])
                            {
                                case Roles.Admin: return new[] { "Admin" };
                                case Roles.User: return new[] { "User" };
                                default: return new[] { "Guest" };
                            }
                        }
                    default: return new[] { "Guest" };
                }
               
            }
            else return new[] { "Guest" };
        }

        public static Dictionary<string, Roles> GetAllUsersRoles()
        {
            switch (SAttr)
            {
                case "0":
                    {
                        Dictionary<string, Roles> temp = new Dictionary<string, Roles>();
                        string sqlExpression = "GetAllAccounts";

                        using (SqlConnection connection = new SqlConnection(_connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(sqlExpression, connection);
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                temp.Add((string)reader.GetValue(0), (Roles)reader.GetValue(2));
                            }
                            return temp;
                        }
                    }
                case "1":
                    {
                        return UserRoles;
                    }
                default: return new Dictionary<string, Roles>();
            }

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