using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
public class HarvesterFactory
{
    public void CreateHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        object[] args = null;
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type typeHarv = assembly.GetTypes().FirstOrDefault(n => n.Name == type+"Harvester");
        if (typeof(HammerHarvester).IsAssignableFrom(typeHarv))
        {
            args=new object[] {id,oreOutput,energyRequirement};
        }
        else
        {
            args = new object[] { id, oreOutput, energyRequirement, int.Parse(arguments[4]) };
        }
        var instance = Activator.CreateInstance(typeHarv, args);
        
        //switch (type)
        //{
        //    case "Hammer":
        //        return new HammerHarvester(id, oreOutput, energyRequirement);
        //    case "Sonic":
        //        var sonicFactor = int.Parse(arguments[4]);
        //        return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
        //    default:
        //        throw new ArgumentException("Harvester is not registered, because of it's Type");
        //}
    }
}