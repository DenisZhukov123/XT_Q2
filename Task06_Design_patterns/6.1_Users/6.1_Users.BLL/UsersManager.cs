using _6._1_Users.Dependencies;
using System;
using System.Collections.Generic;
using System.Text;
using _6._1_Users.Entities;
using _6._1_Users.DAL;

namespace _6._1_Users.BLL
{
    public static class UsersManager
    {
        public static IUsersStorable MemoryStorage => Dependencies.Dependencies.UsersStorage;
        public static bool AddUser(string name, DateTime birth)
        {
            return MemoryStorage.AddUser(new User(name, birth));
        }

        public static bool RemoveUser(Guid id)
        {
            return MemoryStorage.RemoveUser(id);
        }

        public static void RecordFile(string path)
        {
            MemoryStorage.RecordFile(path);
        }

        public static void ReadFile(string path)

        {
            MemoryStorage.ReadFile(path);
        }

        public static ICollection<User> GetAllUsers()
        {
            return MemoryStorage.SelectAllUsers();
        }
    }
}
