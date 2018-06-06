namespace Second_Way.Core
{
    using Contracts;
    using System;
    using System.Reflection;
    using System.Linq;
    using System.Collections.Generic;
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Create = "CreateStudent";
        private const string AddFriends = "AddFriends";

        private IRepository repository;
        public CommandInterpreter(IRepository repository)
        {
            this.repository = repository;
        }
       
        public IExecutable InterpredCommand(string[] arguments)
        {
            string commandName = string.Empty;
            
            if (arguments.Length == 2)
            {
                commandName = arguments[0];
            }
            
            if (arguments.Length == 3)
            {
                commandName = Create;
            }

            if(arguments.All(e=> int.TryParse(e,out int m)))
            {
                commandName = AddFriends;
            }


            Type commandType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(c => c.Name
                .Equals( commandName, StringComparison.OrdinalIgnoreCase));

            var args = new object[] {this.repository,arguments};
            IExecutable command = (IExecutable)Activator.CreateInstance(commandType, args);
            return command;
        }

        
    }
}
