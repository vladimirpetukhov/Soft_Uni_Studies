namespace _07.InfernoInfinity.Contracts
{
    public interface IWeapon
    {
        void AddGem(IGem gem, int index);

        void RemoveGem(int index);
    }
}
