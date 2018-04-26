namespace _07.InfernoInfinity.Core.Commands
{
    using Attributes;
    using Contracts;

    public class AddCommand : Command
    {
        [Inject]
        private readonly IRepository repository;
        [Inject]
        private readonly IGemFactory gemFactory;

        public AddCommand(string[] data, IRepository repository, IGemFactory gemFactory)
            : base(data)
        {
            this.repository = repository;
            this.gemFactory = gemFactory;
        }

        public override void Execute()
        {
            var weaponName = this.Data[0];
            var socketIndex = int.Parse(this.Data[1]);
            var gemType = this.Data[2];

            IGem gemToAdd = this.gemFactory.CreateGem(gemType);

            this.repository.Add(weaponName, socketIndex, gemToAdd);
        }
    }
}
