namespace _07.InfernoInfinity.Contracts
{
    public interface IRepository
    {
        void Create(IWeapon weapon);

        void Add(string weaponName, int socketIndex, IGem gem);
        
        void Remove(string weaponName, int socketIndex);
        
        void Print(string weaponName);
    }
}
