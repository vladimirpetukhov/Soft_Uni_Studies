using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;
public class TuneCommand : Command
{
    private const string SuffixCar ="Car";
    [Car]
    private IGarage garage;
    public TuneCommand(IList<string> arguments,IGarage garage) : base(arguments)
    {
        this.garage = garage;
    }

    public override string Execute()
    {
        var parkedCars = garage.ParkedCars;
        var tuneIndex = int.Parse(Arguments[0]);
        var addOn = Arguments[1];

        foreach (var parkedCar in parkedCars)
        {
            var carName = parkedCar.Value.GetType().Name+SuffixCar;

            parkedCar.Value.Horsepower += tuneIndex;
            parkedCar.Value.Suspension += tuneIndex / 2;

            Type carType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t=> t.Name
                .Equals(carName,StringComparison.OrdinalIgnoreCase));

            if (typeof(ShowCar).IsAssignableFrom(carType))
            {
               var currentCar =(ShowCar) parkedCar.Value;
                currentCar.Stars += tuneIndex;
            }
            if (typeof(PerformanceCar).IsAssignableFrom(carType))
            {
                var performanceCar = (PerformanceCar)parkedCar.Value;
                performanceCar.AddOns.Add(addOn);
            }
            
        }
        return null;
    }
}

