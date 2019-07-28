using System;
using System.Threading;

namespace _4._3_Sorting_unit
{
    public class Program
    {
        public delegate int Comparison<T>(T first, T second);
        static class SortingUnit
        {
            public static event Action<string> SortingFinished;
            public static void BubbleSort<T>(T[] a, Comparison<T> comp)
            {
                if (comp == null)
                    throw new ArgumentNullException();
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
            public static void RunSortInNewThread<T>(T[] a, Comparison<T> comp)
            {
                ThreadStart thStart = new ThreadStart(
                    () =>
                    {
                        Console.WriteLine("New thread start");
                        BubbleSort(a, comp);
                        SortingFinished?.Invoke("Thread finished");
                    }
                );
                Thread th = new Thread(thStart);
                th.Start();
            }
        }
        public static int CompareString(String first, String second)
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

        static void Finish(string message)
        {
            Console.WriteLine(message);
        }

        public static void Main()
        {
            SortingUnit.SortingFinished += Finish;
            string[] StringArray = { "ВвВвввв", "вввввб", "ввввва", "ваава", "авааа", "в", "бб", "ааа" };
            SortingUnit.RunSortInNewThread(StringArray, CompareString);
            SortingUnit.RunSortInNewThread(StringArray, CompareString);
            SortingUnit.RunSortInNewThread(StringArray, CompareString);
            SortingUnit.RunSortInNewThread(StringArray, CompareString);
            SortingUnit.RunSortInNewThread(StringArray, CompareString);
        }
    }
}
