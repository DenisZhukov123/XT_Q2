using System;

namespace Task1._4_X_Mas_tree
{
    class Program
    {
        public static void SmallTree(int NumTree, int N)
        {
            for (int i = 0; i < NumTree; i++)
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
        public static void XMasTree(int N)
        {
            if (N < 0)
                Console.WriteLine("Введенные данные некорректны!");
            else
            {
                for (int i = 0; i <= N; i++)
                {
                    Program.SmallTree(i, N);
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
            XMasTree(N);
            Console.ReadKey();
        }
    }
}
