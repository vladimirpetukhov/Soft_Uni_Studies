namespace BarraksWars.Core
{
    using Attributes;
    using Contracts;
    using System;
    using System.Collections;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        private const string CommandSuffix = "Command";

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandFullName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(commandName) + CommandSuffix;

            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandFullName);


            if (commandType == null)
            {
                throw new InvalidOperationException($"Invalid Command!");
            }
            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"Invalid Type!");
            }

            return InjectDependencies(commandType, data, commandType);

        }

        private IExecutable InjectDependencies(IReflect commandType, IEnumerable data, Type type)
        {
            var fieldsToInject = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.GetCustomAttributes<InjectAttribute>() != null)
                .ToArray();

            var injectArgs = fieldsToInject
                .Select(f => this.serviceProvider.GetService(f.FieldType)).ToArray();
            var constrArgs = new object[] { data }.Concat(injectArgs).ToArray();

            var instance = (IExecutable)Activator.CreateInstance(type, constrArgs);
            return instance;
        }
    }
}
