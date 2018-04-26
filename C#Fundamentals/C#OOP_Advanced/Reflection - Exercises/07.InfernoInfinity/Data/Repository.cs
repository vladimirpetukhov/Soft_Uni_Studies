namespace _07.InfernoInfinity.Data
{
    using Contracts;
    using Models.Weapons;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Repository : IRepository
    {
        private readonly IList<Weapon> weapons;

        public Repository()
        {
            this.weapons = new List<Weapon>();
        }

        public void Create(IWeapon weapon)
        {
            this.weapons.Add((Weapon)weapon);
        }

        public void Add(string weaponName, int socketIndex, IGem gem)
        {
            this.weapons
                .FirstOrDefault(w=> w.Name == weaponName)
                ?.AddGem(gem, socketIndex);
        }

        public void Remove(string weaponName, int weaponIndex)
        {
            this.weapons
                .FirstOrDefault(w => w.Name == weaponName)
                ?.RemoveGem(weaponIndex);
        }

        public void Print(string weaponName)
        {
            Console.WriteLine(this.weapons.FirstOrDefault(w => w.Name == weaponName));
        }
    }
}
