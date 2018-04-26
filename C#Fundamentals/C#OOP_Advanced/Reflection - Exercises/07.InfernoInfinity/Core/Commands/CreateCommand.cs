namespace _07.InfernoInfinity.Core.Commands
{
    using Attributes;
    using Contracts;

    public class CreateCommand : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IWeaponFactory weaponFactory;

        public CreateCommand(string[] data, IRepository repository, IWeaponFactory weaponFactory)
            : base(data)
        {
            this.repository = repository;
            this.weaponFactory = weaponFactory;
        }

        public override void Execute()
        {
            var weaponType = this.Data[0];
            var weaponName = this.Data[1];

            var weapon = this.weaponFactory.CreateWeapon(weaponType, weaponName);
            this.repository.Create(weapon);
        }
    }
}
