namespace NeedForSpeed.Core.IO
{
    using System;
    using NeedForSpeed.Interfaces.IO;
    public class ConsoleWrite : IWriter
    {
       public void ConsoleWriter(string gatherOutput)
        {
            Console.WriteLine(gatherOutput);
        }
    }
}
