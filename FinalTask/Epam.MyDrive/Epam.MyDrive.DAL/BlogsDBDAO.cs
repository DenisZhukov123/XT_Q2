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
    public class BlogsDBDAO : IBlogsDBDAO, ILoggerDAO
    {

        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public ILog Log => LogManager.GetLogger("LOGGER");
        public void InitLogger()
        {
            XmlConfigurator.Configure();
        }

        public Blogs GetBlogById(Guid id)
        {
            string sqlExpression = "GetBlogById";

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
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = id
                };
                command.Parameters.Add(idParam);
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
                    Blogs blog = new Blogs((string)reader.GetValue(1), (string)reader.GetValue(2));
                    blog.ID = (Guid)reader.GetValue(0);
                    return blog;
                }
                return null;
            }
        }

        public List<Blogs> GetUserBlogs(Users user)
        {
            List<Blogs> ListBlogs = new List<Blogs>();
            string sqlExpression = "GetUserBlogs";
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
                    ParameterName = "@Nickname",
                    Value = user.Nickname
                };
                command.Parameters.Add(nick);
                SqlDataReader reader; ;

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
                    if (((string)reader.GetValue(0)) != null)
                        ListBlogs.Add(GetBlogById((Guid)reader.GetValue(1)));
                }
                return ListBlogs;
            }
        }

        
        public bool CreateBlogUser(Blogs blog, string nickname)
        {
            string sqlExpression = "CreateBlogUser";

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
                SqlParameter id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = blog.ID
                };
                command.Parameters.Add(id);
                SqlParameter title = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = blog.Title
                };
                command.Parameters.Add(title);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = blog.Text
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

                if (result == 0)
                    return false;
            }
            sqlExpression = "BlogsToUser";
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
                SqlParameter id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = blog.ID
                };
                command.Parameters.Add(id);
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

        public bool CreateBlogCar(Blogs blog, Guid IdCar)
        {
            string sqlExpression = "CreateBlogCar";

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
                SqlParameter id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = blog.ID
                };
                command.Parameters.Add(id);
                SqlParameter title = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = blog.Title
                };
                command.Parameters.Add(title);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = blog.Text
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


                if (result == 0)
                    return false;
            }
            sqlExpression = "BlogsToCar";
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
                SqlParameter idcar = new SqlParameter
                {
                    ParameterName = "@IdCar",
                    Value = IdCar
                };
                command.Parameters.Add(idcar);
                SqlParameter idblog = new SqlParameter
                {
                    ParameterName = "@IdBlog",
                    Value = blog.ID
                };
                command.Parameters.Add(idblog);
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

        public List<Blogs> GetCarBlogs(Cars car)
        {
            List<Blogs> ListBlogs = new List<Blogs>();
            string sqlExpression = "GetCarBlogs";
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
                    ParameterName = "@IdCar",
                    Value = car.ID
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
                        ListBlogs.Add(GetBlogById((Guid)reader.GetValue(1)));
                }
                return ListBlogs;
            }
        }

        public bool EditBlog(Blogs blog)
        {
            string sqlExpression = "EditBlog";
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
                SqlParameter idblog = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = blog.ID
                };
                command.Parameters.Add(idblog);
                SqlParameter title = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = blog.Title
                };
                command.Parameters.Add(title);
                SqlParameter text = new SqlParameter
                {
                    ParameterName = "@Text",
                    Value = blog.Text
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

        public bool DeleteBlogUser(Blogs blog, string nickname)
        {
            string sqlExpression = "DeleteBlogUser";

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
                SqlParameter idblog = new SqlParameter
                {
                    ParameterName = "@IdBlog",
                    Value = blog.ID
                };
                command.Parameters.Add(idblog);
                SqlParameter nick = new SqlParameter
                {
                    ParameterName = "@Nick",
                    Value = nickname
                };
                command.Parameters.Add(nick);
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

        public bool DeleteBlogCar(Blogs blog, Guid id)
        {
            string sqlExpression = "DeleteBlogCar";

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
                SqlParameter idblog = new SqlParameter
                {
                    ParameterName = "@IdBlog",
                    Value = blog.ID
                };
                command.Parameters.Add(idblog);
                SqlParameter idcar = new SqlParameter
                {
                    ParameterName = "@IdCar",
                    Value = id
                };
                command.Parameters.Add(idcar);
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

        public List<Blogs> SearchBlogs(string search)
        {
            List<Blogs> ListBlogs = new List<Blogs>();
            string sqlExpression = "SearchBlog";
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
                    if (((Guid)reader.GetValue(0)) != null)
                        ListBlogs.Add(GetBlogById((Guid)reader.GetValue(0)));
                }
                return ListBlogs;
            }
        }
    }
}
