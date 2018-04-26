
namespace CakeIngredients
{
    using System;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            string input = string.Empty;

            int numberOfIngredients = 0;
            StringBuilder output = new StringBuilder();
            while (!(input = Console.ReadLine()).Equals("Bake!"))
            {
                output.AppendFormat($"Adding ingredient {input}.\n");
                numberOfIngredients++;
            }

            Console.Write(output);
            Console.WriteLine($"Preparing cake with {numberOfIngredients} ingredients.");
        }
    }
}
