using System;
using System.Collections.Generic;
using NeedForSpeed.Interfaces;
using System.Reflection;
using System.Linq;
public  class RaceFactory:IRaceFactory
{
    private const string SuffixRace ="Race";
    public  IRace CreateRace(IList<string> arguments)
    {
        string type = arguments[0];
        int length = int.Parse(arguments[1]);
        string route = arguments[2];
        int prizePool = int.Parse(arguments[3]);

        string raceType = type + SuffixRace;

        Type typeOfRace = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(raceType, StringComparison.OrdinalIgnoreCase));

        object[] args = new object[] { length, route, prizePool };

        IRace race = (IRace)Activator.CreateInstance(typeOfRace, args);
        
        return race;
    }
}

