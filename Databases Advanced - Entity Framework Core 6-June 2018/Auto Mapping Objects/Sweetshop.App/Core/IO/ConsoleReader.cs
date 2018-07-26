namespace Sweetshop.App.Core.IO
{
    using System;
    using System.Linq;
    using Contracts;

    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }

    }
}
