using System.Collections.Generic;
using NeedForSpeed.Interfaces;
public class Garage:IGarage
{
    public Garage()
    {
        this.ParkedCars = new Dictionary<int, ICar>();
    }

    public IDictionary<int, ICar> ParkedCars { get; protected set; }
}

