namespace Logger.Layouts
{
    using Interfaces;
    using System;

    public class SimpleLayout : ILayout
    {
            public string FormatReport(string datetime, string reportLevel, string message)
                => $"{datetime} - {reportLevel} - {message}";
    }
}
