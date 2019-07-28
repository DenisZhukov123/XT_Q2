using System;

namespace _4._2_Custom_sort_demo
{
    class Program
    {
        public delegate int Comparison<T>(T first, T second);
        public static void BubbleSort<T>(T[] a, Comparison<T> comp)
        {
            if (comp == null || a == null)
            {
                throw new ArgumentNullException();
            }
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (comp(a[j], a[i]) < 0)
                    {
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        static int CompareString(String first, String second)
        {
            if (first.Length == second.Length)
            {
                String tmp1 = first.ToLower();
                String tmp2 = second.ToLower();
                for (int i = 0; i < tmp1.Length; i++)
                {
                    if (tmp2[i] > tmp1[i])
                        return -1;
                    if (tmp2[i] < tmp1[i])
                        return 1;
                }
                return 0;
            }
            if (first == null) return -1;
            if (second == null) return 1;
            if (first.Length < second.Length) return -1;
            if (first.Length > second.Length) return 1;
            return 0;
        }

        static void Main()
        {
            string[] StringArray = { "ВвВвввв", "вввввб", "ввввва", "ваава", "авааа", "в", "бб", "ааа" };
            BubbleSort(StringArray, CompareString);
            Console.WriteLine("Sorted array:");
            foreach (var item in StringArray)
                Console.WriteLine(item);
        }
    }
}
