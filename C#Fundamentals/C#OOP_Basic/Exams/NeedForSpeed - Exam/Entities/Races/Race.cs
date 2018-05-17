using System.Collections.Generic;
using NeedForSpeed.Interfaces;
public abstract class Race:IRace
{
    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.Participants = new Dictionary<int, ICar>();
    }

    public int Length { get; private set; }
    public string Route { get; private set; }
    public int PrizePool { get; private set; }
    public IDictionary<int, ICar> Participants { get; private set; }

    public abstract int GetPerformancePoints();
}

