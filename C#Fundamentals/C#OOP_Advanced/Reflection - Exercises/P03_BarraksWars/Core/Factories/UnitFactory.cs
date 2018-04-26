namespace BarraksWars.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var model = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == unitType);

            if (model == null)
            {
                throw new InvalidOperationException($"Invalid Command!");
            }
            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new InvalidOperationException($"{unitType} is Not a Unit Type!");
            }

            return (IUnit)Activator.CreateInstance(model);
        }
    }
}
