using System;
public class SonicHarvester : Harvester
{
    [SonicHarvester]
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get => this.sonicFactor;
        private set => this.sonicFactor = value;
    }
}
