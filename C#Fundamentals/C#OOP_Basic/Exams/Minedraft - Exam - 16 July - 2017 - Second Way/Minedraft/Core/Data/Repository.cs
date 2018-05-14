using System.Collections.Generic;
using System.Reflection;
using System;
public class Repository : IRepository
{
    private IDictionary<string, IHarvester> harvesters;
    private IDictionary<string, IProvider> providersr;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private string mode;


    public Repository(IDictionary<string, IHarvester> harvesters, IDictionary<string, IProvider> providers)
    {
        this.Harvesters = harvesters;
        this.Providers = providers;
        this.totalStoredEnergy = 0;
        this.totalMinedOre = 0;
        this.Mode ="Full";
    }

    public IDictionary<string, IHarvester> Harvesters
    {
        get { return harvesters; }
        set { harvesters = value; }
    }
    public IDictionary<string, IProvider> Providers
    {
        get { return providersr; }
        set { providersr = value; }
    }

    public double TotalStoredEnergy
    {
        get { return this.totalStoredEnergy; }
        set { this.totalStoredEnergy = value; }
    }
    public double TotalMinedOre
    {
        get { return this.totalMinedOre; }
        set { this.totalMinedOre = value; }
    }

    public string Mode
    {
        get { return this.mode; }
         set { this.mode = value; }
    }

    public string AddHarvester(string id, IHarvester unit)
    {
        if (!(this.Harvesters.ContainsKey(id)))
        {
            this.Harvesters.Add(id, unit);
        }
        return "Successfully registered {0} Harvester - {1}";
    }
    public string AddProvider(string id, IProvider unit)
    {
        if (!(this.Providers.ContainsKey(id)))
        {
            this.Providers.Add(id, unit);
        }
        return "Successfully registered {0} Provider - {1}";
    }




}

