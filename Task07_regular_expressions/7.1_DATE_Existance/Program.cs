using System;
using System.Text.RegularExpressions;

namespace Task07_Date_existance
{
    public class Program
    {
        public static bool CheckStringDate(string str)
        {
            Regex regex = new Regex(@"([0-2][0-9]|[3][0-1])-(0[1-9]|1[0-2])-\d{4}");
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
                return true;
            return false;
        }
        public static void Main()
        {
            Console.WriteLine("Please enter string with data infotmation in format (dd-mm-yyyy):");
            string s = Console.ReadLine();
            if (CheckStringDate(s))
                Console.WriteLine("In string: \"" + s + "\" " + "is found date");
            else
                Console.WriteLine("In string : \"" + s + "\" " + "don't found date");
        }
    }
}
