namespace FestivalManager.Entities.Factories
{
    using System;
    using Contracts;
    using Entities.Contracts;
    using System.Linq;
    using System.Reflection;

    public class InstrumentFactory : IInstrumentFactory
    {
        public IInstrument CreateInstrument(string type)
        {
            var instrumentType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == type);

            return (IInstrument) Activator.CreateInstance(instrumentType);
        }
    }
}