namespace NeedForSpeed.Core.IO
{
    using System;
    using NeedForSpeed.Interfaces.IO;
    public class ConsoleReader : IReader
    {
        public string ReadData()
        {
            return Console.ReadLine();
        }
    }
}
