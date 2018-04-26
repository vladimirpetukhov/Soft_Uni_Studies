﻿using Logger;
using Logger.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using Logger.Factories;

public class Controller
{
    private IList<IAppender> appenders;
    private AppendFactory appenderFactory;

    public Controller()
    {
        this.appenders = new List<IAppender>();
        this.appenderFactory = new AppendFactory();
    }

    internal void GetAppendersFromConsole()
    {
        var numberOfAppenders = int.Parse(Console.ReadLine());

        while (numberOfAppenders > 0)
        {
            var input = Console.ReadLine().Split();
            var appenderName = input[0];
            var layoutName = input[1];

            var appender = this.appenderFactory.CreateAppender(appenderName, layoutName);

            if (input.Length > 2)
            {
                this.SetLevelThreshold(appender, input[2]);
            }

            this.appenders.Add(appender);
            numberOfAppenders--;
        }
    }

    internal void ExecuteCommands()
    {
        var command = Console.ReadLine().Split('|');

        while (command[0] != "END")
        {
            var reportLevel = command[0];
            var time = command[1];
            var message = command[2];

            foreach (var appender in this.appenders)
            {
                appender.Append(time, reportLevel, message);
            }

            command = Console.ReadLine().Split('|');
        }
    }

    internal void PrintAppenders()
    {
        foreach (var appender in this.appenders)
        {
            Console.WriteLine(appender.ToString().Trim());
        }
    }

    private void SetLevelThreshold(IAppender appender, string thresholdName)
    {
        ReportLevel levelThreshold;
        var isValidLevel = Enum.TryParse(
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(thresholdName.ToLower()),
            out levelThreshold);

        if (isValidLevel)
        {
            appender.ReportLevel = levelThreshold;
        }
    }
}