namespace NeedForSpeed.Interfaces
{
    using System.Collections.Generic;
    public interface IRace
    {
        int Length { get; }
        string Route { get; }
        int PrizePool { get; }
        IDictionary<int, ICar> Participants { get; }

        int GetPerformancePoints();
    }
}
