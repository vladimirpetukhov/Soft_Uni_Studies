
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DayCommand : Command
{
    private string mode;
    public DayCommand(IList<string> arguments, IRepository repository) : base(arguments, repository)
    {
        this.mode ="Full";
    }

    public override string Execute()
    {
            double dayEnergy = 0;
            double dayOre = 0;
            double harvestNeededEnergyForDay = 0;

            dayEnergy =Repository.Providers.Sum(v => v.Value.EnergyOutput);
            this.Repository.TotalStoredEnergy += dayEnergy;

            harvestNeededEnergyForDay +=Repository. Harvesters.Sum(h => h.Value.EnergyRequirement);

            if (Repository. TotalStoredEnergy >= harvestNeededEnergyForDay)
            {
                if (mode == "Full")
                {
                    dayOre +=Repository. Harvesters.Values.Sum(h => h.OreOutput);
                   Repository. TotalStoredEnergy -= harvestNeededEnergyForDay;
                }
                else if (mode == "Half")
                {
                    dayOre +=Repository. Harvesters.Values.Sum(h => (h.OreOutput * 50) / 100);
                   Repository. TotalStoredEnergy -= (harvestNeededEnergyForDay * 60) / 100;
                }

               Repository. TotalMinedOre += dayOre;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"A day has passed.");
            sb.AppendLine($"Energy Provided: {dayEnergy}");
            sb.AppendLine($"Plumbus Ore Mined: {dayOre}");

            return sb.ToString().Trim();
        
    }
}

