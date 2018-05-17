namespace NeedForSpeed.Interfaces
{
    using System.Collections.Generic;
    public interface IGarage
    {
        IDictionary<int, ICar> ParkedCars { get; }
    }
}
