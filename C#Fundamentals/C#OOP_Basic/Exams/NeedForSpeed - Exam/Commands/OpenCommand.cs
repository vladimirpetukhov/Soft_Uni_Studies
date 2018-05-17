using NeedForSpeed.Interfaces;
using System.Collections.Generic;
using NeedForSpeed.Core.Attributes;
using System.Linq;
public class OpenCommand : Command
{
    [Car]
    private ICarManager carManager;
    
    private IRaceFactory raceFactory;
    public OpenCommand(IList<string> arguments, ICarManager carManager) : base(arguments)
    {
        this.carManager = carManager;
        this.raceFactory = new RaceFactory();
    }

    public override string Execute()
    {
        int id = int.Parse(Arguments[0]);
        string type = Arguments[1];
        int length = int.Parse(Arguments[2]);
        string route = Arguments[3];
        int prizePool = int.Parse(Arguments[4]);

        var arguments = this.Arguments.Skip(1).ToList();
        IRace race= this.raceFactory.CreateRace(arguments);
        this.carManager.Races[id] = race;
        return null;
    }
}

