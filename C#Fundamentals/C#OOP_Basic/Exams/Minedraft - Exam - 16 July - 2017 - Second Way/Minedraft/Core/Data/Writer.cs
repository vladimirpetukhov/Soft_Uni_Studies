using System;
using System.Text;


public class Writer : IWriter
{
    

    public Writer()
    {
        this.GatherOutput = new StringBuilder();
    }

    public StringBuilder GatherOutput
    {
        get;
        private set;
    }
    

    public string AppendToGatherOutput(string gatheredOutput)
    {
       return this.GatherOutput.AppendLine(gatheredOutput)
            .ToString()
            .Trim();
                
    }

    

    public void WriteGatherOutput(string result)
    {
        Console.Write(this.GatherOutput);
    }
}

