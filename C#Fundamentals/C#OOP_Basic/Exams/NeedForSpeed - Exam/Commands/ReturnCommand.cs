using NeedForSpeed.Interfaces.CommandBox;
using System.Collections.Generic;
public abstract class ReturnCommand : IReturnable
{
    
    private IList<string> arguments;

    protected ReturnCommand(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public IList<string> Arguments
    {
        get { return this.arguments; }
        set { this.arguments = value; }
    }
    public abstract string Execute();
}

