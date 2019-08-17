using System;
using System.Collections.Generic;
using System.Text;

namespace _6._1_Users_and_awards.Entities
{
    public interface IUsersStorable
    {
        bool AddUser(User user);
        bool RemoveUser(Guid id);
        User GetUser(Guid id);
        ICollection<User> SelectAllUsers();
    }
}
