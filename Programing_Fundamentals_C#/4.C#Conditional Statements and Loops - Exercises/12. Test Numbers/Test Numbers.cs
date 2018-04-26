

namespace TestNumbers
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // First line – N – integer in the interval [1…100]
            // Second line – M – integer in the interval[1…100]
            // Third line – maximum sum boundary – integer in the interval[1…1000000]

            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxBoundary = int.Parse(Console.ReadLine());

            int sum = 0;
            int combinations = 0;
            for (int i = n; i >= 1; i--)
            {
                for (int p = 1; p <= m; p++)
                {
                    combinations++;

                    int calculation = i * p;
                    sum += calculation * 3;

                    if (sum >= maxBoundary)
                        break;
                }

                if (sum >= maxBoundary)
                    break;
            }

            if (sum >= maxBoundary)
            {
                Console.WriteLine($"{combinations} combinations");
                Console.WriteLine($"Sum: {sum} >= {maxBoundary}");
            }
            else
            {
                Console.WriteLine($"{combinations} combinations");
                Console.WriteLine($"Sum: {sum}");
            }
        }
    }
}
