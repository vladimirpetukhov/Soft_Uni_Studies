namespace P01_BillsPaymentSystem.Data.IO
{
    public class ConsoleReader : IReader
    {
        public string Read(string path)
        {
            return System.Console.ReadLine();
        }
    }
}
