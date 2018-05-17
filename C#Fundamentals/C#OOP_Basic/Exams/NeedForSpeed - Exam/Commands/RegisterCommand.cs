using NeedForSpeed.Interfaces.CommandBox;
using NeedForSpeed.Interfaces;
using System.Collections.Generic;
using NeedForSpeed.Core.Attributes;
using System.Linq;
using System;

public class RegisterCommand : Command
{
    
    private ParametersGatherer parametersGatherer;
    [Car]
    private ICarFactory carFactory;
    [Car]
    private ICarManager carManager;

    public RegisterCommand(IList<string> arguments, ICarFactory carFactory, ICarManager carManager)
        : base(arguments)
    {
        this.carFactory = carFactory;
        this.carManager = carManager;
        this.parametersGatherer = new ParametersGatherer();
    }

    public override string Execute()
    {
        var carId = int.Parse(Arguments[0]);
        var carType = Arguments[1];
        var carArguments = Arguments.Skip(1).ToList();

        var car = carFactory.CreateCar(carArguments);

        carManager.Cars.Add(carId, car);


        return null;
        

    }

}



