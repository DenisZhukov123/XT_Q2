using System;

namespace _4._4_Number_array_sum
{
    public static class NumberArraySum
    {
        public static T SumMass<T>(this T[] param)
        {
            if (param == null)
                throw new ArgumentNullException();
            double sum = 0;
            for (int i = 0; i < param.Length; i++)
                sum += Convert.ToDouble(param[i]);
            return (T)Convert.ChangeType(sum, typeof(T));
        }
    }
    public class Program
    {
        public static void Main()
        {
            int[] testmass1 = new int[] { 1, 4, 5, 3, 5, 3, 7 };
            Console.WriteLine("Summ = {0}", testmass1.SumMass());

            float[] testmass2 = new float[] { 1.2f, 4f, 5.1f, 3.7f, 5f, 3f, 7f };
            Console.WriteLine("Summ = {0}", testmass2.SumMass());

            double[] testmass3 = new double[] { 1.2, 4, 3.5, 8.5, 5.4, 3, 7 };
            Console.WriteLine("Summ = {0}", testmass3.SumMass());

            decimal[] testmass4 = new decimal[] { 1.2m, 2.1m, 3.3m, 4m, 5m, 6m, 7m, 8m, 9m, 10m};
            Console.WriteLine("Summ = {0}", testmass4.SumMass());
        }
    }
}
