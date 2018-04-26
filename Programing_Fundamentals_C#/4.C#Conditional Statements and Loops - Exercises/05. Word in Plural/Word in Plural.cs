
namespace WordInPlural
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string word = Console.ReadLine();

            if (word.EndsWith("y"))
            {
                word = word.Substring(0, word.Length - 1) + "ies";
            }
            else if (word.EndsWith("o") || word.EndsWith("s") || word.EndsWith("x") || word.EndsWith("z") ||
                     word.EndsWith("ch") || word.EndsWith("sh"))
            {
                word += "es";
            }
            else
            {
                word += "s";
            }

            Console.WriteLine(word);
        }
    }
}
