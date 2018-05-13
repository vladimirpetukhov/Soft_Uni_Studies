public interface ICommand:IExecute
{
    IRepository Repository { get; }
    IFactory Factory { get; }
}

