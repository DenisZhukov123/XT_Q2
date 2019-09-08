using System;
using System.Collections.Generic;
using System.Text;
using _6._1_Users.Entities;
using _6._1_Users.DAL;

namespace _6._1_Users.BLL
{
    public class UsersManager: IUserManageble
    {
        private readonly IUsersStorable MemoryStorage;

        public UsersManager(IUsersStorable MemoryStorage)
        {
            this.MemoryStorage = MemoryStorage;
        }
        public bool AddUser(string name, DateTime birth)
        {
            return MemoryStorage.AddUser(new User(name, birth));
        }

        public bool RemoveUser(Guid id)
        {
            return MemoryStorage.RemoveUser(id);
        }

        public void RecordFile(string path)
        {
            MemoryStorage.RecordFile(path);
        }

        public void ReadFile(string path)

        {
            MemoryStorage.ReadFile(path);
        }

        public ICollection<User> GetAllUsers()
        {
            return MemoryStorage.SelectAllUsers();
        }
    }
}
