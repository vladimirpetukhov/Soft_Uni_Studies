namespace _07.InfernoInfinity.Core.Commands
{
    using Contracts;

    public abstract class Command : IExecutable
    {
        private string[] data;

        protected Command(string[] data)
        {
            this.data = data;
        }

        public string[] Data
        {
            get => this.data;
            private set => this.data = value;

        }

        public abstract void Execute();
    }
}
