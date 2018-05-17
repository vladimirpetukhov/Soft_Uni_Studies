namespace NeedForSpeed
{
    using Interfaces;
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using NeedForSpeed.Interfaces.CommandBox;

    public class StartUp
    {
        public static void Main()
        {
            

            

            
            IRaceFactory raceFactory = new RaceFactory();
            ICarFactory carFactory = new CarFactory();
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            Engine engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<ICar, Car>();
            services.AddTransient<ICarFactory, CarFactory>();
            services.AddTransient<IRaceFactory, RaceFactory>();
            services.AddSingleton<ICarManager, CarManager>();
            services.AddSingleton<IGarage, Garage>();
            


            return services.BuildServiceProvider();
        }
    }
}
