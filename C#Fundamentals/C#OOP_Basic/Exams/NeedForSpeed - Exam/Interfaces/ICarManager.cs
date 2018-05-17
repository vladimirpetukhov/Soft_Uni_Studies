namespace NeedForSpeed.Interfaces
{
    using System.Collections.Generic;
    public interface ICarManager
    {
        IDictionary<int, ICar> Cars { get; set; }
        IDictionary<int, IRace> Races { get; set; }
        IDictionary<int, ICar> ParkedCars { get; set; }
        //string Check(int id);
        //void Open(int id, string type, int length, string route, int prizePool);
        //void Open(int id, string type, int length, string route, int prizePool, int extraParam);
        //void Participate(int carId, int raceId);
        //string Start(int id);
        //void Park(int id);
        //void Unpark(int id);
        //void Tune(int tuneIndex, string addOn);
    }
}
