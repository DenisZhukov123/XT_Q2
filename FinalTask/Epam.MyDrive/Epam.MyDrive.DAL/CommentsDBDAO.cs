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
    public class CommentsDBDAO : ICommentsDBDAO, ILoggerDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public ILog Log => LogManager.GetLogger("LOGGER");
        public void InitLogger()
        {
            XmlConfigurator.Configure();
        }
        public bool CreateComment(Comments comment, Blogs blog)
        {
            string sqlExpression = "CreateComment";

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
                SqlParameter idcommnet = new SqlParameter
                {
                    ParameterName = "@IdComment",
                    Value = comment.ID
                };
                command.Parameters.Add(idcommnet);
                SqlParameter idblog = new SqlParameter
                {
                    ParameterName = "@IdBlog",
                    Value = blog.ID
                };
                command.Parameters.Add(idblog);
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = comment.Nickname
                };
                command.Parameters.Add(nick);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = comment.Text
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

        public List<Comments> GetAllComments(Blogs blog)
        {
            List<Comments> ListComments = new List<Comments>();
            string sqlExpression = "GetCommentsBlog";
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
                SqlParameter id = new SqlParameter
                {
                    ParameterName = "@IdBlog",
                    Value = blog.ID
                };
                command.Parameters.Add(id);
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
                    if (((Guid)reader.GetValue(0)) != null)
                    {
                        Comments comment = new Comments((string)reader.GetValue(2), (string)reader.GetValue(3));
                        comment.ID = (Guid)reader.GetValue(0);
                        ListComments.Add(comment);
                    }
                        
                }
                return ListComments;
            }
        }

    }
}
