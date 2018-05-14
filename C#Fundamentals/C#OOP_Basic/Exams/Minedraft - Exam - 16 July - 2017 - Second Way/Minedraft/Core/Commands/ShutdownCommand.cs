using System.Collections.Generic;
using System.Text;

public class ShutdownCommand : Command
{
    public ShutdownCommand(IList<string> arguments, IRepository repository)
        : base(arguments, repository)
    {
    }

    public override string Execute()
    {
        var sb = new StringBuilder();
        var totalStoredEnergy = Repository.TotalStoredEnergy;
        var totalMinedOre = Repository.TotalMinedOre;

        sb.AppendLine("System Shutdown");
        sb.AppendLine($"Total Energy Stored: {totalStoredEnergy}");
        sb.AppendLine($"Total Mined Plumbus Ore: {totalMinedOre}");

        return sb.ToString().Trim();
    }
}

