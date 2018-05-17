
using System.Collections.Generic;
using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
public class ParticipateCommand : Command
{
    [Car]
    private ICarManager carManager;
    [Car]
    private IGarage garage;
    public ParticipateCommand(IList<string> arguments,ICarManager carManager,IGarage garage) 
        : base(arguments)
    {
        this.carManager = carManager;
        this.garage = garage;
    }

    public override string Execute()
    {
        var carId = int.Parse(Arguments[0]);
        var raceId = int.Parse(Arguments[1]);
        var car = carManager.Cars[carId];
        var race = carManager.Races[raceId];

        if (!garage.ParkedCars.ContainsKey(carId))
        {
            if ((race.GetType().Name == "TimeLimitRace" && race.Participants.Count == 0) || race.GetType().Name != "TimeLimitRace")
            {
                race.Participants[carId] = car;
            }
        }
        return null;
    }
}

