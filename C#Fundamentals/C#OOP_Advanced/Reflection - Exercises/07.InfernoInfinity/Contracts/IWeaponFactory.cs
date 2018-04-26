namespace _07.InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string weaponType, string weaponName);
    }
}
