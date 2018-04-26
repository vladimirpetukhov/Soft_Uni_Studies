namespace BarraksWars.Models.Units
{
    public class Gunner : Unit
    {
        private const int GunnerHealth = 20;
        private const int GunnerAttackDamage = 20;

        public Gunner()
            : base(GunnerHealth, GunnerAttackDamage)
        {
        }
    }
}
