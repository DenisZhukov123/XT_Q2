using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users.Entities
{
   public interface IUserManageble
    {
        bool AddUser(string name, DateTime birth);
        bool RemoveUser(Guid id);
        void RecordFile(string path);
        void ReadFile(string path);
        ICollection<User> GetAllUsers();
    }
}
