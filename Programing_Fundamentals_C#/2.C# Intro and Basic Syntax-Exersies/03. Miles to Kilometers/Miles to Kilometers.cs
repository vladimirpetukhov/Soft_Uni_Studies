


namespace _03.Miles_to_Kilometers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            double miles = double.Parse(Console.ReadLine());

            double kilometers = miles * 1.60934;
            Console.WriteLine($"{kilometers:F2}");
        }
    }
}
