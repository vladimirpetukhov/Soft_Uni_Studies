namespace Logger.Layouts
{
    using Interfaces;
    using System.Text;

    public class XmlLayout : ILayout
    {
        public string FormatReport(string datetime, string reportLevel, string message)
        {
            var report = new StringBuilder();

            report.AppendLine("<log>")
                .Append('\t')
                .Append("<date>")
                .Append(datetime)
                .Append("</date>")
                .AppendLine()
                .Append('\t')
                .Append("<level>")
                .Append(reportLevel)
                .Append("</level>")
                .AppendLine()
                .Append('\t')
                .Append("<message>")
                .Append(message)
                .Append("</message>")
                .AppendLine()
                .AppendLine("</log>");

            return report.ToString().Trim();
        }
    }
}
