namespace _05.KingsGambitExtended.Contracts
{
    using System;
    using Models;

    public interface IDefender : IHuman
    {
        event DeathEventHandler SoldierDead;

        int Lives { get; }

        void OnKingAttack(object sender, EventArgs args);

        void TakeAttack();
    }
}
