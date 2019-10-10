using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace Epam.MyDrive.Entities
{
    public class Users
    {
        public string Nickname { get; set; }
        public byte[] Avatar { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string City { get; set; }
        public string Password { get; set; }
        public string Age
        {
            get
            {
                int age;
                if (DateOfBirth == (DateTime)SqlDateTime.MinValue)
                    return "";
                DateTime now = DateTime.Now;
                age = now.Year - DateOfBirth.Year;
                if (now.Month < DateOfBirth.Month ||
                   (now.Month == DateOfBirth.Month &&
                    now.Day < DateOfBirth.Day))
                    age--;
                return age.ToString();
            }
        }
        public Users(string nickname, byte[] avatar, string surname ,string name, DateTime birth, string city)
         {
             Nickname = nickname;
             Avatar = avatar;
             Surname = surname;
             Name = name;
             DateOfBirth = birth;
             City = city;
         }
        public Users(string nickname, string password, byte[] avatar)
        {
            Nickname = nickname;
            Password = password;
            Avatar = avatar;
        }
    }
}
