using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users.Entities
{
    public interface IUsersStorable
    {
        bool AddUser(User user);
        bool RemoveUser(Guid id);

        void RecordFile(string path);
        void ReadFile(string path);

        ICollection<User> SelectAllUsers();
    }
}
