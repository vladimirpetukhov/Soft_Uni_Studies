using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed.Interfaces
{
    public interface ICar
    {
        string Brand { get; }
        string Model { get;  }
        int YearOfProduction { get; }
        int Horsepower { get; set; }
        int Acceleration { get;  }
        int Suspension { get; set; }
        int Durability { get; set; }
        int GetOverallPerformance();
        int GetEnginePerformance();
        int GetSuspensionPerformance();
        int OverallPerformance();
        int EnginePerformance();
        int SuspensionPerformance();
    }
}
