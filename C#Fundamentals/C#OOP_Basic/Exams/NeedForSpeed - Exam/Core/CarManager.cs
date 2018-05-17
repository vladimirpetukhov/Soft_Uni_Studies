using System.Collections.Generic;
using NeedForSpeed.Interfaces;
using NeedForSpeed.Core.Attributes;
public class CarManager : ICarManager
{
    [Car]
    private IDictionary<int, ICar> cars;
    [Car]
    private IDictionary<int, IRace> races;
    [Car]
    private IDictionary<int, ICar> parkedCars;
    


    public CarManager()
    {
        this.Cars = new Dictionary<int, ICar>();            //Potencial ERROr
        this.Races = new Dictionary<int, IRace>();          //Potencial ERROr
        this.ParkedCars =new Dictionary<int, ICar>();       //Potencial ERROr
    }
    public IDictionary<int, ICar> Cars { get => cars; set => cars = value; }
    public IDictionary<int, IRace> Races { get => races; set => races = value; }
    public IDictionary<int, ICar> ParkedCars { get => parkedCars; set => parkedCars = value; }
  

    //public void Tune(int tuneIndex, string addOn)
    //{
    //    var parkedCars = garage.ParkedCars;

    //    foreach (var parkedCar in parkedCars)
    //    {
    //        var carName = parkedCar.Value.GetType().Name;
    //        parkedCar.Value.Horsepower += tuneIndex;
    //        parkedCar.Value.Suspension += tuneIndex / 2;

    //        switch (carName)
    //        {
    //            case "ShowCar":
    //                var currentCar = (ShowCar)parkedCar.Value;
    //                currentCar.Stars += tuneIndex;
    //                break;
    //            case "PerformanceCar":
    //                var performanceCar = (PerformanceCar)parkedCar.Value;
    //                performanceCar.AddOns.Add(addOn);
    //                break;
    //        }
    //    }
    //}
}
