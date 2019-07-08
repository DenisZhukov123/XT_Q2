using System;

namespace Task1._9_Non_negative_sum
{
    class Program
    {

        public static void Summ(int[] array)
        {
            int summ = 0;
            bool check_positive = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    summ += array[i];
                    check_positive = true;
                }
            }
            if(check_positive==true)
                Console.WriteLine("Сумма положительных элементов в массиве = {0}", summ);
            else
                Console.WriteLine("В массиве не найдено положительных элементов");
        }
        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0} ", array[i]);
            Console.Write("\n\r");

        }
        static void Main()
        {
            int[] array = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
                array[i] = rnd.Next(-100, 100);
            Console.WriteLine("Сгенерированный массив:");
            PrintArray(array);
            Summ(array);
            Console.ReadKey();
        }
    }
}
