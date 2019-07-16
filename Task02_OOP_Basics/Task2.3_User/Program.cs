using System;

namespace Task2._3_User
{
    class Program
    {
        public class User
        {
            private string name;
            private string surname;
            private string patronymic;
            private DateTime birthday;
            public string GetName
            {
                get { return name; }
                set
                {
                    name = value;
                }
            }
            public string GetSurname
            {
                get { return surname; }
                set
                {
                    surname = value;
                }
            }
            public string GetPatronymic
            {
                get { return patronymic; }
                set
                {
                    patronymic = value;
                }
            }

            public DateTime GetBirthday
            {
                get { return birthday; }
                set
                {
                    birthday = value;
                }
            }
            public Int32 Age()
            {
                int age;
                DateTime now = DateTime.Now;
                age = now.Year - birthday.Year; 
                if (now.Month < birthday.Month || 
                   (now.Month == birthday.Month && 
                    now.Day < birthday.Day))
                    age--;
                return age;
            }
        }
        static bool CheckStr(string str, int exc)
        {
            if (str.Length > 0)
            {
                foreach (char ch in str)
                {
                    if (Char.IsDigit(ch) || Char.IsPunctuation(ch) || Char.IsSeparator(ch) || Char.IsSurrogate(ch))
                        return false;
                }
            }
            else if(exc==2)
                return true;
            return true;
        }
        static public object Input(int exc)
        {
            string str;
            while (true)
            {
                if (exc < 3)
                {
                    str = Console.ReadLine();
                    if (CheckStr(str, exc) == true)
                        return str;
                    else Console.WriteLine("Данные неверны! Повторите ввод:");
                }
                else
                {
                    DateTime value;
                    if (DateTime.TryParse(Console.ReadLine(), out value) == true)
                    {
                        if(value>DateTime.Now)
                            Console.WriteLine("Данные неверны! Повторите ввод:");
                        else return value;

                    }
                    else Console.WriteLine("Данные неверны! Повторите ввод:");
                }
            }
        }
        static void Main()
        {
            User u = new User();
            Console.WriteLine("Введите имя:");
            u.GetName = (string)Input(1);
            Console.WriteLine("Введите отчество:");
            u.GetPatronymic = (string)Input(2);
            Console.WriteLine("Введите фамилию:");
            u.GetSurname = (string)Input(1);
            Console.WriteLine("Введите дату рождения в формате DD.MM.YY:");
            u.GetBirthday=(DateTime)Input(3);
            Console.WriteLine("Возраст {0} {1} {2} равен: {3}",u.GetName, u.GetPatronymic, u.GetSurname, u.Age());
        }
    }
}
