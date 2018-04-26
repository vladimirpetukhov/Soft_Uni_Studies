

namespace IntervalOfNumbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());

            int min = Math.Min(number1, number2);
            int max = Math.Max(number1, number2);

            for (int i = min; i <= max; i++)
            {
                Console.WriteLine($"{i}");
            }
        }
    }
}
