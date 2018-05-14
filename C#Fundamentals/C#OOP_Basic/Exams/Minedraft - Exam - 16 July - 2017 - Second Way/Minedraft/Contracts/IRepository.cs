using System.Collections.Generic;
public interface IRepository
{
    double TotalStoredEnergy { get; set; }

    string Mode { get; set; }
    double TotalMinedOre { get; set; }
    string AddHarvester(string id, IHarvester unit);

    string AddProvider(string id, IProvider unit);
    IDictionary<string, IHarvester> Harvesters { get; }
    IDictionary<string, IProvider> Providers { get; }

}

