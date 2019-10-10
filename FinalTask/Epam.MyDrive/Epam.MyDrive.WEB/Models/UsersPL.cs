using Epam.MyDrive.BLL.Interfaces;
using Epam.MyDrive.Common;
using Epam.MyDrive.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Epam.MyDrive.WEB.Models
{
    public static class UsersPL
    {
        private static IUsersLogic _usersLogic = Dependency.usersLogic;
       
        public static string Path { get; private set; }= AppDomain.CurrentDomain.BaseDirectory;
        public static string CurrentUser { get; set; }
        public static string ViewUser { get; set; }
        public static Users GetUserByNick(string nickname)
        {
            return _usersLogic.GetUserByNick(nickname);
        }

        public static int GetUserRoleByNick(string nickname)
        {
            return _usersLogic.GetUserRoleByNick(nickname);
        }

        public static bool CheckNick(string nick)
        {
            if (nick.Length > 0 && nick.Length < 25)
                return true;
            else return false;
        }

        static public bool CheckImage(string avatar)
        {
            if (avatar.Length > 0)
            {
                if (File.Exists(avatar))
                {
                    return true;
                }
            }
            return false;

        }
        public static byte[] ImageToByte(string avatar)
        {
            byte[] imageBytes = File.ReadAllBytes(avatar);
            return imageBytes;

        }

        static public bool CheckBirthUser(string Birth, out DateTime birth)
        {
            DateTime now = DateTime.Now;
            if (DateTime.TryParse(Birth, out birth) == true)
            {
                if (birth <= now)
                    return true;
                return false;
            }
            return false;
        }

        public static bool CreateUser(string nickname, string password)
        {
            byte[] tempImage= ImageToByte(Path + @"Pages\Image\default.png");
            Users user = new Users(nickname, password, tempImage);
            return _usersLogic.CreateUser(user);
        }

        public static bool EditUser(string nickname, byte[] avatar, string surname, string name, string birth, string city)
        {
            if (GetUserByNick(nickname) != null)
                return false;
            Users user = GetUserByNick(CurrentUser);
            string Tempnick;
            byte[] Tempavatar;
            string Tempsurname;
            string Tempname;
            DateTime Tempbirth;
            string Tempcity;
            if (nickname.Length != 0)
                Tempnick = nickname;
            else
                Tempnick = user.Nickname;
            if (avatar != null)
                Tempavatar = avatar;
            else
                Tempavatar = user.Avatar;
            if (surname.Length != 0)
                Tempsurname = surname;
            else
                Tempsurname = user.Surname;
            if (name.Length != 0)
                Tempname = name;
            else
                Tempname = user.Name;
            if (birth.Length != 0)
                CheckBirthUser(birth, out Tempbirth);
            else
            {
                if (user.DateOfBirth == DateTime.MinValue)
                    Tempbirth = (DateTime)SqlDateTime.MinValue;
                else
                    Tempbirth = user.DateOfBirth;
            }
                
            if (city.Length != 0)
                Tempcity = city;
            else
                Tempcity = user.City;
            Users newuser = new Users(Tempnick, Tempavatar, Tempsurname, Tempname, Tempbirth, Tempcity);
            return _usersLogic.EditUser(newuser, CurrentUser);
        }
        public static List<Users> GetAllUsers()
        {
            return _usersLogic.GetAllUsers();
        }
        public static void DeleteUser(Users user)
        {
            if (_usersLogic.DeleteUser(user))
            {
                List<Blogs> ListBlogs = new List<Blogs>();
                ListBlogs = BlogsPL.GetUserBlogs(user);
                List<Cars> ListCars = new List<Cars>();
                ListCars = CarsPL.GetUserCars(user);
                foreach (var item in ListBlogs)
                {
                    BlogsPL.DeleteBlogUser(item, user.Nickname);
                }
                foreach (var item in ListCars)
                {
                    CarsPL.DeleteCar(item);
                }
            }
        }
        public static bool EditRoleUser(string nickname, int role)
        {
            return _usersLogic.EditRoleUser(nickname, role);
        }

        public static List<Users> SearchUsers(string search)
        {
            return _usersLogic.SearchUsers(search);
        }

        public static bool SubscribeToUser(string nick, string subsnick)
        {
            return _usersLogic.SubscribeToUser(nick, subsnick);
        }

        public static bool UnSubscribeToUser(string nick, string subsnick)
        {
            return _usersLogic.UnSubscribeToUser(nick, subsnick);
        }
        public static bool CheckSubscribeToUser(string nick, string subsnick)
        {
            return _usersLogic.CheckSubscribeToUser(nick, subsnick);
        }

        public static int GetCountSubscribeToUser(string nick)
        {
            return _usersLogic.GetCountSubscribeToUser(nick);
        }
        public static int GetCountUsersToSubscribe(string nick)
        {
            return _usersLogic.GetCountUsersToSubscribe(nick);
        }
    }
}