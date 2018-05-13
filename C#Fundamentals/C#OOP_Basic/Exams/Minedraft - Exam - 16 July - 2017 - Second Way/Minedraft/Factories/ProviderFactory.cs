using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
public class ProviderFactory:IFactory
{
    private const string Suffix ="Provider";

    public IUnit CreateUnit(IList<string> arguments)
    {
        var providerType = arguments[0];
        var fullName = providerType + Suffix;

        var providerId = arguments[1];
        var providerEnergyOutput = double.Parse(arguments[2]);

        Type provider = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(fullName, StringComparison.OrdinalIgnoreCase));

        object[] args = new object[] {providerId,providerEnergyOutput};

        IProvider activatedProvider =(IProvider) Activator.CreateInstance(provider, args);

        return null;
    }
}

