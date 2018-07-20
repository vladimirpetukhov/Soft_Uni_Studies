namespace P01_BillsPaymentSystem.Data.IO
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FileReadAllLines : IReader
    {
        public string Read(string path)
        {
            var sb = new StringBuilder();
            
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while (sr.ReadLine() != null)
                    {
                        line = sr.ReadLine();
                        sb.AppendLine(line);
                    }
                                       
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return sb.ToString().Trim();
        }
    }
}
