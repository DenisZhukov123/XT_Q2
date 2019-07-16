using System;

namespace Task2._5_Employee
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

        public class Employee : User
        {
            private string position;
            private DateTime timebeginwork;
            public string Position
            {
                get { return position; }
                set
                {
                    position = value;
                }
            }
            public DateTime Timebeginwork
            {
                set { timebeginwork = value; }
            }
            public Int32[] Experience
            {
                get
                {
                    Int32[] result = new Int32[3] { 0, 0, 0 };
                    DateTime now = DateTime.Now;
                    DateTime temp1=now;
                    DateTime temp2=timebeginwork;
                    if (temp1 < temp2)
                    {
                        DateTime temp3 = timebeginwork;
                        temp2 = now;
                        temp1 = temp3;
                    }
                    result[1] = 12 * (temp1.Year - temp2.Year) + (temp1.Month - temp2.Month);
                    if (temp1.Day < temp2.Day)
                    {
                        result[1]--;
                        result[2] = DateTime.DaysInMonth(temp2.Year, temp2.Month) - temp2.Day + temp1.Day;
                    }
                    else
                    {
                        result[2] = temp1.Day - temp2.Day;
                    }
                    result[0] = result[1] / 12;
                    result[1] -= result[0] * 12;
                    return result;
                }
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
            else if (exc == 2)
                return true;
            return true;
        }
        static public object Input(int exc)//добавить обработку пустого отчества и корректности даты
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
                else if (exc == 3)
                {
                    DateTime value;
                    if (DateTime.TryParse(Console.ReadLine(), out value) == true)
                    {
                        if (value > DateTime.Now)
                            Console.WriteLine("Данные неверны! Повторите ввод:");
                        else return value;
                    }
                    else Console.WriteLine("Данные неверны! Повторите ввод:");
                }
            }
            //return false;
        }

        static public void Output(int value, int flag)//добавить обработку пустого отчества и корректности даты
        {
            switch (flag)
            {
                case 1:
                    {
                        if (value == 0)
                            break;
                        else if (value >= 10 && value <= 20)
                            Console.WriteLine("{0} лет", value);
                        else if (value % 10 == 1)
                            Console.WriteLine("{0} год", value);
                        else if (value % 10 == 2 || value % 10 == 3 || value % 10 == 4)
                            Console.WriteLine("{0} года", value);
                        else Console.WriteLine("{0} лет", value);
                        break;
                    }
                case 2:
                    {
                        if (value == 0)
                            break;
                        else if (value == 1)
                            Console.WriteLine("{0} месяц", value);
                        else if (value>=2&&value<=4)
                            Console.WriteLine("{0} месяца", value);
                        else
                            Console.WriteLine("{0} месяцев", value);
                        break;
                    }
                case 3:
                    {
                        if (value == 0)
                            break;
                        else if (value >= 10 && value <= 20)
                            Console.WriteLine("{0} дней", value);
                        else if (value % 10 == 1)
                            Console.WriteLine("{0} день", value);
                        else if (value % 10 == 2 || value % 10 == 3 || value % 10 == 4)
                            Console.WriteLine("{0} дня", value);
                        else Console.WriteLine("{0} дней", value);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ошибка!");
                        break;
                    }
            }
        }
        static void Main()
        {
            Employee e = new Employee();
            Console.WriteLine("Введите имя:");
            e.GetName = (string)Input(1);
            Console.WriteLine("Введите отчество:");
            e.GetPatronymic = (string)Input(2);
            Console.WriteLine("Введите фамилию:");
            e.GetSurname = (string)Input(1);
            Console.WriteLine("Введите дату рождения в формате DD.MM.YY:");
            e.GetBirthday = (DateTime)Input(3);
            Console.WriteLine("Введите должность:");
            e.Position = Console.ReadLine();
            Console.WriteLine("Введите дату приема на работу DD.MM.YY:");
            e.Timebeginwork = (DateTime)Input(3);
            Console.WriteLine("Работник {0} {1} {2}", e.GetName, e.GetPatronymic, e.GetSurname);
            Console.WriteLine("Возраст:");
            Output(e.Age(), 1);
            Console.WriteLine("Стаж:");
            if (e.Experience[0] == 0 && e.Experience[1] == 0 && e.Experience[2] == 0)
                Console.WriteLine("0 дней");
            else
            {
                Output(e.Experience[0], 1);
                Output(e.Experience[1], 2);
                Output(e.Experience[2], 3);
            }
        }
    }
}
