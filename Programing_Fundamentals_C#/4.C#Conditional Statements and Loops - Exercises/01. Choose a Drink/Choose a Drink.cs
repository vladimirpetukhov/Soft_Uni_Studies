﻿

namespace ChooseADrink
{
    using System;
    public class Program
    {
        public static void Main()
        {
            // “Water” – for “Athlete”
            // “Coffee” – for “Businessman” or “Businesswoman”
            // “Beer” – for “SoftUni Student”
            // “Tea” – for all other professions.

            string profession = Console.ReadLine();

            string drink = string.Empty;
            switch (profession)
            {
                case "Athlete":
                    drink = "Water";
                    break;
                case "Businessman":
                case "Businesswoman":
                    drink = "Coffee";
                    break;
                case "SoftUni Student":
                    drink = "Beer";
                    break;
                default:
                    drink = "Tea";
                    break;
            };

            Console.WriteLine(drink);
        }
    }
}
