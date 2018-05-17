using System.Collections.Generic;
using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
public class CheckCommand : Command
{
    [Car]
    private ICarManager carManager;
    public CheckCommand(IList<string> arguments,ICarManager carManager) 
        : base(arguments)
    {
        this.carManager = carManager;
    }

    public override string Execute()
    {
        var id = int.Parse(Arguments[0]);
        return carManager.Cars[id].ToString().Trim();
        
        
    }
}

