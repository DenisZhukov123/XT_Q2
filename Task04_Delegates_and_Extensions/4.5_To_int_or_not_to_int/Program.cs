using System;

namespace _4._5_To_int_or_not_to_int
{
    public static class Array
    {
        public static bool IsCheckPositiveInt(this string str)
        {
            if (str == null)
                return false;
            if(str.Length==0)
                return false;
            int index = 0;
            int countzero = 0;
            if (str[0] == '-')
            {
                return false;
            }
            if (str[0] == '+')
            {
                index++;
            }
            for (int i = index; i < str.Length; i++)
            {
                if (!Char.IsDigit(str[i]))
                    return false;
                else if (str[i] == '0')
                    countzero ++;
            }
            if(countzero==str.Length||countzero>str.Length-1-index)
                return false;
            return true;
        }
    }
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter string:");
            string str = Console.ReadLine();
            if(str.IsCheckPositiveInt())
                Console.WriteLine("String is postitive integer number");
            else
                Console.WriteLine("String is not postitive integer number");
        }
    }
}
