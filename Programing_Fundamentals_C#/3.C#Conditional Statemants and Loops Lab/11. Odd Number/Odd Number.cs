

using System.Text;

namespace OddNumber
{
    using System;

    public class Program
    {
        public static void Main()
        {
            StringBuilder output = new StringBuilder();
            while (true)
            {
                int number = int.Parse(Console.ReadLine());
                if ((number & 1) == 0)
                {
                    output.Append("Please write an odd number.\n");
                }
                else
                {
                    output.AppendFormat($"The number is: {Math.Abs(number)}\n");
                    break;
                }
            }

            Console.Write(output);
        }
    }
}
