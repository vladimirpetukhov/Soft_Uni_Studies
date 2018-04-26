
namespace ChooseADrink2._0
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string profession = Console.ReadLine();
            int quantities = int.Parse(Console.ReadLine());

            string drink = string.Empty;
            decimal price = 0.00m;
            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    price = 0.70m;
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    price = 1.00m;
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    price = 1.70m;
                    break;
                default:
                    drink = "Tea";
                    price = 1.20m;
                    break;
            };

            Console.WriteLine($"The {profession} has to pay {quantities * price}.");
        }
    }
}
