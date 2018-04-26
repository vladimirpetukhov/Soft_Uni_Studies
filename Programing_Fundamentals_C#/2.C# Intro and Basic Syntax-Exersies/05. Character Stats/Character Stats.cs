


namespace _05.Character_Stats
{
    using System;

    public class Program
    {
        public static void Main()
        {
            string name = Console.ReadLine();
            int currentHealth = int.Parse(Console.ReadLine());
            int maximumHealth = int.Parse(Console.ReadLine());
            int currentEnergy = int.Parse(Console.ReadLine());
            int maximumEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Health: {new string('|', currentHealth + 1)}{new string('.', maximumHealth - currentHealth)}|");
            Console.WriteLine($"Energy: {new string('|', currentEnergy + 1)}{new string('.', maximumEnergy - currentEnergy)}|");
        }
    }
}
