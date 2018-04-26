namespace _07.InfernoInfinity.Models.Weapons
{
    using Contracts;
    using Enums;

    public class Knife : Weapon
    {
        private const int MinKnifeDamage = 3;
        private const int MaxKnifeDamage = 4;
        private const int KnifeGemSockets = 2;

        public Knife(WeaponRarity rarity, string name)
            : base(rarity, name, MinKnifeDamage, MaxKnifeDamage, new IGem[KnifeGemSockets])
        {
        }
    }
}
