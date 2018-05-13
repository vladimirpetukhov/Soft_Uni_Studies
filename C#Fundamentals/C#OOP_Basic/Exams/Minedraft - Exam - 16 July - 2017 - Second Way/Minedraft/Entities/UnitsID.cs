public abstract class UnitsID:IUnit
{
    private string id;

    protected UnitsID(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
    }
}

