using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Reflection.Emit;

public class HarvesterFactory : UnitFactory
{
    private const string Suffix = "Harvester";
    public override IUnit CreateUnit(IList<string> arguments)
    {
        var harvesterType = arguments[0];
        var harvesterFullName = harvesterType + Suffix;

        var harvesterId = arguments[1];
        var harvesterOreOutput = double.Parse(arguments[2]);
        var harvesterEnergyRequirement = double.Parse(arguments[3]);

        Type type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(harvesterFullName, StringComparison.OrdinalIgnoreCase));

        ConstructorInfo ctor = type.GetConstructors().First();
        int numberOfArguments = ctor.GetParameters().Length;

        object[] givenArgs = new object[] { harvesterId,harvesterOreOutput,harvesterEnergyRequirement};
        if (numberOfArguments > 3)
        {
            var sonicFactor = int.Parse(arguments[4]);
            givenArgs= new object[] { harvesterId, harvesterOreOutput, harvesterEnergyRequirement,sonicFactor };
        }

        try
        {
            IHarvester getHarvester = (IHarvester)Activator.CreateInstance(type, givenArgs);
            return getHarvester;
        }
        catch(TargetInvocationException e)
        {
            throw e.InnerException;
        }

        
        
    }


}
