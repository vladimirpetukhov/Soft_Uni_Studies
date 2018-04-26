namespace _03.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var customStack = GetStack();

            PrintStack(customStack);
            PrintStack(customStack);
        }

        private static CustomStack<int> GetStack()
        {
            var customStack = new CustomStack<int>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var inputTokens = input
                    .Split(" ,".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                    .ToList();
                var command = inputTokens[0];

                try
                {
                    switch (command)
                    {
                        case "Push":
                            var elements = inputTokens.Skip(1).Select(int.Parse).ToList();
                            foreach (var element in elements)
                            {
                                customStack.Push(element);
                            }
                            break;
                        case "Pop":
                            customStack.Pop();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return customStack;
        }

        private static void PrintStack(CustomStack<int> customStack)
        {
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
