using System;

namespace Task1._1_Rectangle
{
    class Program
    {
        public static int InputAndCheck(char name_side)
        {
            bool repeat = false;
            int temp_side = 0;
            while (repeat == false || temp_side <= 0)
            {

                Console.WriteLine("Введите значение стороны {0}: ", name_side);
                repeat = int.TryParse(Console.ReadLine(), out temp_side);
                if (repeat == false || temp_side <= 0)
                    Console.WriteLine("Введенные данные некорректны, повторите ввод");
                else break;
            }
            return temp_side;
        }

        public static int CalculateSquare(int a, int b) => a * b;

        public static void Main()
        {
            int a = InputAndCheck('a');
            int b = InputAndCheck('b');
            Console.WriteLine("Площадь прямоугольника равна: {0}", CalculateSquare(a, b));
            Console.ReadKey();
        }
    }
}
