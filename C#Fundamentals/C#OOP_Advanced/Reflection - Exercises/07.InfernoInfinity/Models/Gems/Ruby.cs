namespace _07.InfernoInfinity.Models.Gems
{
    using Enums;

    public class Ruby : Gem
    {
        private const int RubyStrengthBonus = 7;
        private const int RubyAgilityBonus = 2;
        private const int RubyVitalityBonus = 5;

        public Ruby(GemClarity clarity)
            : base(clarity, RubyStrengthBonus, RubyAgilityBonus, RubyVitalityBonus)
        {
        }
    }
}
