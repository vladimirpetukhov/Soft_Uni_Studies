using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
using System.Collections.Generic;

public class ParkCommand : Command
{
    [Car]
    private ICarManager carManager;
    [Car]
    private IGarage garage;
    public ParkCommand(IList<string> arguments,ICarManager manager,IGarage garage) 
        : base(arguments)
    {
        this.carManager = manager;
        this.garage = garage;
    }

    public override string Execute()
    {
        var id = int.Parse(Arguments[0]);
        foreach (var race in this.carManager. Races)
        {
            if (race.Value.Participants.ContainsKey(id))
            {
                return null;
            }
        }
        var car =this.carManager. Cars[id];
        garage.ParkedCars.Add(id, car);
        return null;
    }
}

