using Epam.MyDrive.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.MyDrive.DAL.Interfaces;
using System.Data.SqlTypes;
using log4net;
using log4net.Config;
using System.Security.Cryptography;

namespace Epam.MyDrive.DAL
{
    public static class Crypt
    {
        public static string CalcHash(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
    public class UsersDBDAO:IUsersDBDAO,ILoggerDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public ILog Log => LogManager.GetLogger("LOGGER");
        public void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public Users GetUserByNick(string nickname)
        {
            string sqlExpression = "GetUserByNick";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return null;
                }
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = nickname
                };
                command.Parameters.Add(nick);
                SqlDataReader reader;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return null;
                }
                if (reader.Read())
                {
                    
                    Users user = new Users((string)reader.GetValue(0),
                                           (reader.GetValue(1) as byte[]) ?? null,
                                           (reader.GetValue(2) as string) ?? "",
                                           (reader.GetValue(3) as string) ?? "",
                                            (reader.GetValue(4) as DateTime?) ?? (DateTime)SqlDateTime.MinValue,
                                           (reader.GetValue(5) as string) ?? "");
                    return user;
                }
                return null;
            }
        }
        public bool CreateUser(Users user)
        {
            string sqlExpression = "CreateUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter login = new SqlParameter
                {
                    ParameterName = "@Login",
                    Value = user.Nickname
                };
                command.Parameters.Add(login);
                SqlParameter password = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = user.Password
                };
                command.Parameters.Add(password);
                SqlParameter avatar = new SqlParameter
                {
                    ParameterName = "@Avatar",
                    Value = user.Avatar
                };
                command.Parameters.Add(avatar);
                int result;
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool EditUser(Users user, string Oldnickname)
        {
            string sqlExpression = "EditUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter oldnickname = new SqlParameter
                {
                    ParameterName = "@Oldnickname",
                    Value = Oldnickname
                };
                command.Parameters.Add(oldnickname);
                SqlParameter nickname = new SqlParameter
                {
                    ParameterName = "@Nickname",
                    Value = user.Nickname
                };
                command.Parameters.Add(nickname);
                SqlParameter avatar = new SqlParameter
                {
                    ParameterName = "@Avatar",
                    Value = user.Avatar
                };
                command.Parameters.Add(avatar);
                SqlParameter surname = new SqlParameter
                {
                    ParameterName = "@Surname",
                    Value = user.Surname
                };
                command.Parameters.Add(surname);
                SqlParameter name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name
                };
                command.Parameters.Add(name);
                SqlParameter birth = new SqlParameter
                {
                    ParameterName = "@Birth",
                    Value = user.DateOfBirth
                };
                command.Parameters.Add(birth);
                SqlParameter city = new SqlParameter
                {
                    ParameterName = "@City",
                    Value = user.City
                };
                command.Parameters.Add(city);
                int result;
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool DeleteUser(Users user)
        {
            string sqlExpression = "DeleteUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nickname = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = user.Nickname
                };
                command.Parameters.Add(nickname);
                int result;
                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }
                if (result <= 0)
                    return false;
            }
            return true;
        }

        public List<Users> GetAllUsers()
        {
            List<Users> ListUsers = new List<Users>();
            string sqlExpression = "GetAllUsers";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return null;
                }
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return null;
                }
                while (reader.Read())
                {
                    Users user = new Users((string)reader.GetValue(0),
                                          (reader.GetValue(1) as byte[]) ?? null,
                                          (reader.GetValue(2) as string) ?? "",
                                          (reader.GetValue(3) as string) ?? "",
                                          (reader.GetValue(4) as DateTime?) ?? (DateTime)SqlDateTime.MinValue,
                                          (reader.GetValue(5) as string) ?? "");
                    ListUsers.Add(user);

                }
                return ListUsers;
            }
        }

        public int GetUserRoleByNick(string nickname)
        {
            string sqlExpression = "GetUserRoleByNick";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return 2;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = nickname
                };
                command.Parameters.Add(nick);
                SqlDataReader reader;
                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return 2;
                }
                if (reader.Read())
                {
                    return (int)reader.GetValue(7);
                }
                return 2;
            }
        }

        public bool EditRoleUser(string nickname, int role)
        {
            string sqlExpression = "ChangeRole";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = nickname
                };
                command.Parameters.Add(nick);
                SqlParameter newrole = new SqlParameter
                {
                    ParameterName = "@Role",
                    Value = role
                };
                command.Parameters.Add(newrole);
                int number;

                try
                {
                    number = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }

                if (number > 0)
                    return true;
                else return false;
            }
        }

        public List<Users> SearchUsers(string search)
        {
            List<Users> ListUsers = new List<Users>();
            string sqlExpression = "SearchUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return null;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter searchstr = new SqlParameter
                {
                    ParameterName = "@Search",
                    Value = search
                };
                command.Parameters.Add(searchstr);
                SqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return null;
                }

                while (reader.Read())
                {
                    Users user = new Users((string)reader.GetValue(0),
                                          (reader.GetValue(1) as byte[]) ?? null,
                                          (reader.GetValue(2) as string) ?? "",
                                          (reader.GetValue(3) as string) ?? "",
                                           (reader.GetValue(4) as DateTime?) ?? (DateTime)SqlDateTime.MinValue,
                                          (reader.GetValue(5) as string) ?? "");
                    ListUsers.Add(user);
                }
                return ListUsers;
            }
        }

        public bool SubscribeToUser(string Nick, string Subsnick)
        {
            string sqlExpression = "SubscribeToUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = Nick
                };
                command.Parameters.Add(nick);
                SqlParameter subsnick = new SqlParameter
                {
                    ParameterName = "@Subsnick",
                    Value = Subsnick
                };
                command.Parameters.Add(subsnick);
                int result;

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool UnSubscribeToUser(string Nick, string Subsnick)
        {
            string sqlExpression = "UnSubscribeToUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = Nick
                };
                command.Parameters.Add(nick);
                SqlParameter subsnick = new SqlParameter
                {
                    ParameterName = "@Subsnick",
                    Value = Subsnick
                };
                command.Parameters.Add(subsnick);
                int result;

                try
                {
                    result = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }

                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool CheckSubscribeToUser(string Nick, string Subsnick)
        {
            string sqlExpression = "CheckSubscribeToUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return false;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = Nick
                };
                command.Parameters.Add(nick);
                SqlParameter subsnick = new SqlParameter
                {
                    ParameterName = "@Subsnick",
                    Value = Subsnick
                };
                command.Parameters.Add(subsnick);
                SqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return false;
                }

                if (reader.Read())
                {
                    return true;
                }
                return false;
            }
        }

        public int GetCountSubscribeToUser(string Nick)
        {
            string sqlExpression = "GetCountSubscribeToUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return 0;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Subsnick",
                    Value = Nick
                };
                command.Parameters.Add(nick);
                SqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return 0;
                }

                if (reader.Read())
                {
                    return reader.FieldCount;
                }
                return 0;
            }
        }

        public int GetCountUsersToSubscribe(string Nick)
        {
            string sqlExpression = "GetCountUsersToSubscribe";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return 0;
                }


                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = Nick
                };
                command.Parameters.Add(nick);
                SqlDataReader reader;

                try
                {
                    reader = command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return 0;
                }


                if (reader.Read())
                {
                    return reader.FieldCount;
                }
                return 0;
            }
        }

        public void SetAdmin()
        {
            string sqlExpression = "SetAdmin";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {

                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка открытия БД");
                    return;
                }

                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
               
                try
                {
                    command.ExecuteReader();
                }
                catch (Exception ex)
                {
                    InitLogger();
                    var exMessage = ex.Message.Replace(Environment.NewLine, "");
                    Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                    return;
                }
            }
        }

        public bool CanLogin(string login, string password)
        {
            if (login.Length != 0)
            {
                string sqlExpression = "GetLogin";
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        InitLogger();
                        var exMessage = ex.Message.Replace(Environment.NewLine, "");
                        Log.Error(exMessage + "Ошибка открытия БД");
                        return false;
                    }

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    SqlParameter loginParam = new SqlParameter
                    {
                        ParameterName = "@Login",
                        Value = login
                    };
                    command.Parameters.Add(loginParam);
                    SqlDataReader reader;
                    try
                    {
                        reader=command.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        InitLogger();
                        var exMessage = ex.Message.Replace(Environment.NewLine, "");
                        Log.Error(exMessage + "Ошибка выполнения запроса к БД");
                        return false;
                    }
                    if (reader.Read())
                    {
                        if ((string)reader.GetValue(0) == login && (string)reader.GetValue(6) == Crypt.CalcHash(password))
                            return true;
                        else return false;
                    }
                    else return false;
                }
            }
            else return true;
        }
    }
}
