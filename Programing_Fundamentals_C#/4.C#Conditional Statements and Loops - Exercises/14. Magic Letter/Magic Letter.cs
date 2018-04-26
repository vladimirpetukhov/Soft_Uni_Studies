

namespace MagicLetter
{
    using System;

    public class Program
    {
        public static void Main()
        {
            // First line – lower case English letter from ‘a’ to ‘z’
            // Second line – lower case English letter from ‘a’ to ‘z’
            // Third line – lower case English letter from ‘a’ to ‘z’ – combinations, containing this letter should not be printed

            char ch1 = char.Parse(Console.ReadLine());
            char ch2 = char.Parse(Console.ReadLine());
            char ch3 = char.Parse(Console.ReadLine());

            for (char d1 = ch1; d1 <= ch2; d1++)
            for (char d2 = ch1; d2 <= ch2; d2++)
            for (char d3 = ch1; d3 <= ch2; d3++)
            {
                if (d1 == ch3 || d2 == ch3 || d3 == ch3)
                    continue;

                Console.Write($"{d1}{d2}{d3} ");
            }

            Console.WriteLine();
        }
    }
}
