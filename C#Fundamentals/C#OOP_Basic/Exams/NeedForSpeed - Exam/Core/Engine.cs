using System;
using System.Collections.Generic;
using System.Linq;
using NeedForSpeed.Interfaces;
using NeedForSpeed.Interfaces.CommandBox;
using System.Reflection;
using NeedForSpeed.Interfaces.IO;
using NeedForSpeed.Core.IO;
using NeedForSpeed.Core.Attributes;
public class Engine
{


    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;
    //private IServiceProvider serviceProvider;

    public Engine(ICommandInterpreter command)
    {

        this.commandInterpreter = command;
        //this.serviceProvider = serviceProvider;
        this.reader = new ConsoleReader();
        this.writer = new ConsoleWrite();

    }

    public void Run()
    {
        string inputCommand;
        while ((inputCommand = reader.ReadData()) != "Cops Are Here")
        {
            var commandArgs = ParseInput(inputCommand);
            var methodName = commandArgs[0];
            var result=commandInterpreter.ReturnCommand(commandArgs);
            if (result == null)
            {
                continue;
            }
            writer.ConsoleWriter(result);
            
        }
    }

    private void DistributeCommands(List<string> commandArgs)
    {
        var command = commandArgs[0];
        commandArgs = commandArgs.ToList();

        //switch (command)
        //{
        //    case "register":
        //        var id = int.Parse(commandArgs[1]);
        //        var type = commandArgs[2];
        //        var brand = commandArgs[3];
        //        var model = commandArgs[4];
        //        var year = int.Parse(commandArgs[5]);
        //        var horsepower = int.Parse(commandArgs[6]);
        //        var acceleration = int.Parse(commandArgs[7]);
        //        var suspension = int.Parse(commandArgs[8]);
        //        var durability = int.Parse(commandArgs[9]);
        //        this.Manager.Register(id, type, brand, model, year, horsepower, acceleration, suspension, durability);
        //        break;
        //    case "check":
        //        OutputWriter(this.Manager.Check(int.Parse(commandArgs[1])));
        //        break;
        //    case "open":
        //        var idRace = int.Parse(commandArgs[1]);
        //        var raceType = commandArgs[2];
        //        var length = int.Parse(commandArgs[3]);
        //        var route = commandArgs[4];
        //        var prizePool = int.Parse(commandArgs[5]);

        //        if (commandArgs.Count > 6)
        //        {
        //            var extraParam = int.Parse(commandArgs[6]);
        //            this.Manager.Open(idRace, raceType, length, route, prizePool, extraParam);
        //        }
        //        else
        //        {
        //            this.Manager.Open(idRace, raceType, length, route, prizePool);
        //        }
        //        break;
        //    case "participate":
        //        var carId = int.Parse(commandArgs[1]);
        //        var raceId = int.Parse(commandArgs[2]);
        //        this.Manager.Participate(carId, raceId);
        //        break;
        //    case "start":
        //        OutputWriter(this.Manager.Start(int.Parse(commandArgs[1])));
        //        break;
        //    case "park":
        //        this.Manager.Park(int.Parse(commandArgs[1]));
        //        break;
        //    case "unpark":
        //        this.Manager.Unpark(int.Parse(commandArgs[1]));
        //        break;
        //    case "tune":
        //        this.Manager.Tune(int.Parse(commandArgs[1]), commandArgs[2]);
        //        break;
        //}
    }

    private void OutputWriter(string message) => Console.WriteLine(message);

    private List<string> ParseInput(string inputCommand)
    {
        return inputCommand
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .ToList();
    }
}
