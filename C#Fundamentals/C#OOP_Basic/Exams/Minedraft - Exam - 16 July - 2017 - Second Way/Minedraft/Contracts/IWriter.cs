using System;
using System.Text;

public interface IWriter
{
    
    string AppendToGatherOutput(string gatheredOutput);

    void WriteGatherOutput(string result);
}

