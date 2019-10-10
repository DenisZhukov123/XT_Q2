using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.MyDrive.BLL.Interfaces
{
    public interface IUsersLogic
    {
        bool CreateUser(Users user);
        Users GetUserByNick(string nickname);
        int GetUserRoleByNick(string nickname);
        bool EditUser(Users user, string oldnick);
        bool DeleteUser(Users user);
        bool EditRoleUser(string nickname, int role);
        List<Users> GetAllUsers();
        List<Users> SearchUsers(string search);
        bool SubscribeToUser(string nick, string subsnick);
        bool UnSubscribeToUser(string nick, string subsnick);
        bool CheckSubscribeToUser(string nick, string subsnick);
        int GetCountSubscribeToUser(string nick);
        int GetCountUsersToSubscribe(string nick);
        void SetAdmin();
        bool CanLogin(string login, string password);
    }
}
