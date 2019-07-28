using System;

namespace _4._1_Custom_sort
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

        static void Main()
        {
        }
    }
 }
