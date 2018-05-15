using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{


    private IServiceProvider serviceProvider;
    private bool IsRunning = true;
    private IReader reader;
    private IWriter writer;
    private ICommandInterpreter commandInterpreter;
    private IRepository repository;

    public Engine(IServiceProvider service)
    {

        this.reader = new Reader();
        this.writer = new Writer();
        this.commandInterpreter = new CommandInterpreter();
        this.serviceProvider = service;
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

            string result = commandInterpreter.InterpredCommand(commandParameters, serviceProvider);

            writer.WriteGatherOutput(result);

            if (inputCommand == "Shutdown")
            {
                Environment.Exit(0);
            }

        }

    }


    private IList<string> ParseInput(string inputCommand)
    {
        return inputCommand.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }


}

