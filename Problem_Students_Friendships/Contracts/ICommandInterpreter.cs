namespace Second_Way.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpredCommand(string[] arguments);
    }
}
