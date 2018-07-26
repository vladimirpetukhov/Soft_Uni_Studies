namespace Sweetshop.App.Core.Contracts
{
    public interface ICommandInterpreter
    {
        ICommand InterpretCommand(string[] args,string name);
    }
}
