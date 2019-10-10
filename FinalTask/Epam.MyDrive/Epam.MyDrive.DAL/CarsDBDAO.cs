using Epam.MyDrive.DAL.Interfaces;
using Epam.MyDrive.Entities;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Epam.MyDrive.DAL
{
    public class CarsDBDAO:ICarsDBDAO, ILoggerDAO
    {
        
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public ILog Log => LogManager.GetLogger("LOGGER");
        public void InitLogger()
        {
            XmlConfigurator.Configure();
        }
        public Cars GetCarById(Guid id)
        {
            string sqlExpression = "GetCarById";

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
                    Cars car = new Cars((string)reader.GetValue(1), (string)reader.GetValue(2), (DateTime)reader.GetValue(3), (int)reader.GetValue(4), (byte[])reader.GetValue(5));
                    car.ID = (Guid)reader.GetValue(0);
                    return car;
                }
                return null;
            }
        }

        public List<Cars> GetUserCars(Users user)
        {
            List<Cars> ListCars = new List<Cars>();
            string sqlExpression = "GetUserCars";
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
                    if (((string)reader.GetValue(0)) != null)
                        ListCars.Add(GetCarById((Guid)reader.GetValue(1)));
                }
                return ListCars;
            }
        }

        public bool CarsToUser(Guid Id, string nickname)
        {
            string sqlExpression = "CarsToUser";

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
                    ParameterName = "@Nickname",
                    Value = nickname
                };
                command.Parameters.Add(nick);
                SqlParameter id = new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = Id
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
        public bool CreateCar(Cars car, string nickname)
        {
            string sqlExpression = "CreateCar";

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
                    Value = car.ID
                };
                command.Parameters.Add(id);
                SqlParameter brand = new SqlParameter
                {
                    ParameterName = "@Brand",
                    Value = car.Brand
                };
                command.Parameters.Add(brand);
                SqlParameter model = new SqlParameter
                {
                    ParameterName = "@Model",
                    Value = car.Model
                };
                command.Parameters.Add(model);
                SqlParameter manuf = new SqlParameter
                {
                    ParameterName = "@Manuf",
                    Value = car.YearOfManuf
                };
                command.Parameters.Add(manuf);
                SqlParameter power = new SqlParameter
                {
                    ParameterName = "@Power",
                    Value = car.Power
                };
                command.Parameters.Add(power);
                SqlParameter image = new SqlParameter
                {
                    ParameterName = "@Image",
                    Value = car.Image
                };
                command.Parameters.Add(image);
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
            sqlExpression = "CarsToUser";
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
                    Value = car.ID
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

        public List<Cars> GetAllCars()
        {
            List<Cars> ListCars = new List<Cars>();
            string sqlExpression = "GetAllCars";
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
                    Cars car = new Cars((string)reader.GetValue(1), (string)reader.GetValue(2), (DateTime)reader.GetValue(3), (int)reader.GetValue(4), (byte[])reader.GetValue(5));
                    car.ID = (Guid)reader.GetValue(0);
                    ListCars.Add(car);
                }
                return ListCars;
            }
        }

        public bool DeleteCar(Cars car)
        {
            string sqlExpression = "DeleteCar";

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
                    ParameterName = "@Id",
                    Value = car.ID
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

                if (result <= 0)
                    return false;
            }
            return true;
        }

    }
}
