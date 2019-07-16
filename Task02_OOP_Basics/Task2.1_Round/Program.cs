using System;

namespace Task2._1_Round
{
    class Program
    {
        public class Round
        {
            private Int32 x;
            private Int32 y;
            private double radius;
            public Int32 X
            {
                get {return x;}
                set {

                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        x = value;
  
                }
            }
            public Int32 Y
            {
                get {return y;}
                set {
                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        y = value;
                }
            }
            public double Radius
            {
                get { return radius; }
                set {
                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        radius = value;
                }
            }
            public double GetArea
            {
                get { return Math.PI * radius * radius; }
            }
            public double GetLength
            {
                get { return 2 * Math.PI * radius; }
            }

        }
        static public int Input()
        {
            int input;
            while (true)
            {
                try
                {
                    input = Int32.Parse(Console.ReadLine());
                    if (input < 0)
                    {
                        Console.WriteLine("Введенные данные некорректны! Повторите ввод:");
                        continue;
                    }
                    else return input;
                }
                catch
                {
                    Console.WriteLine("Введенные данные некорректны! Повторите ввод:");
                    continue;
                }
            }

        }
        static void Main()
        {
            Round r = new Round();
            Console.WriteLine("Введите значение координаты X:");
            r.X = Input();
            Console.WriteLine("Введите значение координаты Y:");
            r.Y = Input();
            Console.WriteLine("Введите значение радиуса:");
            r.Radius = Input();
            Console.WriteLine("Для круга с координатами: {0}:{1}", r.X,r.Y);
            Console.WriteLine("Площадь круга равна: {0}", r.GetArea);
            Console.WriteLine("Длина окружности равна равна: {0}", r.GetLength);

        }
    }
}
