using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


public class CommandInterpreter : ICommandInterpreter
{
    private const string Suufix ="Command";

    private IServiceProvider serviceProvider;
    public string InterpredCommand(IList<string> commandParameters,IServiceProvider service)
    {
        string command = commandParameters[0];
        string commandFullName = command + Suufix;
        this.serviceProvider = service;

        commandParameters = commandParameters.Skip(1).ToList();

        Type commandType = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(commandFullName, StringComparison.OrdinalIgnoreCase));

        FieldInfo[] fieldInfos = commandType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Public| BindingFlags.Instance )
            //.Where(f => f.CustomAttributes
            //.Any(ca => ca.AttributeType == typeof(InjectAttributes)))
            .ToArray();

        object[] injectArgs = fieldInfos
            .Select(f => this.serviceProvider.GetService(f.FieldType))
            .ToArray();

        object[] args = new object[] { commandParameters }
        .Concat(injectArgs)
        .ToArray();
        

        var instance = Activator.CreateInstance(commandType, args);

        MethodInfo method = commandType
            .GetMethods()
            .First();

        string result = (string)method.Invoke(instance, null);

        
        return result;
    }
}

