namespace Second_Way.Core
{
    using System;
    using Contracts;
    using System.Text;
    public class Writer : IWriter
    {
        private readonly StringBuilder sb;
       

        public Writer()
        {
            this.sb = new StringBuilder();
        }

        public string StoredMessage => this.sb.ToString().Trim();

        public void StoreMessage(string message)
        {
            this.sb.AppendLine(message.Trim());
        }

        public void WriteLine(string output)
        {
            Console.WriteLine(output);
            sb.Clear();
        }
    }
}
