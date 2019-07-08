using System;

namespace Task1._6_Font_adjustment
{
    class Program
    {
        [Flags]
        enum Font
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }

        public static void PrintMenu()
        {
            Console.WriteLine("Введите:");
            Console.WriteLine("\t1: bold");
            Console.WriteLine("\t2: italic");
            Console.WriteLine("\t3: underline");
            Console.WriteLine("\t4: для выхода");
        }
        public static void Main()
        {
            Font f = Font.None;
            while (true)
            {
                PrintMenu();
                try
                {
                    int num_prop = int.Parse(Console.ReadLine());
                    switch (num_prop)
                    {
                        case 1:
                            f ^= Font.Bold;
                            break;
                        case 2:
                            f ^= Font.Italic;
                            break;
                        case 3:
                            f ^= Font.Underline;
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Ошибка ввода!");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода!");
                }
                Console.WriteLine(f);
            }
        }
    }
}
