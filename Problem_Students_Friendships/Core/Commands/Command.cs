namespace Second_Way.Core.Commands
{
    using Contracts;
    using System.Collections.Generic;
    public abstract class Command : IExecutable
    {
        private IRepository repository;
        private string[] args;

        protected Command(IRepository repository, string[] args)
        {
            this.Repository = repository;
            this.Args = args;
        }

        public IRepository Repository
        {
            get { return this.repository; }
            protected set { this.repository = value; }
        }

        public string[] Args
        {
            get { return this.args; }
            private set { this.args = value; }
        }

        public abstract string Execute(string[] args);
    }
}
