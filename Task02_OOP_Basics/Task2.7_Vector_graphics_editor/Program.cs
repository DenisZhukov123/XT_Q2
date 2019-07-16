using System;

namespace Task2._7_Vector_graphics_editor
{
    class Program
    {
        public static int Menu()
        {
            Console.WriteLine("Введите номер фигуры, которую необходимо создать:");
            Console.WriteLine("1: Линия");
            Console.WriteLine("2: Окружность");
            Console.WriteLine("3: Прямоугольник");
            Console.WriteLine("4: Круг");
            Console.WriteLine("5: Кольцо");
            Int32 choise;
            while (true)
            {
                if (Int32.TryParse(Console.ReadLine(), out choise) == true)
                    return choise;
                else Console.WriteLine("Ошибка! Повторите ввод!");
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
        public static void Main()
        {
            while(true)
            {
                Console.Clear();
                switch (Menu())
                {
                    case 1:
                        {
                            Line l = new Line();
                            Console.WriteLine("Введите координату начальной точки X");
                            l.x = Input();
                            Console.WriteLine("Введите координату начальной точки Y");
                            l.y = Input();
                            Console.WriteLine("Введите координату конечной точки X");
                            l.x1 = Input();
                            Console.WriteLine("Введите координату конечной точки Y");
                            l.y1 = Input();
                            l.Draw();
                            break;
                        }
                    case 2:
                        {
                            Circle c = new Circle();
                            Console.WriteLine("Введите координату точки X");
                            c.x = Input();
                            Console.WriteLine("Введите координату точки Y");
                            c.y = Input();
                            Console.WriteLine("Введите радиус");
                            while (true)
                            {
                                try
                                {
                                    c.radius = (double)Input();
                                    break;
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Введены некорректные данные! Повторите ввод");
                                    continue;
                                }
                            }
                            c.Draw();
                            break;
                        }
                    case 3:
                        {
                            Rectangle r = new Rectangle();
                            Console.WriteLine("Введите координату точки X");
                            r.x = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату точки Y");
                            r.y = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Введите сторону a");
                            while (true)
                            {
                                try
                                {
                                    r.a = (double)Input();
                                    break;
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Введены некорректные данные! Повторите ввод");
                                    continue;
                                }
                            }
                            Console.WriteLine("Введите сторону b");
                            while (true)
                            {
                                try
                                {
                                    r.b = (double)Input();
                                    break;
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Введены некорректные данные! Повторите ввод");
                                    continue;
                                }
                            }
                            r.Draw();
                            break;
                        }
                    case 4:
                        {
                            Round r = new Round();
                            Console.WriteLine("Введите координату точки X");
                            r.x = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату точки Y");
                            r.y = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Введите радиус");
                            while (true)
                            {
                                try
                                {
                                    r.radius = (double)Input();
                                    break;
                                }
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Введены некорректные данные! Повторите ввод");
                                    continue;
                                }
                            }
                            r.Draw();
                            break;
                        }
                    case 5:
                        {
                            Ring r;
                            Console.WriteLine("Введите координату точки X");
                            int x = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Введите координату точки Y");
                            int y = Int32.Parse(Console.ReadLine());
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
                                catch (ArgumentException)
                                {
                                    Console.WriteLine("Введены некорректные данные! Повторите ввод");
                                    continue;
                                }
                            }
                            r.Draw();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Ошибка ввода!");
                            break;
                        }
                }
                Console.WriteLine("Введите 2 чтобы выйти или любой ввод, чтобы продолжить");
                Int32 repeat;
                if (Int32.TryParse(Console.ReadLine(), out repeat))
                {
                    if (repeat == 2)
                        break;
                }
            }
            
        }
    }
    abstract class Figure
    {
        protected Int32 _x;
        protected Int32 _y;
        public Int32 x
        {
            get { return _x; }
            set { _x = value; }
        }
        public Int32 y
        {
            get { return _y; }
            set { _y = value; }
        }
        public Figure()
        {
            _x = 0;
            _y = 0;
        }
        public Figure(int a, int b)
        {
            _x = a;
            _y = b;
        }
        public virtual void Draw()
        {
        }
    }
    class Line : Figure
    {
        private Int32 _x1;
        private Int32 _y1;
        public Int32 x1
        {
            get { return _x1; }
            set { _x1 = value; }
        }
        public Int32 y1
        {
            get { return _y1; }
            set { _y1 = value; }
        }
        public Line()
        {
            _x = 0;
            _y = 0;
            _x1 = 0;
            _y1 = 0;
        }
        public Line(int a, int b, int c, int d)
        {
            _x = a;
            _y = b;
            _x1 = c;
            _y1 = d;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow((_x1 - _x), 2) + Math.Pow((_y1 - _y), 2));
        }
        public override void Draw()
        {
            Console.WriteLine("Линия с началом в точке ({0},{1}) и концом в точке ({2},{3})", _x, _y, _x1, _y1);
            Console.WriteLine("Имеет длину {0}", Length());
        }
    }
    class Circle : Figure
    {
        protected double _radius;
        public Circle()
        {
            _x = 0;
            _y = 0;
            _radius = 0;
        }
        public double radius
        {
            set {if (value < 0){throw new ArgumentException("Введены неверные данные!");}
                else
                    _radius = value;
            }
            get { return _radius; }
        }

        public double Length()
        {
            return 2 * Math.PI * _radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Окружность c координатами ({0},{1}) имеет длину окружности {2}", x, y, Length());
        }
    }
    class Round : Circle
    {
        public double Area()
        {
            return Math.PI * radius * radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Круг c координатами ({0},{1})", x, y);
            Console.WriteLine("Имеет длину окружности {0} и площадь {1}", Length(), Area());
        }

    }
    class Ring : Figure
    {
        private Round InRound;
        private Round OutRound;
        public Ring(int x, int y, double inround, double outround)
        {
            if (inround >= outround)
                throw new ArgumentException("Радиус внутреннего круга больше или равен радиусу внешнего!");
            InRound = new Round();
            InRound.x = x;
            InRound.y = y;
            InRound.radius = inround;
            OutRound = new Round();
            OutRound.x = x;
            OutRound.y = y;
            OutRound.radius = outround;
        }
        public double Area()
        {
            return OutRound.Area() - InRound.Area();
        }
        public double InLength()
        {
            return 2 * Math.PI * InRound.radius;
        }
        public double OutLength()
        {
            return 2 * Math.PI * OutRound.radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Кольцо c координатами ({0},{1})", x, y);
            Console.WriteLine("имеет длину окружности внутреннего круга {0} и внешнего круга {1}", InLength(), OutLength());
            Console.WriteLine("Площадь {0}",Area());
        }
    }
    class Rectangle : Figure
    {
        private double _a;
        private double _b;
        public Rectangle()
        {
            _x = 0;
            _y = 0;
            _a = 0;
            _b = 0;
        }
        public Rectangle(int x1, int y1, int a1, int b1)
        {
            _x = x1;
            _y = y1;
            _a = a1;
            _b = b1;
        }
        public double a
        {
            get { return _a; }
            set {if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                else
                    _a = value;
            }
        }
        public double b
        {
            get { return _b; }
            set {
                if (value <= 0) { throw new ArgumentException("Введены неверные данные!"); }
                else
                    _b = value;
            }
        }
        public double Perimetr()
        {
            return 2 * (_a + _b);
        }
        public double Area()
        {
            return _a * _b;
        }
        public override void Draw()
        {
            Console.WriteLine("Прямоугольник c координатами ({0},{1})", x, y);
            Console.WriteLine("имеет периметр {0} и площадь {1}", Perimetr(), Area());
        }
    }
}
