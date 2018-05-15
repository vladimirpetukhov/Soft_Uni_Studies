using System;
using System.Collections.Generic;
using System.Linq;

public interface ICommandInterpreter
{
    string InterpredCommand(IList<string> arguments,IServiceProvider serviceProvider);
}

