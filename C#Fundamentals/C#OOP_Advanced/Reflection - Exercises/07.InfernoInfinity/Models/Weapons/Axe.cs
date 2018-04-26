namespace _07.InfernoInfinity.Models.Weapons
{
    using Contracts;
    using Enums;

    public class Axe : Weapon
    {
        private const int MinAxeDamage = 5;
        private const int MaxAxeDamage = 10;
        private const int AxeGemSockets = 4;

        public Axe(WeaponRarity rarity, string name)
            : base(rarity, name, MinAxeDamage, MaxAxeDamage, new IGem[AxeGemSockets])
        {
        }
    }
}
