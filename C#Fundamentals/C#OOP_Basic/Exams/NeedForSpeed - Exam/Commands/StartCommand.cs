using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
using System.Collections.Generic;

public class StartCommand : Command
{
    [Car]
    private ICarManager carManager;
    public StartCommand(IList<string> arguments,ICarManager manager) : base(arguments)
    {
        this.carManager = manager;
    }

    public override string Execute()
    {
        var raceId = int.Parse(Arguments[0]);
        var race = carManager.Races[raceId];

        if (race.Participants.Count == 0)
        {
            return $"Cannot start the race with zero participants.";
        }

        this.carManager. Races.Remove(raceId);
        return race.ToString();
        throw new System.NotImplementedException();
    }
}

