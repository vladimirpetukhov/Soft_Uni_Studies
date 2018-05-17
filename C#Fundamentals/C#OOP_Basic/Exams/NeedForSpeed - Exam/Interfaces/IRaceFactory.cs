namespace NeedForSpeed.Interfaces
{
    using System.Collections.Generic;
    public interface IRaceFactory
    {
        IRace CreateRace(IList<string> arguments);
    }
}
