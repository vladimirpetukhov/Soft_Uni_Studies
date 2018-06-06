namespace Second_Way
{
    using System;
    using Contracts;
    using Core;
    using Core.Data;
    using Microsoft.Extensions.DependencyInjection;
    using Core.Factory;
    using System.Collections.Generic;
    public class Startup
    {
        public static void Main()
        {
           
            IList<IStudent> students = new List<IStudent>();
            IRepository repository = new Repository(students);
            
            ICommandInterpreter commandInterpreter = new CommandInterpreter(repository);
            IEngine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        
    }
}
