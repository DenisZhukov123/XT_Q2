using System;

namespace Task2._2_Triangle
{
    class Program
    {
        public class Triangle
        {
            private double a;
            private double b;
            private double c;
            public Triangle(double a, double b, double c)
            {
                A = a;
                B = b;
                C = c;
            }
            public double A
            {
                get { return a; }
                set
                {
                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        a = value;
                }
            }
            public double B
            {
                get { return b; }
                set
                {
                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        b = value;
                }
            }
            public double C
            {
                get { return c; }
                set
                {
                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        c = value;
                }
            }
            public double Area()
            {
                double p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A)*(p - B)*(p - C));
            }
            public double Perimetr()
            {
                return A+B+C;
            }

        }
        static public double Input()
        {
            double input;
            while (true)
            {
                try
                {
                    input = double.Parse(Console.ReadLine());
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
        static public bool CheckTriangle(double a, double b, double c)
        {
            if (a < b + c && b < a + c & c < a + b)
            {
                Console.WriteLine("Существование такого треугольника возможно!");
                return true;
            }
            else
            {
                Console.WriteLine("Существование такого треугольника невозможно!");
                return false;
            }
        }
        static void Main()
        {
            double a, b, c;
            Triangle t;
            do
            {
                Console.WriteLine("Введите значение стороны A:");
                a = Input();
                Console.WriteLine("Введите значение стороны B:");
                b = Input();
                Console.WriteLine("Введите значение стороны C:");
                c = Input();
            }
            while (CheckTriangle(a, b, c) == false);
            t = new Triangle(a, b, c);
            Console.WriteLine("Для треугольника со сторонами: A = {0}, B = {1}, C = {2}", t.A, t.B, t.C);
            Console.WriteLine("Площадь равна: {0}", t.Area());
            Console.WriteLine("Периметр равен: {0}", t.Perimetr());

        }
    }
}
