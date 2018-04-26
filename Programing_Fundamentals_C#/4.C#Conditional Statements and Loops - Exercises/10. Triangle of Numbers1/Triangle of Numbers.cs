

namespace TriangleOfNumbers
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                StringBuilder output = new StringBuilder();
                for (int p = 1; p <= i; p++)
                {
                    output.AppendFormat($"{i} ");
                }
                Console.WriteLine(output);
            }
        }
    }
}
