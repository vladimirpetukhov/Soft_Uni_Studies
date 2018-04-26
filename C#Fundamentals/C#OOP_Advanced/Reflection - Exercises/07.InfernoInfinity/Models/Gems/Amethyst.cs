namespace _07.InfernoInfinity.Models.Gems
{
    using Enums;

    public class Amethyst : Gem
    {

        private const int AmethystStrengthBonus = 2;
        private const int AmethystAgilityBonus = 8;
        private const int AmethystVitalityBonus = 4;

        public Amethyst(GemClarity clarity)
            : base(clarity, AmethystStrengthBonus, AmethystAgilityBonus, AmethystVitalityBonus)
        {
        }
    }
}
