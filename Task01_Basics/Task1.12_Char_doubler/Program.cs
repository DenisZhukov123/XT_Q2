using System;

namespace Task1._12_Char_doubler
{
    class Program
    {
        public static string DoubleChar(string str1, string str2)
        {
            string result = "";
            foreach (char ch in str1)
                if (str2.Contains(ch) != true)
                    result += ch;
                else
                    result = result + ch + ch;
            return result;
        }

        public static void Main()
        {
            Console.WriteLine("Введите первую строку:");
            string str1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку:");
            string str2 = Console.ReadLine();
            Console.WriteLine(DoubleChar(str1, str2));
            Console.ReadKey();
        }
    }
}
