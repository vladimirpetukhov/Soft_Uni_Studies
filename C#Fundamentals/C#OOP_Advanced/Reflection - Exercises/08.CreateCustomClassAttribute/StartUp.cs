namespace _08.CreateCustomClassAttribute
{
    using Attributes;
    using Models;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var customAttributes = typeof(Weapon).GetCustomAttributes(false);

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END") break;

                PrintCommand(customAttributes, command);
            }
        }

        private static void PrintCommand(object[] attributes, string command)
        {
            foreach (CustomAttribute attribute in attributes)
            {
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"{command}: {attribute.Author}");
                        break;
                    case "Revision":
                        Console.WriteLine($"{command}: {attribute.Revision}");
                        break;
                    case "Description":
                        Console.WriteLine($"Class {command.ToLower()}: {attribute.Description}");
                        break;
                    case "Reviewers":
                        Console.WriteLine($"{command}: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }
            }
        }
    }
}
