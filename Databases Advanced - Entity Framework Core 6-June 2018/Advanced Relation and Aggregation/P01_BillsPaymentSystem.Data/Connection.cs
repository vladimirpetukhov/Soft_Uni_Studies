namespace P01_BillsPaymentSystem.Data
{
    using System.IO;
    using IO;

    public class Conection
    {
        private const string Path = @"C:\Users\Vlado\source\repos\ConectionString.txt";
        private const string Test = @"C:\Users\Vlado\source\repos\somefile.txt";
        private FileReader reader;
        //private FileReadAllLines fileReadAllLines;

        public Conection()
        {
            this.reader = new FileReader();
            //this.fileReadAllLines = new FileReadAllLines();
            this.ConnectionString = reader.Read(Path);
            //this.ConnectionString = fileReadAllLines.Read(Test);
        }
        public string ConnectionString { get;private set; }
        

    }

}

