namespace NeedForSpeed.Interfaces
{
    using System.Collections.Generic;
   public interface ICarFactory
    {
        ICar CreateCar(IList<string> arguments);
    }
}
