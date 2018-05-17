namespace NeedForSpeed.Interfaces.CommandBox
{
    using System.Collections.Generic;

    public interface ICommandInterpreter
    {
        string ReturnCommand(IList<string> commandArgs);
    }
}
