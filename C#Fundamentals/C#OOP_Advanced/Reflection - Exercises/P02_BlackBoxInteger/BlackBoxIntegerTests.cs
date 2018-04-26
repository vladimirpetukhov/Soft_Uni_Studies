namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    class BlackBoxIntegerTests
    {
        static void Main()
        {
            var blackboxType = typeof(BlackBoxInt);
            var blackboxInstance = (BlackBoxInt)Activator.CreateInstance(blackboxType, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var methodTokens = input.Split(new[] { '_' }, StringSplitOptions.RemoveEmptyEntries);
                var methodName = methodTokens[0];
                var methodParam = int.Parse(methodTokens[1]);

                blackboxType
                    .GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic)
                    ?.Invoke(blackboxInstance, new object[] {methodParam});

                var innerValue = blackboxType
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .First()
                    .GetValue(blackboxInstance);

                Console.WriteLine(innerValue);
            }
        }
    }
}
