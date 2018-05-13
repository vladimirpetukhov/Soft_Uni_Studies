using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public class CommandInterpreter : ICommandInterpreter
{
    private const string Suufix ="Command";
    public string InterpredCommand(IList<string> commandParameters,IRepository repository)
    {
        string command = commandParameters[0];
        string commandFullName = command + Suufix;

        commandParameters = commandParameters.Skip(1).ToList();

        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(commandFullName, StringComparison.OrdinalIgnoreCase));

        object[] args = new object[] {commandParameters,repository};

        if (commandParameters.Count == 1)
        {
            args = null;
        }

        var instance = Activator.CreateInstance(commandType, args);

        MethodInfo method = commandType
            .GetMethods()
            .First();

        string result = (string)method.Invoke(instance, null);

        
        return result;
    }
}

