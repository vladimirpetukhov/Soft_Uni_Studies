using System.Collections.Generic;

public abstract class UnitFactory : IFactory
{
    public abstract IUnit CreateUnit(IList<string> arguments);
}

