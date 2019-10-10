using Epam.MyDrive.DAL.Interfaces;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Epam.MyDrive.DAL
{
    public class MessageDBDAO : IMessageDBDAO, ILoggerDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public ILog Log => LogManager.GetLogger("LOGGER");
        public void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public bool CreateMessage(Message message)
        {
            string sqlExpression = "CreateMessage";

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
                SqlParameter idmessage = new SqlParameter
                {
                    ParameterName = "@IdMessage",
                    Value = message.ID
                };
                command.Parameters.Add(idmessage);
                SqlParameter sendnick = new SqlParameter
                {
                    ParameterName = "@SendNick",
                    Value = message.SendNick
                };
                command.Parameters.Add(sendnick);
                SqlParameter recnick = new SqlParameter
                {
                    ParameterName = "@RecNick",
                    Value = message.RecNick
                };
                command.Parameters.Add(recnick);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = message.Text
                };
                command.Parameters.Add(text);
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

        public bool EditMessage(Message message)
        {
            string sqlExpression = "EditMessage";
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
                SqlParameter idmess = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = message.ID
                };
                command.Parameters.Add(idmess);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = message.Text
                };
                command.Parameters.Add(text);
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

        public bool DeleteMessage(Guid id)
        {
            string sqlExpression = "DeleteMessage";

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
                SqlParameter idmess = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                command.Parameters.Add(idmess);
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

        public List<Message> GetAllMeMessage(string nick)
        {
            List<Message> ListMessage = new List<Message>();
            string sqlExpression = "GetAllMeMessage";
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
                SqlParameter recnick = new SqlParameter
                {
                    ParameterName = "@RecNick",
                    Value = nick
                };
                command.Parameters.Add(recnick);
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
                    Message message = new Message((string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
                    message.ID = (Guid)reader.GetValue(0);
                    ListMessage.Add(message);
                }
                return ListMessage;
            }
        }

        public List<Message> GetAllMyMessage(string nick)
        {
            List<Message> ListMessage = new List<Message>();
            string sqlExpression = "GetAllMyMessage";
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
                SqlParameter sendnick = new SqlParameter
                {
                    ParameterName = "@SendNick",
                    Value = nick
                };
                command.Parameters.Add(sendnick);
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
                    Message message = new Message((string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
                    message.ID = (Guid)reader.GetValue(0);
                    ListMessage.Add(message);
                }
                return ListMessage;
            }
        }

        public Message GetMessageById(Guid id)
        {
            string sqlExpression = "GetMessageById";

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
                SqlParameter idmess = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                command.Parameters.Add(idmess);
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
                    Message mess = new Message((string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
                    mess.ID = (Guid)reader.GetValue(0);
                    return mess;
                }
                return null;
            }
        }

        public List<Message> GetAllMessage()
        {
            List<Message> ListMessage = new List<Message>();
            string sqlExpression = "GetAllMessage";
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
                    Message message = new Message((string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3));
                    message.ID = (Guid)reader.GetValue(0);
                    ListMessage.Add(message);
                }
                return ListMessage;
            }
        }
    }
}
