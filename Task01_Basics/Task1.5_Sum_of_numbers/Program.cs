using System;

namespace Task1._5_Sum_of_numbers
{
    class Program
    {
        static int SumNumber()
        {
            int sum = 0;
            for (int i = 1; i < 1000; i++)
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            return sum;
        }
        static void Main()
        {
            Console.WriteLine("Сумма всех чисел меньше 1000 кратных 3 или 5: {0}", SumNumber());
            Console.ReadKey();
        }
    }
}
