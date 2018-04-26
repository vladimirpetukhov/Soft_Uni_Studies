namespace _07.InfernoInfinity.Models.Weapons
{
    using Contracts;
    using Enums;
    using Gems;
    using System.Linq;

    public abstract class Weapon : IWeapon
    {
        private readonly int minDamage;
        private readonly int maxDamage;
        private readonly IGem[] sockets;
        private readonly WeaponRarity rarity;

        protected Weapon(WeaponRarity rarity, string name, int minDamage, int maxDamage, IGem[] sockets)
        {
            this.rarity = rarity;
            this.Name = name;
            this.minDamage = minDamage;
            this.maxDamage = maxDamage;
            this.sockets = sockets;
        }

        public string Name { get; }

        public int MinDamage => this.minDamage * (int)this.rarity;

        public int MaxDamage => this.maxDamage * (int)this.rarity;

        public void AddGem(IGem gem, int index)
        {
            if (index >= 0 && index < this.sockets.Length)
            {
                this.sockets[index] = gem;
            }
        }

        public void RemoveGem(int index)
        {
            if (index >= 0 && index < this.sockets.Length && this.sockets[index] != null)
            {

                this.sockets[index] = null;
            }
        }

        public override string ToString()
        {
            var localGems = this.sockets
                .Cast<Gem>()
                .Where(g => g != null)
                .ToArray();
            int bonusMinDamage = localGems.Sum(g => g.AddBonusToMinDamage()) + this.MinDamage;
            int bonusMaxDamage = localGems.Sum(g => g.AddBonusToMaxDamage()) + this.MaxDamage;

            int strength = localGems.Sum(g => g.Strength);
            int agility = localGems.Sum(g => g.Agility);
            int vitality = localGems.Sum(g => g.Vitality);


            return $"{this.Name}: {bonusMinDamage}-{bonusMaxDamage} Damage, +{strength} Strength, +{agility} Agility, +{vitality} Vitality";
        }
    }
}
