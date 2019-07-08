using System;

namespace Task1._2_Triangle
{
    class Program
    {
        public static void Triangle(int N)
        {
            if (N < 0)
                Console.WriteLine("Введенные данные некорректны!");
            else
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write("\n\r");
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write("*");
                    }
                }
            }
            Console.Write("\n\r");
        }
        static void Main()
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
            Triangle(N);
            Console.ReadKey();
        }
    }
}
