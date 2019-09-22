using System;
using System.Configuration;
using UsersAndAwards.Entities;
using System.Data.SqlClient;
using IUsersAndAwards.DAL.Interfaces;
using System.Collections.Generic;
using System.Data;

namespace _6._1_UsersAndAwards.DAL
{
    public class DataBase:IUsersAndAwardsDAO
    {
        //private static string _connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UsersAndAwards;Integrated Security=True";
        private static string _connectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public bool AddAward(Award award)
        {
            string sqlExpression = "AddAward";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@ID",
                    Value = award.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter titleParam = new SqlParameter
                {
                    ParameterName = "@Title",
                    Value = award.Title
                };
                command.Parameters.Add(titleParam);
                SqlParameter imageParam = new SqlParameter
                {
                    ParameterName = "@Image",
                    Value = award.Image
                };
                command.Parameters.Add(imageParam);


                var result = command.ExecuteNonQuery();

                if (result > 0)
                    return true;
                else
                    return false;
                
            }
        }

        public bool AddAwardUser(Guid IdUser, Guid IdAward)
        {
            string sqlExpression = "AddAwardUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter iduserParam = new SqlParameter
                {
                    ParameterName = "@idUser",
                    Value = IdUser
                };
                command.Parameters.Add(iduserParam);
                SqlParameter idawardParam = new SqlParameter
                {
                    ParameterName = "@idAward",
                    Value = IdAward
                };
                command.Parameters.Add(idawardParam); 
                var result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;

            }
        }

        public bool AddUser(User user)
        {
            string sqlExpression = "AddUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = user.Id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = user.Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter birthParam = new SqlParameter
                {
                    ParameterName = "@birth",
                    Value = user.DateOfBirth
                };
                command.Parameters.Add(birthParam);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public void EditAward(Guid id, string Title, byte[] Image, bool flag_image)
        {         
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                if (flag_image)
                {
                    command.CommandText = @"UPDATE Awards SET Title=@Title, Image=@Image WHERE Id=@Id";
                    command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier, 16);
                    command.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
                    command.Parameters.Add("@Image", SqlDbType.Image, 1000000);
                    command.Parameters["@Id"].Value = id;
                    command.Parameters["@Title"].Value = Title;
                    command.Parameters["@Image"].Value = Image;
                }
                else
                {
                    command.CommandText = @"UPDATE Awards SET Title=@Title WHERE Id=@Id";
                    command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier, 16);
                    command.Parameters.Add("@Title", SqlDbType.NVarChar, 50);
                    command.Parameters["@Id"].Value = id;
                    command.Parameters["@Title"].Value = Title;
                }
                command.ExecuteNonQuery();
            }
        }

        public void EditUser(Guid id, string Name, DateTime Birth)
        {
            string sqlExpression = "EditUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                SqlParameter nameParam = new SqlParameter
                {
                    ParameterName = "@name",
                    Value = Name
                };
                command.Parameters.Add(nameParam);
                SqlParameter birthParam = new SqlParameter
                {
                    ParameterName = "@birth",
                    Value = Birth
                };
                command.Parameters.Add(birthParam);
                command.ExecuteNonQuery();
            }
        }

        public Award GetAward(Guid id)
        {
            string sqlExpression = "GetAward";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    Award temp = new Award((string)reader.GetValue(1), (byte[])reader.GetValue(2));
                    temp.Id = (Guid)reader.GetValue(0);
                    return temp;
                }
                    
                return null;
            }
        }

        public List<User> GetAwardUser(Guid AwardId)
        {
            List<User> ListUser = new List<User>();
            string sqlExpression = "GetAwardUser";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = AwardId
                };
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (GetUser((Guid)reader.GetValue(0)) != null)
                        ListUser.Add(GetUser((Guid)reader.GetValue(0)));
                }
                return ListUser;
            }
        }

        public User GetUser(Guid id)
        {
            string sqlExpression = "GetUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    User temp = new User((string)reader.GetValue(1), (DateTime)reader.GetValue(2));
                    temp.Id = (Guid)reader.GetValue(0);
                    return temp;
                }
                return null;  
            }
        }

        public List<Award> GetUserAward(Guid UserId)
        {
            List<Award> ListAward = new List<Award>();
            string sqlExpression = "GetUserAward";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = UserId
                };
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if(GetAward((Guid)reader.GetValue(1))!=null)
                        ListAward.Add(GetAward((Guid)reader.GetValue(1)));
                }
                return ListAward;
            }
        }

        public void ReadFiles(string path)
        {
            throw new NotImplementedException();
        }

        public void RecordFiles(string path)
        {
            throw new NotImplementedException();
        }

        public bool RemoveAward(Guid id)
        {
            string sqlExpression = "RemoveAward";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool RemoveUser(Guid id)
        {
            string sqlExpression = "RemoveUser";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@id",
                    Value = id
                };
                command.Parameters.Add(idParam);
                var result = command.ExecuteNonQuery();
                if (result > 0)
                    return true;
                else
                    return false;
            }

        }

        public ICollection<Award> SelectAllAwards()
        {
            ICollection<Award> awards = new List<Award>();
            string sqlExpression = "SelectAllAwards";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Award temp = new Award((string)reader.GetValue(1), (byte[])reader.GetValue(2));
                    temp.Id = (Guid)reader.GetValue(0);
                    awards.Add(temp);
                }
                return awards;
            }
        }

        public ICollection<User> SelectAllUsers()
        {
            ICollection<User> users = new List<User>();
            string sqlExpression = "SelectAllUsers";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User temp = new User((string)reader.GetValue(1), (DateTime)reader.GetValue(2));
                    temp.Id = (Guid)reader.GetValue(0);
                    users.Add(temp);
                }
                return users;
            }
        }
    }
}