using System;

namespace Task2._6_Ring
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
                get { return x; }
                set
                {

                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        x = value;
                }
            }
            public Int32 Y
            {
                get { return y; }
                set
                {
                    if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                    else
                        y = value;
                }
            }
            public double Radius
            {
                get { return radius; }
                set
                {
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
        class Ring
        {
            private Round InRound;
            private Round OutRound;

            public Ring(int x, int y, double inround, double outround)
            {
                if(inround>=outround)
                    throw new ArgumentException("Радиус внутреннего круга больше или равен радиусу внешнего!");
                InRound = new Round();
                InRound.X = x;
                InRound.Y = y;
                InRound.Radius = inround;
                OutRound = new Round();
                OutRound.X = x;
                OutRound.Y = y;
                OutRound.Radius = outround;
            }
            public int X
            {
                get { return InRound.X; }
            }
            public int Y
            {
                get { return InRound.Y; }
            }
            public double GetArea()
            {
                return OutRound.GetArea - InRound.GetArea;
            }
            public double SumLength()
            {
                return InRound.GetLength + OutRound.GetLength;
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
            Ring r;
            Console.WriteLine("Введите значение координаты X:");
            int x = Input();
            Console.WriteLine("Введите значение координаты Y:");
            int y = Input();
            while (true)
            {
                Console.WriteLine("Введите радиус внутреннего круга:");
                int InR = Input();
                Console.WriteLine("Введите радиус внешнего круга:");
                int OutR = Input();
                try
                {
                    r = new Ring(x, y, InR, OutR);
                    break;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Введены некорректные данные! Повторите ввод");
                    continue;
                }
            }
            Console.WriteLine("Для кольца с координатами: {0}:{1}", r.X, r.Y);
            Console.WriteLine("Площадь кольца равна: {0}", r.GetArea());
            Console.WriteLine("Суммарная длина окружностей кольца равна: {0}", r.SumLength());
        }
    }
}
