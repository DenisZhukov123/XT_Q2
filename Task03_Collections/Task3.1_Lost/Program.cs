using System;
using System.Collections.Generic;

namespace Task3._1_Lost
{
    public class Program
    {
        public static Queue<int> InputAndCreateCircle()
        {
            Queue<int> Circle = new Queue<int>();
            Console.WriteLine("Enter the number of people:");
            int N;
            while (true)
            {
                if (!Int32.TryParse(Console.ReadLine(), out N))
                    Console.WriteLine("Error! Try again:");
                else if(N>0)
                    break;
                else Console.WriteLine("The number of people must be greater than 0");
            }
            for (int i = 0; i < N; i++)
                Circle.Enqueue(i + 1);
            return Circle;
        }

        public static bool OneStepCircle(Queue<int> circle)
        {
            if (circle.Count != 1)
            {
                circle.Enqueue(circle.Dequeue());
                circle.Dequeue();
                return true;
            }
            return false;
        }
        public static void PrintCircle(Queue<int> circle)
        {
            int[] arr = circle.ToArray();
            Console.WriteLine("Remaining people after one step");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("{0} ", arr[i]);
            }
            Console.WriteLine("");
        }

        public static void Main()
        {
            Queue<int> CirclePeople;
            CirclePeople = InputAndCreateCircle();
            while (OneStepCircle(CirclePeople))
                PrintCircle(CirclePeople);
            Console.WriteLine("The winner has number: {0}", CirclePeople.Peek());
        }
    }
}
