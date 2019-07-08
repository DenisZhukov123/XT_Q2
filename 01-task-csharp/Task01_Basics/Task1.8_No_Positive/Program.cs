using System;

namespace Task1._8_No_Positive
{
    class Program
    {
        public static int[,,] ZeroPositive(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                    {
                        if (array[i,j,k] > 0)
                            array[i,j,k] = 0;
                    }
                }
            }
            return array;
        }
        public static void PrintArray(int[,,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    for (int k = 0; k < array.GetLength(2); k++)
                        Console.Write("{0} ", array[i,j,k]);
                }
            }    
            Console.Write("\n\r");
        }
        static void Main()
        {
            int[,,] array = new int[5,5,5];    
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                        array[i,j,k] = rnd.Next(-100, 100);
                }
                    
            }
            Console.WriteLine("Сгенерированный массив:");
            PrintArray(array);
            Console.WriteLine("Массив с замененными положительными элементами:");
            PrintArray(ZeroPositive(array));
            Console.ReadKey();
        }
    }
}
