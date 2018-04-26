


namespace RectangleArea
{
    using System;

   public class Program
    {
        public static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double rectangleArea = width * height;
            Console.WriteLine($"{rectangleArea:F2}");
        }
    }
}
