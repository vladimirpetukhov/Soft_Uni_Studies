using System;

namespace _04.Froggy
{
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var stones = Console.ReadLine()
                .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var lake = new Lake(stones);

            Console.Write(string.Join(", ", lake));
        }
    }
}
