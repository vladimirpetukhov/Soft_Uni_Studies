using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
using System.Collections.Generic;

public class UnparkCommand : Command
{
    [Car]
    private IGarage garage;
    public UnparkCommand(IList<string> arguments,IGarage garage) : base(arguments)
    {
        this.garage = garage;
    }

    public override string Execute()
    {
        var id = int.Parse(Arguments[0]);
        garage.ParkedCars.Remove(id);

        return null;
    }
}

