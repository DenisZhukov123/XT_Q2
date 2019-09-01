using System;
using System.Text.RegularExpressions;

namespace _7._3_EMAIL_Finder
{
    class Program
    {
        public static void SearchEmail(string str)
        {
            string pattern = @"\b[A-Za-z0-9]+[A-Za-z0-9\._-]*[A-Za-z0-9]+@([A-Za-z0-9]+[A-Za-z0-9-]*[A-Za-z0-9]+\.)+[A-Za-z]{2,6}\b";
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                    Console.WriteLine(match.Value);
            }
            else
            {
                Console.WriteLine("E-mail entry don't find");
            }
        }
        public static void Main()
        {
            Console.WriteLine("Please enter text for find e-mail entry:");
            SearchEmail(Console.ReadLine());
        }
    }
}
