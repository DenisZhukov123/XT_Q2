using System;
using _6._1_Users.Entities;

namespace _6._1_Users.PL
{
    class Program
    {
        static public void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Please select action:");
            Console.WriteLine("1: Create user");
            Console.WriteLine("2: View list of users");
            Console.WriteLine("3: Delete user");
            Console.WriteLine("4: Save");
            Console.WriteLine("5: Exit");
        }

        static public int InputMode()
        {
            int mode;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out mode) && (mode >= 1 && mode <= 5))
                    return mode;
                else
                {
                    Console.WriteLine("Input error! Try again:");
                }
            }
        }

        static public void SelectMode(int mode)
        {
                switch (mode)
                {
                    case 1:
                    var newUser = new User();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        return;
                }
        }


        static void Main(string[] args)
        {
            PrintMenu();
            SelectMode(InputMode());
        }
    }
}
