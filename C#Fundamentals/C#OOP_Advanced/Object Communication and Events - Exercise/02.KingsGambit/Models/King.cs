namespace _02.KingsGambit.Models
{
    using System;

    public class King
    {
        public event EventHandler UnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public void OnAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            UnderAttack?.Invoke(this, null);
        }
    }
}
