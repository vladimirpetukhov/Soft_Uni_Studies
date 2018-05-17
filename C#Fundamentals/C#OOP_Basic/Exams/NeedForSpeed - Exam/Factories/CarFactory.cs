using System;
using System.Linq;
using System.Collections.Generic;
using NeedForSpeed.Interfaces;
using System.Reflection;
public class CarFactory : ICarFactory
{
    private const string SuffixCar = "Car";
    
    public ICar CreateCar(IList<string> arguments)
    {
        string carType = arguments[0]+SuffixCar;
        string brand = arguments[1];
        string model = arguments[2];

        var intParsed = arguments.Skip(3).Select(int.Parse).ToList();

        int yearOfProduction = intParsed[0];
        int horsepower = intParsed[1];
        int acceleration = intParsed[2];
        int suspension = intParsed[3];
        int durability = intParsed[4];

        object[] args = new object[] 
        { brand, model, yearOfProduction, horsepower, acceleration, suspension, durability };

        Type type = Assembly.GetExecutingAssembly()
            .GetTypes()
            .FirstOrDefault(t => t.Name
            .Equals(carType, StringComparison.OrdinalIgnoreCase));

        ICar car = (ICar)Activator.CreateInstance(type, args);
        //switch (type)
        //{
        //    case "Performance":
        //        return new PerformanceCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        //    case "Show":
        //        return new ShowCar(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability);
        //    default:
        //        throw new ArgumentException();
        //}
        return car;
    }
}