using System.Collections.Generic;

public abstract class Command : ICommand
{

    private IList<string> arguments;
    [InjectAttributes]
    private IRepository repository;
    [InjectAttributes]
    private IFactory factory;

    protected Command(IList<string> arguments, IRepository repository)
    {
        this.Arguments = arguments;
        Repository = repository;
        
    }

    public abstract string Execute();

    public IRepository Repository
    {
        get { return this.repository; }
        protected set { this.repository = value; }
    }
    public IFactory Factory
    {
        get { return this.factory; }
        protected set { this.factory = value; }
    }

    public IList<string> Arguments
    {
        get { return this.arguments; }
        set { this.arguments = value; }
    }
}

