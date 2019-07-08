using System;

namespace Task0._3_Square
{
    class Program
    {
        public static void Square(int N)
        {
            for (int i = 0; i < N; i++)
            {
                Console.Write("\n\r");
                for (int j = 0; j < N; j++)
                {
                    if (i == N / 2 && j == N / 2)
                        Console.Write(" ");
                    else
                        Console.Write("*");
                }
            }
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
            if (N % 2 == 0||N<=0)
                Console.WriteLine("Число {0} не удовлетворяет условиям задачи", N);
            else
                Square(N);
        }
    }
}
