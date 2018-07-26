namespace Sweetshop.App
{
    using System;
    using System.Linq;
    using Microsoft.Extensions.DependencyInjection;

    using Core.Contracts;
    using Core.IO;
    using Service.Contracts;
    

    public class Engine : IEngine
    {
        private readonly IServiceProvider serviceProvider;
        

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            
        }

        public void Run()
        {
            var initialiseDb = this.serviceProvider.GetService<IDbInitialise>();
            initialiseDb.InitialiseDb();

            var commandInterpreter = this.serviceProvider.GetService<ICommandInterpreter>();

            var reader = this.serviceProvider.GetService<IReader>();

            while (true)
            {

                string[] input=reader.Read().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string comandName = input[0];

                string[] commandArgs = input.Skip(1).ToArray();

                try
                {
                    ICommand command = (ICommand)commandInterpreter.InterpretCommand(commandArgs, comandName);
                
                    string result = command.Execute(commandArgs);

                    Console.WriteLine(result);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
