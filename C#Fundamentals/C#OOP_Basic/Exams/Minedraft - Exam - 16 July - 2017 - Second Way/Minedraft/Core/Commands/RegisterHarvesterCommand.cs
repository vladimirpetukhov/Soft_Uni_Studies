using System.Collections.Generic;
using System;
public class RegisterHarvesterCommand : Command
{
    public RegisterHarvesterCommand(IList<string> arguments, Repository repository)
        : base(arguments, repository)
    {
        this.Factory = new HarvesterFactory();
    }

    public override string Execute()
    {
        var id = Arguments[1];
        var message = string.Empty;
        var harvesterType = Arguments[0];
        try
        {
            IHarvester harvester = (IHarvester)this.Factory.CreateUnit(this.Arguments);
            string m = this.Repository.AddHarvester(id, harvester);
            message = String.Format(m, harvesterType, harvester.Id);
        }
        catch (ArgumentException ex)
        {
            message = ex.Message;
        }
        return message;
    }
}

