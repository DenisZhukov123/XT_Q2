using System;
using System.Text;

namespace Task0._1_Sequence
{
    class Program
    {
        public static string ReturnString(int N)
        {
            if (N <= 0)
                return "Число " + N + " меньше 1";
            var result = new StringBuilder("1");
            for (int i = 2; i <= N; i++)
            {
                result.Append(", ").Append(i.ToString());
            }
            return result.ToString();
        }
        public static void Main()
        {
            Console.WriteLine("Введите число N: ");
            int N;
            try
            {
                N = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка при вводе!");
                return;
            }
            Console.WriteLine("Для N={0}: {1}", N, ReturnString(N));
        }
    }
}
