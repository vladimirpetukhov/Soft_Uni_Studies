using System;
using System.Collections.Generic;
public class ModeCommand : Command
{
    public ModeCommand(IList<string> arguments, IRepository repository) 
        : base(arguments, repository)
    {
    }

    public override string Execute()
    {
        string modeToChange = Arguments[0];
        string mode = Repository.Mode;

        if (modeToChange == "Half")
        {
            this.Repository.Mode = modeToChange;
        }
        else if (modeToChange == "Full")
        {
            this.Repository.Mode = modeToChange;
        }
        else
        {
            this.Repository.Mode = modeToChange;
        }

        return $"Successfully changed working mode to {this.Repository.Mode} Mode";
    }
}

