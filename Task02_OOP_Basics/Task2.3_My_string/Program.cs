using System;

namespace Task2._4_My_string
{
    class Program
    {
        class MyString
        {
            char[] mystr;
            public MyString()
            {
                mystr = new char[0];
            }

            public MyString(char[] str)
            {
                mystr = str;
            }

            public MyString(string str)
            {
                mystr = str.ToCharArray();
            }

            public char this[int index]
            {
                get => mystr[index];
                set => mystr[index] = value;
            }
            public int Length
            {
                get { return mystr.Length; }
            }
            public static bool operator ==(MyString a, MyString b)
            {
                if (a.Length != b.Length)
                    return false;
                else
                {
                    for (int i = 0; i < a.Length; i++)
                        if (a[i] != b[i])
                            return false;
                }
                return true;
            }
            public static bool operator !=(MyString a, MyString b)
            {
                if (a.Length != b.Length)
                    return true;
                else
                {
                    for (int i = 0; i < a.Length; i++)
                        if (a[i] != b[i])
                            return true;
                }
                return false;
            }
            public override int GetHashCode()
            {
                return 0;
            }
            public override bool Equals(Object obj)
            {
                return obj is MyString && this == (MyString)obj;
            }
            public static MyString operator +(MyString a, MyString b)
            {
                int NewStrLength = a.Length + b.Length;
                int k = 0;
                MyString temp = new MyString
                {
                    mystr = new char[NewStrLength]
                };
                for (int i = 0; i<a.Length; i++)
                    temp[i] = a[i];
                for (int j = a.Length; j < NewStrLength; j++)
                {
                    temp[j] = b[k];
                    k++;
                }
                return temp;
            }
            public bool Find(char c)
            {
                for (int i = 0; i < mystr.Length; i++)
                {
                    if (mystr[i] == c)
                        return true;
                }
                return false;
            }
            public char[] ToCharArray()
            {
                return mystr;
            }
            public override string ToString()
            {
                return new string(mystr);
            }

            public static MyString ToString(char[] array)
            {
                return new MyString(array);
            }
        }
        static void Main()
        {
            MyString str1;
            MyString str2;
            Console.WriteLine("Введите первую строку:");
            str1 = new MyString(Console.ReadLine());
            Console.WriteLine("Введите вторую строку:");
            str2 = new MyString(Console.ReadLine());
            Console.WriteLine("Количество символов в первой строке: {0}", str1.Length);
            Console.WriteLine("Количество символов во второй строке: {0}", str2.Length);
            Console.WriteLine("Сравнение строк:");
            if(str1==str2)
                Console.WriteLine("Строки совпадают");
            if(str1!=str2)
                Console.WriteLine("Строки не совпадают");
            Console.WriteLine("Конкатенация строк: {0}", str1+str2);
            Console.WriteLine("Введите символ чтобы узнать есть ли он во введенных строках:");
            char a;
            while (true)
            {
                if (char.TryParse(Console.ReadLine(), out a))
                    break;
                else
                    Console.WriteLine("Ошибка! Повторите ввод символа: ");
            }
            if(str1.Find(a)==true)
                Console.WriteLine("Символ {0} присутствует в первой строке", a);
            else
                Console.WriteLine("Символ {0} отсутствует в первой строке", a);
            if (str2.Find(a) == true)
                Console.WriteLine("Символ {0} присутствует во второй строке", a);
            else
                Console.WriteLine("Символ {0} отсутствует во второй строке", a);
        }
    }
}
