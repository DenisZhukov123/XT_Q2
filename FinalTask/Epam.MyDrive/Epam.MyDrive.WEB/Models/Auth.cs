using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Epam.MyDrive.WEB.Models
{
    public static class Auth
    {
      
        private static IUsersLogic _usersLogic = Dependency.usersLogic;

        public static void SetAdmin()
        {
            _usersLogic.SetAdmin();
        }

        public static bool CanLogin(string login, string password)
        {
            SetAdmin();
            return _usersLogic.CanLogin(login,password);
        }
    }
}
   