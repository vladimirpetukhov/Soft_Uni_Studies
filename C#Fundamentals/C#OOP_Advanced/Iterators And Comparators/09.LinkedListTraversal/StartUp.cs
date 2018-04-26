namespace _09.LinkedListTraversal
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var linkedList = new LinkedList<int>();

            int numberOfLinesToRead = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfLinesToRead; i++)
            {
                var tokens = Console.ReadLine()
                    .Split()
                    .ToList();
                var command = tokens[0];
                var element = int.Parse(tokens[1]);

                switch (command)
                {
                    case "Add":
                        linkedList.Add(element);
                        break;
                    case "Remove":
                        linkedList.Remove(element);
                        break;
                }
            }

            Console.WriteLine(linkedList.Count);
            Console.WriteLine(string.Join(' ', linkedList));
        }
    }
}
