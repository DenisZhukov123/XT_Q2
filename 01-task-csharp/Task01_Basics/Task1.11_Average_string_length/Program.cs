using System;

namespace Task1._11_Average_string_length
{
    class Program
    {
        public static double Calculate(string str)
        {
            double sum_word = 0;
            int sum_chr = 0;
            bool find_word = false;
            for (int i = 0; i < str.Length; i++)
            {
                if (!Char.IsSeparator(str[i]) && !Char.IsPunctuation(str[i]) && !Char.IsDigit(str[i]))
                {
                    if (find_word == false)
                    {
                        sum_word++;
                        find_word = true;
                    }
                    sum_chr++;
                }
                else if (find_word == true)
                    find_word = false;
            }
            if (sum_word != 0)
                return sum_chr / sum_word;
            return 0;
        }
        static void Main()
        {
            Console.WriteLine("Введите строку");
            string str = Console.ReadLine();
            Console.WriteLine("Средняя длина слова в строке: {0}", Calculate(str));
            Console.ReadKey();
        }
    }
}
