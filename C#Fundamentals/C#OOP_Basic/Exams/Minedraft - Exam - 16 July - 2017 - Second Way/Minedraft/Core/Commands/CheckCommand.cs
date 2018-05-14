using System;
using System.Collections.Generic;

public class CheckCommand : Command
{
    public CheckCommand(IList<string> arguments, IRepository repository)
        : base(arguments, repository)
    {
    }

    public override string Execute()
    {
        var id = Arguments[0];
        string msg = string.Empty;
        var providers = Repository.Providers;
        var harvesters = Repository.Harvesters;

        if (providers.ContainsKey(id))
        {
            msg = providers[id].ToString();
        }
        if (harvesters.ContainsKey(id))
        {
            msg = harvesters[id].ToString();
        }
        if (msg != String.Empty)
        {
            return msg;
        }

        return $"No element found with id - {id}";
    }
}

