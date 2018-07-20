namespace CommandInterpreter
{
    using Contracts;
    using P01_BillsPaymentSystem.Data;

    public abstract class Command : ICommand
    {
        public abstract void PopulateTable(BillsPaymentSystemContext context, string table);
        
    }
}
