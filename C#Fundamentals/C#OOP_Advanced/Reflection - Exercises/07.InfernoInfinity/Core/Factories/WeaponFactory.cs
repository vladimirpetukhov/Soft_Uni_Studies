namespace _07.InfernoInfinity.Core.Factories
{
    using Contracts;
    using Enums;
    using System;
    using System.Linq;
    using System.Reflection;

    public class WeaponFactory : IWeaponFactory
    {
        public IWeapon CreateWeapon(string weaponType, string weaponName)
        {
            var args = weaponType.Split();
            var rarity = Enum.Parse<WeaponRarity>(args[0]);
            var type = args[1];

            var weaponInfo = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t=> t.Name == type);
            

            return (IWeapon)Activator.CreateInstance(weaponInfo, rarity, weaponName);
        }
    }
}
