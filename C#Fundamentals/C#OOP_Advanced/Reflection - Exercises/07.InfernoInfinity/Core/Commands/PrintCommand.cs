namespace _07.InfernoInfinity.Core.Commands
{
    using Attributes;
    using Contracts;

    public class PrintCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public PrintCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }

        public override void Execute()
        {
            string weaponName = this.Data[0];

            this.repository.Print(weaponName);
        }
    }
}
