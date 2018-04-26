namespace _07.InfernoInfinity.Models.Weapons
{
    using Contracts;
    using Enums;

    public class Sword : Weapon
    {
        private const int MinSwordDamage = 4;
        private const int MaxSwordDamageDamage = 6;
        private const int MinSwordDamageGemSockets = 3;

        public Sword(WeaponRarity rarity, string name)
            : base(rarity, name, MinSwordDamage, MaxSwordDamageDamage, new IGem[MinSwordDamageGemSockets])
        {
        }
    }
}
