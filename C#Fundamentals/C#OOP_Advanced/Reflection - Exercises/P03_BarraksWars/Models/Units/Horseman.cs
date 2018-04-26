namespace BarraksWars.Models.Units
{
    public class Horseman : Unit
    {
        private const int HorsemanHealth = 50;
        private const int HorsemanAttackDamage = 10;

        public Horseman()
            : base(HorsemanHealth, HorsemanAttackDamage)
        {
        }
    }
}
