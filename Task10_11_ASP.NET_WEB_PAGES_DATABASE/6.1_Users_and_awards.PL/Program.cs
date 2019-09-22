using System.Configuration;
using System;
using System.Collections.Generic;
using UsersAndAwards.Entities;
using System.IO;
using IUsersAndAwards.BLL.Interfaces;
using UsersAndAwards.Common;

namespace _6._1_Users_and_awards.PL
{
    class Program
    {

        private static IUsersAndAwardsLogic usersandawardsLogic;
        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select action:");
            Console.WriteLine("1: Create user");
            Console.WriteLine("2: View list of users");
            Console.WriteLine("3: Delete user");
            Console.WriteLine("4: Create new award");
            Console.WriteLine("5: View list of awards");
            Console.WriteLine("6: Award to user");
            Console.WriteLine("0: Exit");
        }

        static public int InputMode()
        {
            int mode;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out mode) && (mode >= 0 && mode <= 6))
                    return mode;
                else
                    Console.WriteLine("Input error! Try again:");
            }
        }

        static public void Save(string path)
        {
            usersandawardsLogic.RecordFiles(path);
        }

        static public void SelectMode(int mode)
        {
            switch (mode)
            {
                case 1:
                    CreateUser();
                    if (sAttr == "1")
                        Save(path);
                    Refresh(path);
                    break;
                case 2:
                    ViewUsers(usersandawardsLogic.GetAllUsers(),true);
                    PrintMenu();
                    SelectMode(InputMode());
                    break;
                case 3:
                    RemoveUser();
                    if (sAttr == "1")
                        Save(path);
                    Refresh(path);
                    break;
                case 4:
                    CreateAward();
                    if (sAttr == "1")
                        Save(path);
                    Refresh(path);
                    break;
                case 5:
                    ViewAwards(usersandawardsLogic.GetAllAwards(),true);
                    PrintMenu();
                    SelectMode(InputMode());
                    break;
                case 6:
                    AddAwardToUser();
                    if (sAttr == "1")
                        Save(path);
                    Refresh(path);
                    break;
                case 0:
                    return;
            }
        }

        static public String EnterNameUser()
        {
            Console.Clear();
            Console.WriteLine("Enter name of user:");
            string Name;
            while (true)
            {
                Name = Console.ReadLine();
                if (Name.Length != 0)
                    return Name;
                else
                    Console.WriteLine("Please enter name of user again:");
            }
        }

        static public String EnterTitleAward()
        {
            Console.Clear();
            Console.WriteLine("Enter title of award:");
            string Title;
            while (true)
            {

                Title = Console.ReadLine();
                if (Title.Length != 0)
                    return Title;
                else
                    Console.WriteLine("Please enter title of award again:");
            }
        }

        static public DateTime EnterBirthUser()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Enter date of birth user (dd:mm:yyyy):");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birth) == true)
                {
                    if(birth<=now)
                        return birth;
                    else Console.WriteLine("Error! Date of birth lagger then now date! Please enter date of birth again:");
                }
                else Console.WriteLine("Please enter date of birth again:");
            }
        }

        static public Guid EnterGuid()
        {
            while (true)
            {
                if (Guid.TryParse(Console.ReadLine(), out Guid id) == true)
                    return id;
                else Console.WriteLine("Error! Please enter id again:");
            }
        }

        static public void CreateUser()
        {
            if (usersandawardsLogic.AddUser(EnterNameUser(), EnterBirthUser()))
                Console.WriteLine("User create successfull!");
            else
                Console.WriteLine("User don't create");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }

        static public void RemoveUser()
        {
            Console.Clear();
            ViewUsers(usersandawardsLogic.GetAllUsers(),false);
            Console.WriteLine("Enter id of user for remove:");
            if (usersandawardsLogic.RemoveUser(EnterGuid()))
                Console.WriteLine("User remove successfull!");
            else
                Console.WriteLine("User don't found");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }

        static public void ViewUsers(ICollection<User> users, bool clear)
        {
            if(clear)
                Console.Clear();
            if (users.Count != 0)
            {
                Console.WriteLine("========================================");
                foreach (var item in users)
                {
                    Console.WriteLine("User:");
                    Console.WriteLine("Id: {0}", item.Id);
                    Console.WriteLine("Name: {0}", item.Name);
                    Console.WriteLine("Date of birth: {0:d}", item.DateOfBirth);
                    Console.WriteLine("Age (years): {0}", item.Age);
                    Console.WriteLine("Awards {0}:", item.Name);
                    GetUserAward(item.Id);
                    Console.WriteLine("========================================");
                }
            }
            else
                Console.WriteLine("List of users is empty");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }

        static public void CreateAward()
        {
            byte[] image= {0};
            if (usersandawardsLogic.AddAward(EnterTitleAward(), image))
                Console.WriteLine("Award create successfull!");
            else
                Console.WriteLine("Award don't create");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }

        static public void ViewAwards(ICollection<Award> awards, bool clear)
        {
            if(clear)
                Console.Clear();
            if (awards.Count != 0)
            {
                Console.WriteLine("========================================");
                foreach (var item in awards)
                {
                    Console.WriteLine("Award:");
                    Console.WriteLine("Id: {0}", item.Id);
                    Console.WriteLine("Title: {0}", item.Title);
                    Console.WriteLine("========================================");
                }
            }
            else
                Console.WriteLine("List of awards is empty");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }

        public static void AddAwardToUser()
        {
            Console.Clear();
            ViewUsers(usersandawardsLogic.GetAllUsers(), false);
            ViewAwards(usersandawardsLogic.GetAllAwards(), false);
            Guid UserId;
            Guid AwardId;
            Console.WriteLine("Enter ID of user:");
            while (true)
            {
                UserId = EnterGuid();
                if (usersandawardsLogic.GetUser(UserId) != null)
                    break;
                else
                    Console.WriteLine("User with this ID don't found. Please try again");
            };
            Console.WriteLine("Enter ID of award:");
            while (true)
            {
                AwardId = EnterGuid();
                if (usersandawardsLogic.GetAward(AwardId) != null)
                    break;
                else
                    Console.WriteLine("Award with this ID don't found. Please try again");
            };
            if(usersandawardsLogic.AddAwardToUser(UserId, AwardId))
            {
                Console.WriteLine("Add award is successfull");
            }
            else
            {
                Console.WriteLine("Add award is failed");
            }
        }

        public static void GetUserAward(Guid UserId)
        {
            foreach(var item in usersandawardsLogic.GetUserAward(UserId))
                Console.WriteLine("{0}", item.Title);
        }

        public static void ReadFiles(string path)
        {
            usersandawardsLogic.ReadFiles(path);
        }

        public static void Refresh(string path)
        {
            sAttr = ConfigurationManager.AppSettings["Mode"];
            switch (sAttr)
            {
                case "0":
                    {
                        
                        usersandawardsLogic = Dependencies.UsersAndAwardsDBLogic;
                    }
                    break;
                case "1":
                    {
                        usersandawardsLogic = Dependencies.UsersAndAwardsFileLogic;
                        ReadFiles(path);
                    }
                    break;
                default:
                    {
                        path = AppDomain.CurrentDomain.BaseDirectory;
                        usersandawardsLogic = Dependencies.UsersAndAwardsFileLogic;
                        ReadFiles(path);
                    }
                    break;
            }
            PrintMenu();
            SelectMode(InputMode());
        }

        public static string path;
        public static string sAttr;
        static void Main(string[] args) 
        {
            path = AppDomain.CurrentDomain.BaseDirectory;
            Refresh(path);
        }
    }
}
