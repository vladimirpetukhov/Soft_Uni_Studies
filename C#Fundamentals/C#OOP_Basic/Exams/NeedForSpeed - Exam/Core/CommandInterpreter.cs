using NeedForSpeed.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
using NeedForSpeed.Core.Attributes;
using NeedForSpeed.Interfaces.CommandBox;
public class CommandInterpreter : ICommandInterpreter
{
    private const string Suffix ="Command";
   private IServiceProvider serviceProvider;

    public CommandInterpreter(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    public string ReturnCommand(IList<string> commandArgs)
    {
        string commandName = commandArgs[0]+Suffix;
        var data = commandArgs.Skip(1).ToList();
        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(commandName, StringComparison.OrdinalIgnoreCase));

        FieldInfo[] fieldInfos = commandType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(f => f.CustomAttributes
            .Any(ca => ca.AttributeType== typeof(CarAttribute)))
            .ToArray();

        object[] arguments = fieldInfos         //Potencial ERROR
            .Select(f => this.serviceProvider
            .GetService(f.FieldType))
            .ToArray();

        object[] args = new[] { data }.Concat(arguments)
            .ToArray();


        IExecute instance = (IExecute)Activator.CreateInstance(commandType, args);
        
        MethodInfo takeMethod = typeof(IExecute).GetMethods().First();

        var result =(string) takeMethod.Invoke(instance,null);
        return result;
    }
}

