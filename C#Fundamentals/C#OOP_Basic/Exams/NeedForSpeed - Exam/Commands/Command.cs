using NeedForSpeed.Interfaces.CommandBox;
using System.Collections.Generic;
public abstract class Command :IExecute
{
    private IList<string> arguments;

    protected Command(IList<string> arguments)
    {
        this.Arguments = arguments;
    }

    public  IList<string> Arguments
    {
        get { return this.arguments; }
        set { this.arguments = value; }
    }

    public abstract string Execute();
}

