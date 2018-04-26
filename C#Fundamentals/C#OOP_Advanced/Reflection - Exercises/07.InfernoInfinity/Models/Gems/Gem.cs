namespace _07.InfernoInfinity.Models.Gems
{
    using Contracts;
    using Enums;

    public abstract class Gem : IGem
{
    private const int MinBonusStrength = 2;
    private const int MaxBonusStrength = 3;
        
    private const int MinBonusAgility = 1;
    private const int MaxBonusAgility = 4;
        
    private readonly int strength;
    private readonly int agility;
    private readonly int vitality;
    private readonly GemClarity clarity;
        
    protected Gem(GemClarity clarity, int strength, int agility, int vitality)
    {
        this.clarity = clarity;
        this.strength = strength;
        this.agility = agility;
        this.vitality = vitality;
    }

    public int Strength => this.strength + (int)this.clarity;

    public int Agility => this.agility + (int)this.clarity;

    public int Vitality => this.vitality + (int)this.clarity;
        

    public int AddBonusToMinDamage()
    {
        return (MinBonusStrength * this.Strength) + (MinBonusAgility * this.Agility);
    }

    public int AddBonusToMaxDamage()
    {
        return (MaxBonusStrength * this.Strength) + (MaxBonusAgility * this.Agility);
    }
    }
}
