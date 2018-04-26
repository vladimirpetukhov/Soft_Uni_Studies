namespace _07.InfernoInfinity.Core.Commands
{
    using Attributes;
    using Contracts;

    public class RemoveCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public RemoveCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override void Execute()
        {
            string weaponName = this.Data[0];
            int weaponIndex = int.Parse(this.Data[1]);

            this.repository.Remove(weaponName, weaponIndex);
        }
    }
}
