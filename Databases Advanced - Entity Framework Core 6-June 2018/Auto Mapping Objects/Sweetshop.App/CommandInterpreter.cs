namespace Sweetshop.App
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand InterpretCommand(string[] args,string name)
        {

            string commandName = name+Suffix;

            Type type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

            if (type == null)
            {
                throw new ArgumentException("Invalid command name");
            }
            

            var constructor = type.GetConstructors().First();

            var parameters = constructor.GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            var service = parameters.Select(this.serviceProvider.GetService)
                .ToArray();

            var command =(ICommand)constructor.Invoke(service);


            return command;
        }
    }
}
