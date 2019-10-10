using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.DAL.Interfaces;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;

namespace Epam.MyDrive.BLL
{
    public class UsersLogic:IUsersLogic
    {
        private readonly IUsersDBDAO _usersDBDAO;

        public UsersLogic(IUsersDBDAO userDAO)
        {
            _usersDBDAO = userDAO;
        }
      
        public Users GetUserByNick(string nickname)
        {
            return _usersDBDAO.GetUserByNick(nickname);
        }

        public bool CreateUser(Users user)
        {
            return _usersDBDAO.CreateUser(user);
        }

        public bool EditUser(Users user, string oldnick)
        {
            return _usersDBDAO.EditUser(user, oldnick);
        }

        public List<Users> GetAllUsers()
        {
            return _usersDBDAO.GetAllUsers();
        }

        public int GetUserRoleByNick(string nickname)
        {
            return _usersDBDAO.GetUserRoleByNick(nickname);
        }
        public bool DeleteUser(Users user)
        {
            return _usersDBDAO.DeleteUser(user);
        }

        public bool EditRoleUser(string nickname, int role)
        {
            return _usersDBDAO.EditRoleUser(nickname, role);
        }

        public List<Users> SearchUsers(string search)
        {
            return _usersDBDAO.SearchUsers(search);
        }

        public bool SubscribeToUser(string nick, string subsnick)
        {
            return _usersDBDAO.SubscribeToUser(nick, subsnick);
        }
        public bool UnSubscribeToUser(string nick, string subsnick)
        {
            return _usersDBDAO.UnSubscribeToUser(nick, subsnick);
        }

        public bool CheckSubscribeToUser(string nick, string subsnick)
        {
            return _usersDBDAO.CheckSubscribeToUser(nick, subsnick);
        }
        public int GetCountSubscribeToUser(string nick)
        {
            return _usersDBDAO.GetCountSubscribeToUser(nick);
        }
        public int GetCountUsersToSubscribe(string nick)
        {
            return _usersDBDAO.GetCountUsersToSubscribe(nick);
        }

        public void SetAdmin()
        {
            _usersDBDAO.SetAdmin();
        }

        public bool CanLogin(string login, string password)
        {
            return _usersDBDAO.CanLogin(login,password);
        }
    }
}
