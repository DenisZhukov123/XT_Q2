using System;
using System.Collections.Generic;

namespace Task3._2_word_frequency
{
    public class Program
    {
        public static void Main()
        {
            char[] delimiterChars = { ' ', '.'};
            Console.WriteLine("Enter string:");
            string text = Console.ReadLine();
            string[] word_mass = text.ToUpper().Split(delimiterChars,StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> DictBase = new Dictionary<string, int>();
            foreach (string word in word_mass)
            {
                if (!(DictBase.ContainsKey(word)))
                    DictBase.Add(word, 1);
                else
                    DictBase[word]++;
            }
            foreach (var word in DictBase)
                Console.WriteLine("The word {0} occurs in the text {1} times", word.Key, word.Value);
        }
    }
}
