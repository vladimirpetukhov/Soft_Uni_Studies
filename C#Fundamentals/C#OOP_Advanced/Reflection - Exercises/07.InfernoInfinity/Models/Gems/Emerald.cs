namespace _07.InfernoInfinity.Models.Gems
{
    using Enums;

    public class Emerald : Gem
    {
        private const int EmeraldStrengthBonus = 1;
        private const int EmeraldAgilityBonus = 4;
        private const int EmeraldVitalityBonus = 9;

        public Emerald(GemClarity clarity)
            : base(clarity, EmeraldStrengthBonus, EmeraldAgilityBonus, EmeraldVitalityBonus)
        {
        }
    }
}
