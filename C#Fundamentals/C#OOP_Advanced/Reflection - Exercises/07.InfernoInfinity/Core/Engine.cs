namespace _07.InfernoInfinity.Core
{
    using Contracts;
    using System;
    using System.Linq;

    public class Engine : IRunnable
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] data = input.Split(';');
                    string commandName = data[0];
                    data = data.Skip(1).ToArray();
                    var result = this.commandInterpreter.InterpretCommand(data, commandName);
                    result.Execute();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
