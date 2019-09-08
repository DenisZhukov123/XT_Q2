using System;
using System.Collections.Generic;
using _6._1_Users.Entities;
using System.IO;

namespace _6._1_Users.PL
{
    class Program
    {
        private static IUserManageble UsersManager;
   
        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select action:");
            Console.WriteLine("1: Create user");
            Console.WriteLine("2: View list of users");
            Console.WriteLine("3: Delete user");
            Console.WriteLine("0: Exit");
        }

        static public int InputMode()
        {
            int mode;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out mode) && (mode >= 0 && mode <= 3))
                    return mode;
                else
                {
                    Console.WriteLine("Input error! Try again:");
                }
            }
        }

        static public void Save(string path)
        {
            UsersManager.RecordFile(path);
        }

        static public void SelectMode(int mode)
        {
            switch (mode)
            {
                case 1:
                    CreateUser();
                    Save(path);
                    Refresh(path);
                    break;
                case 2:
                    ViewUsers(UsersManager.GetAllUsers());
                    PrintMenu();
                    SelectMode(InputMode());
                    break;
                case 3:
                    RemoveUser();
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
        static public DateTime EnterBirthUser()
        {
            DateTime now = DateTime.Now;
            Console.WriteLine("Enter date of birth user (dd:mm:yyyy):");
            while (true)
            {
                if (DateTime.TryParse(Console.ReadLine(), out DateTime birth) == true)
                {
                    if (birth <= now)
                        return birth;
                    else Console.WriteLine("Error! Date of birth lagger then now date! Please enter date of birth again:");
                }
                else Console.WriteLine("Please enter date of birth again:");
            }
        }
        static public void CreateUser()
        {
            if(UsersManager.AddUser(EnterNameUser(),EnterBirthUser()))
                Console.WriteLine("User create successfull!");
            else
                Console.WriteLine("User don't create");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
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
        static public void RemoveUser()
        {
            Console.Clear();
            ViewUsers(UsersManager.GetAllUsers());
            Console.WriteLine("Enter id of user for remove:");
            if (UsersManager.RemoveUser(EnterGuid()))
                Console.WriteLine("User remove successfull!");
            else
                Console.WriteLine("User don't found");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }
        static public void ViewUsers(ICollection<User> users)
        {
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
                    Console.WriteLine("========================================");
                }
            }
            else
                Console.WriteLine("List of users is empty");
            Console.WriteLine("Please press any key for continue");
            Console.ReadKey();
        }
        public static void ReadFile(string path)
        {
            UsersManager.ReadFile(path);
        }
        public static void Refresh(string path)
        {
            UsersManager = Dependencies.Dependencies.UsersManager;
            ReadFile(path);
            PrintMenu();
            SelectMode(InputMode());
        }
        static public string EnterAndCheckPath()
        {
            string path;
            Console.WriteLine("Please enter path for folder for work:");
            while (true)
            {
                path = Console.ReadLine();
                if (!Directory.Exists(@path))
                    Console.WriteLine("Directory is not found! Try again:");
                else break;
            }
            return path;
        }

        public static string path; 
        static void Main(string[] args)
        {
            path=EnterAndCheckPath();
            Refresh(path);
        }
    }
}
