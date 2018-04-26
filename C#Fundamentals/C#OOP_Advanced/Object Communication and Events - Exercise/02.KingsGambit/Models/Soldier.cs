namespace _02.KingsGambit.Models
{
    using System;

    public abstract class Soldier
    {
        protected Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract void KingUnderAttack(object sender, EventArgs e);
    }
}
