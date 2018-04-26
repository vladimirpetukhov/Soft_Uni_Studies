﻿namespace Logger.Appenders
{
    using Interfaces;
    using System;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(string datetime, string reportLevel, string message)
        {
            if (this.IsMessageValidLevel(reportLevel))
            {
                Console.WriteLine(this.Layout.FormatReport(datetime, reportLevel, message));
                this.MessagesCount++;
            }
        }
    }
}
