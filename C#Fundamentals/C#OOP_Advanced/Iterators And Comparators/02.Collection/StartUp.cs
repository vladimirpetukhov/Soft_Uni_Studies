namespace _02.Collection
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            var collection = new ListyIterator<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputTokens = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var command = inputTokens[0];
                inputTokens = inputTokens.Skip(1).ToList();

                try
                {
                    switch (command)
                    {
                        case "Create":
                            if (inputTokens.Any())
                            {
                                collection = new ListyIterator<string>(inputTokens);
                            }
                            break;
                        case "Print":
                            collection.Print();
                            break;
                        case "Move":
                            Console.WriteLine(collection.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(collection.HasNext());
                            break;
                        case "PrintAll":
                            collection.PrintAll();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
