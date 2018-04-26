namespace _07.InfernoInfinity.Core.Factories
{
    using Contracts;
    using Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class GemFactory : IGemFactory
    {
        public IGem CreateGem(string gemType)
        {
            var args = gemType.Split();
            var clarity = Enum.Parse<GemClarity>(args[0]);
            var type = args[1];
            var gemInfo = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(g => g.Name == type);

            return (IGem)Activator.CreateInstance(gemInfo, clarity);
        }
    }
}
