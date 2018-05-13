using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{


    private DraftManager draftManager;
    private bool IsRunning = true;
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;
    private IRepository repository;

    public Engine(IRepository repository)
    {
        this.draftManager = new DraftManager();
        this.reader = new Reader();
        this.writer = new Writer();
        this.commandInterpreter = new CommandInterpreter();
        this.Repository = repository;
    }

    public IRepository Repository
    {
        get { return this.repository; }
        set { this.repository = value; }
    }

    public void Run()
    {

        while (IsRunning)
        {
            string inputCommand = reader.ReadInput();
            var commandParameters = this.ParseInput(inputCommand);
            string result = commandInterpreter.InterpredCommand(commandParameters,repository);
            string gatherOutput=writer.AppendToGatherOutput(result);
            writer.WriteGatherOutput(gatherOutput);
        }

    }

    //private void DistributeCommand(List<string> commandParameters)
    //{
    //    string command = commandParameters[0];
    //    commandParameters = commandParameters.Skip(1).ToList();

    //    switch (command)
    //    {
    //        case "RegisterHarvester":
    //            OutputWriter(this.draftManager.RegisterHarvester(commandParameters));
    //            break;
    //        case "RegisterProvider":
    //            OutputWriter(this.draftManager.RegisterProvider(commandParameters));
    //            break;
    //        case "Day":
    //            OutputWriter(this.draftManager.Day());
    //            break;
    //        case "Mode":
    //            OutputWriter(this.draftManager.Mode(commandParameters));
    //            break;
    //        case "Check":
    //            string status = this.draftManager.Check(commandParameters);
    //            this.OutputWriter(status);
    //            break;
    //        case "Shutdown":
    //            string record = this.draftManager.ShutDown();
    //            this.OutputWriter(record);
    //            this.isRunning = false;
    //            break;
    //    }
    //}



    private IList<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }


}

