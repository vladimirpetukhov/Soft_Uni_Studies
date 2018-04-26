namespace Logger
{
    using Interfaces;
    using System.Linq;
    using System.Text;

    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size { get; private set; }

        public void Write(string message)
        {
            this.sb.AppendLine(message);

            this.Size += message
                .Where(char.IsLetter)
                .Sum(c => c);
        }

        public override string ToString()
        {
            return this.sb.ToString().Trim();
        }
    }
}
