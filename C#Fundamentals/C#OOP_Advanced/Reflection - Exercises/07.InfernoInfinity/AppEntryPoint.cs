namespace _07.InfernoInfinity
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class AppEntryPoint
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IWeaponFactory, WeaponFactory>();
            services.AddTransient<IGemFactory, GemFactory>();
            services.AddSingleton<IRepository, Repository>();

            return services.BuildServiceProvider();
        }
    }
}
