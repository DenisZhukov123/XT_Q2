using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._6_I_seek_you
{
    class Program
    {
        public delegate bool Positive(int a);
        public static List<int> FindAllPositive(int[] mass)
        {
            if (mass == null)
                throw new ArgumentNullException();
            List<int> result = new List<int>();
            for (int i = 0; i < mass.Length; i++)
                if (mass[i] > 0)
                    result.Add(mass[i]);
            return result;
        }

        public static List<int> FindAllPositiveDelegate(int[] mass, Positive pos)
        {
            if (mass == null||pos==null)
                throw new ArgumentNullException();
            List<int> result = new List<int>();
            for (int i = 0; i < mass.Length; i++)
                if (pos(mass[i]))
                    result.Add(mass[i]);
            return result;
        }

        public static int[] FindAllPositiveLinq(int[] mass)
        {
            if (mass == null)
                throw new ArgumentNullException();
            var query = from item in mass where item > 0 select item;
            return query.ToArray();
        }


        public static List<int> FindAllPositiveAnon(int[] mass, Positive pos)
        {
            if (mass == null||pos==null)
                throw new ArgumentNullException();
            List<int> result = new List<int>();
            for (int i = 0; i < mass.Length; i++)
                if (pos(mass[i]))
                    result.Add(mass[i]);
            return result;
        }

        public static bool IsPositive(int a)
        {
            if (a > 0)
                return true;
            return false;
        }

        static void Main()
        {
            int[] massive =new int[]{-1,2,5,-3,5,-6,-2,7,8};
            List<int> result1 = new List<int>();
            List<int> result2 = new List<int>();
            List<int> result3 = new List<int>();
            List<int> result4 = new List<int>();
            result1 =FindAllPositive(massive);
            result2=FindAllPositiveDelegate(massive,IsPositive);
            Console.WriteLine("Result for simple void:");
            foreach (var item in result1)
                Console.Write("{0} ", item);
            Console.WriteLine("");
            Console.WriteLine("Result for void delegate:");
            foreach (var item in result2)
                Console.Write("{0} ", item);
            Console.WriteLine("");
            Positive pos_anon = delegate (int a)
            {
                if (a > 0)
                    return true;
                return false;
            };
            result3 = FindAllPositiveAnon(massive, pos_anon);
            Console.WriteLine("Result for anon void:");
            foreach (var item in result3)
                Console.Write("{0} ", item);
            Console.WriteLine("");
            Positive pos_lambda =  (a) =>
            {
                if (a > 0)
                    return true;
                return false;
            };
            result4 = FindAllPositiveAnon(massive, pos_lambda);
            Console.WriteLine("Result for lambda void:");
            foreach (var item in result4)
                Console.Write("{0} ", item);
            Console.WriteLine("");
            Console.WriteLine("Result for LINQ void:");
            foreach (var item in FindAllPositiveLinq(massive))
                Console.Write("{0} ", item);
            Console.WriteLine("");
        }
    }
}
