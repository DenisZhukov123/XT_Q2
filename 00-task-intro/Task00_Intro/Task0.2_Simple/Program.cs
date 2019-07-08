using System;

namespace Task0._2_Simple
{
    class Program
    {
        public static void CheckSimple(int N)
        {
            if (N <=1)
            {
                Console.WriteLine("Введенное число не может быть ни простым, ни составным");
                return;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(N); i++)
                {
                    if (N % i == 0 && N != i)
                    {
                        Console.WriteLine("Введенное число составное");
                        return;
                    }          
                }
            }
            Console.WriteLine("Введенное число простое");
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
            CheckSimple(N);
        }
    }
}
