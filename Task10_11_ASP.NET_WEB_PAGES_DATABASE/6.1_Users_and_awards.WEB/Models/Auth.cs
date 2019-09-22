using System.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data.SqlClient;


namespace _6._1_Users_and_awards.WEB.Models
{
    public static class Auth
    {
        //private static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
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
                    sr1.WriteLine("admin;"+Crypt.CalcHash("admin"));
                }
                logpass.Add("admin", Crypt.CalcHash("admin"));
            }
            return logpass;
        }

        public static void SetAdmin()
        {
            string sqlExpression = "SetAdmin";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.ExecuteNonQuery();
            }
        }

        public static bool CanLogin(string login, string password)
        {
            string sAttr;
            sAttr = ConfigurationManager.AppSettings["Mode"];
            switch (sAttr)
            {
                case "0":
                    {
                        SetAdmin();
                        if (login.Length != 0)
                        {
                            string sqlExpression = "GetLogin";
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
                                SqlDataReader reader = command.ExecuteReader();
                                if (reader.Read())
                                {
                                    if ((string)reader.GetValue(0) == login && (string)reader.GetValue(1) == Crypt.CalcHash(password))
                                        return true;
                                    else return false;
                                }
                                else return false;
                            }
                        }
                        else return true;
                    }
                case "1":
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory;
                        Dictionary<string, string> logpass = new Dictionary<string, string>();
                        logpass = LP();
                        if (login.Length != 0)
                        {
                            if (logpass.ContainsKey(login))
                            {
                                if (logpass[login] == Crypt.CalcHash(password))
                                    return true;
                                else return false;
                            }
                            else return false;
                        }
                        else return true;
                    }
                default:
                    {
                        Path = AppDomain.CurrentDomain.BaseDirectory;
                        Dictionary<string, string> logpass = new Dictionary<string, string>();
                        logpass = LP();
                        if (login.Length != 0)
                        {
                            if (logpass.ContainsKey(login))
                            {
                                if (logpass[login] == Crypt.CalcHash(password))
                                    return true;
                                else return false;

                            }
                            else return false;
                        }
                        else return true;
                    }
            }
        }
    }
}