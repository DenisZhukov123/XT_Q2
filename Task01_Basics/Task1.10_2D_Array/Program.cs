using System;

namespace Task1._10_2D_Array
{
    class Program
    {
        public static int Summ(int[,] array)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {   
                    if((i+j)%2==0)
                        sum += array[i, j];
                }
            }
            return sum;
        }
        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                Console.Write("\n\r");
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(array[i, j]>=0)
                        Console.Write(" {0} ", array[i, j]);
                    else
                        Console.Write("{0} ", array[i, j]);
                }
            }
            Console.Write("\n\r");
        }
        static void Main()
        {
            int[,] array = new int[5, 5];
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                        array[i, j] = rnd.Next(-100, 100);
                }

            }
            Console.WriteLine("Сгенерированный массив:");
            PrintArray(array);
            Console.WriteLine("Сумма элементов массива на четной позиции = {0}", Summ(array));
            Console.ReadKey();
        }
    }
}
