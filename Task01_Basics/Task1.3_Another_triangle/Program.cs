using System;

namespace Task1._3_Another_triangle
{
    class Program
    {
        public static void AnotherTriangle(int N)
        {
            if (N < 0)
                Console.WriteLine("Введенные данные некорректны!");
            else
            {
                for (int i = 0; i < N; i++)
                {
                    Console.Write("\n\r");
                    for (int j = 0; j < 2 * N; j++)
                    {
                        if (j >= N - i && j <= N + i)
                            Console.Write("*");
                        else
                            Console.Write(" ");
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
                Console.WriteLine("Введенные данные некорректны!");
                return;
            }
            AnotherTriangle(N);
            Console.ReadKey();
        }
    }
}
