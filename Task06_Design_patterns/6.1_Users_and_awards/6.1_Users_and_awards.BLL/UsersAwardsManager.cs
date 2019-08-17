using _6._1_Users_and_awards.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using _6._1_Users_and_awards.Entities;
using _6._1_Users_and_awards.DAL;

namespace _6._1_Users_and_awards.BLL
{
    public static class UsersAwardsManager
    {
        public static IUsersStorable MemoryUserStorage => Dependencies.Dependencies.UsersStorage;
        public static IAwardsStorable MemoryAwardStorage => Dependencies.Dependencies.AwardsStorage;
        public static IUserAwardTable UserAwardTable => Dependencies.Dependencies.UserAwardTable;

        public static bool AddUser(string name, DateTime birth)
        {
            return MemoryUserStorage.AddUser(new User(name, birth));
        }
        public static User GetUser(Guid id)
        {
            return MemoryUserStorage.GetUser(id);
        }
        public static bool RemoveUser(Guid id)
        {
            return MemoryUserStorage.RemoveUser(id);
        }
        public static ICollection<User> GetAllUsers()
        {
            return MemoryUserStorage.SelectAllUsers();
        }
        public static bool AddAward(string title)
        {
            return MemoryAwardStorage.AddAward(new Award(title));
        }
        public static List<Award> GetUserAward(Guid UserId)
        {
            return UserAwardTable.GetUserAward(UserId);
        }
        public static Award GetAward(Guid id)
        {
            return MemoryAwardStorage.GetAward(id);
        }
        public static ICollection<Award> GetAllAwards()
        {
            return MemoryAwardStorage.SelectAllAwards();
        }
        public static bool AddAwardToUser(Guid IdUser, Guid IdAward)
        {
            return UserAwardTable.AddAwardUser(IdUser, IdAward);
        }
        public static void RecordFiles(string path)
        {
            MemoryStorage.RecordFiles(path);
        }
        public static void ReadFiles(string path)
        {
            MemoryStorage.ReadFiles(path);
        }
    }
}
