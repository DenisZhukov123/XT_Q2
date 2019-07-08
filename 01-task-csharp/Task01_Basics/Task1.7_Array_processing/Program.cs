using System;

namespace Task1._7_Array_processing
{
    class Program
    {
        public static int[] SortBubble(int[] array) // функция сортировки используется самая простаясортировка пузырьком
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        public static void MaxMin(int[] array) 
        {
            int max = array[0];
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (max <= array[i])
                    max = array[i];
                if (min >= array[i])
                    min = array[i];
            }
            Console.WriteLine("Максимальное значение в массиве: {0}", max);
            Console.WriteLine("Минимальное значение в массиве: {0}", min);
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
            MaxMin(array);
            Console.WriteLine("Отсортированный массив:");
            PrintArray(SortBubble(array));
        }
    }
}
