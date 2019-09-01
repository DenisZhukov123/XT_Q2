using System;
using System.Text.RegularExpressions;

namespace _7._2_HTML_Replacer
{
    public class Program
    {
        public static string ReplaceTeg(string str)
        {
            string pattern = @"(\<(/?[^>]+)>)";
            string target = "_";
            Regex regex = new Regex(pattern);
            return regex.Replace(str, target);
        }
        public static void Main()
        {
            Console.WriteLine("Please enter text for replace tags on '_':");
            string s = Console.ReadLine();
            Console.WriteLine("Text with replace tags:");
            Console.WriteLine(ReplaceTeg(s));
        }
    }
}
