


namespace SumOfOddNumbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int startNumber = 1;
            int sum = 0;
            while (n > 0)
            {
                if ((startNumber % 2) != 0)
                {
                    sum += startNumber;
                    Console.WriteLine(startNumber);
                    n--;
                }

                startNumber++;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}

