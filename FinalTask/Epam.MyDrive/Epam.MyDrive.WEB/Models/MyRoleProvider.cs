using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Epam.MyDrive.WEB.Models
{
    public enum Roles
    {
        Admin = 0,
        User = 1,
        Guest = 2
    }
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            int role=UsersPL.GetUserRoleByNick(username);
            switch (role)
            {
                case 0: return new[] { "Admin" };
                case 1: return new[] { "User" };
                default: return new[] { "Guest" };
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public static int GetAnotherRole(string nick, string role)
        {
            switch (role)
            {
                case "0": return 1;
                case "1": return 0;
                default: return 2;
            }
        }

        public static string RoleToString(int role)
        {
            switch (role)
            {
                case 0: return "Admin";
                case 1: return "User";
                default: return "Guest";
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        static public bool CreateUser(string login, string password)
        {
            return UsersPL.CreateUser(login, Crypt.CalcHash(password));
        }
    }
}