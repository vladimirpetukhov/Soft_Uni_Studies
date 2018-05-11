using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Minedraft.Commands
{
    public class CommandInterpreter : ICommand
    {
        public Participant Execute(IList<string> commandArgs)
        {
            var command = commandArgs[0];
            commandArgs = commandArgs.Skip(1).ToList();
            string output;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == command);

            
            var instance = Activator.CreateInstance(type,new object[] { commandArgs});

            return (Participant)instance;
        }

        
    }
}
