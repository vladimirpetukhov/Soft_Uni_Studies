using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Minedraft.Commands
{
    public class RegisterHarvester : Command
    {
        
        public RegisterHarvester(List<string> args) : base(args)
        {
            Register(args);
        }

        public Participant Register(IList<string> arguments)
        {
            Object classType = null;
            var type = arguments[0];
            var id = arguments[1];
            var oreOutput = double.Parse(arguments[2]);
            var energyRequirement = double.Parse(arguments[3]);
            object[] args = null;
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type typeHarv = assembly.GetTypes().FirstOrDefault(n => n.Name == type + "Harvester");
            if (typeof(HammerHarvester).IsAssignableFrom(typeHarv))
            {
                args = new object[] { id, oreOutput, energyRequirement };
            }
            else
            {
                args = new object[] { id, oreOutput, energyRequirement, int.Parse(arguments[4]) };
            }
            var instance = Activator.CreateInstance(typeHarv, args);
            classType = instance;

            return (Harvester)classType;


        }
    }
}
