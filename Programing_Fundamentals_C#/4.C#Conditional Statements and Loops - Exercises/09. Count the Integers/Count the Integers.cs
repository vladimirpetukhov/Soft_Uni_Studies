

namespace CountTheIntegers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int countNumbers = 0;
            while (true)
            {
                string input = Console.ReadLine();

                bool isNumeric = int.TryParse(input, out int n);
                if (!isNumeric)
                    break;

                countNumbers++;
            }

            Console.WriteLine($"{countNumbers}");
        }
    }
}
