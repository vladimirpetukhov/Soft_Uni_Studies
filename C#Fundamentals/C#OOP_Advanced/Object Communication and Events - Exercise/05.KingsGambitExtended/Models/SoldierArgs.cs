namespace _05.KingsGambitExtended.Models
{
    using Contracts;
    using System;

    public class SoldierArgs : EventArgs
    {
        public SoldierArgs(IDefender soldier, KingUnderAttackEventHandler onKingAttack)
        {
            this.Soldier = soldier;
            this.OnKingAttack = onKingAttack;
        }

        public IDefender Soldier { get; }

        public KingUnderAttackEventHandler OnKingAttack { get; }
    }
}
