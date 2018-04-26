

namespace NumberChecker
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            int number;
            bool isNumeric = int.TryParse(input, out number);

            if (isNumeric)
            {
                Console.WriteLine("It is a number.");
            }
            else
            {
                Console.WriteLine("Invalid input!");
            }
        }
    }
}
