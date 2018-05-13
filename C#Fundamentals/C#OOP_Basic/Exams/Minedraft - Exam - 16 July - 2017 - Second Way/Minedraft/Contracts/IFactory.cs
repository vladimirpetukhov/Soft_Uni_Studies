using System.Collections.Generic;

public interface IFactory
{
    IUnit CreateUnit(IList<string> arguments);
}

