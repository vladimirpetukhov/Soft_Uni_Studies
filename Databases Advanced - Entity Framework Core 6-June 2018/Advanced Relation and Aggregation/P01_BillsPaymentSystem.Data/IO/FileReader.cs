namespace P01_BillsPaymentSystem.Data.IO
{
    using System.IO;

    public class FileReader
    {
       public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
