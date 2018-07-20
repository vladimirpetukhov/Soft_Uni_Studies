namespace CommandInterpreter.Contracts
{
    using P01_BillsPaymentSystem.Data;

    interface ICommand
    {
        void PopulateTable(BillsPaymentSystemContext context, string table);
    }
}
