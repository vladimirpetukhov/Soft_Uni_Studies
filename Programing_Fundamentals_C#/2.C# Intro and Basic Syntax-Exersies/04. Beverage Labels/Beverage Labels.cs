


namespace _04.Beverage_Labels
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energyContent = int.Parse(Console.ReadLine());
            int sugarContent = int.Parse(Console.ReadLine());

            double energy = (volume / 100.00) * energyContent;
            double sugar = (volume / 100.00) * sugarContent;

            string output = string.Format($"{volume}ml {name}:\n{energy}kcal, {sugar}g sugars");
            Console.WriteLine(output);
        }
    }
}
