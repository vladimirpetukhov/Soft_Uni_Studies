namespace Sweetshop.App
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using AutoMapper;

    using Data;
    using Service;
    using Service.Contracts;
    using Core;
    using Core.IO;
    using Core.Contracts;
    using Core.Controlers;

    public class Startup
    {
       public static void Main()
        {
            var service = ConfigureServices();
            var reader = new ConsoleReader();
            var engine = new Engine(service);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<SweetshopContext>(cfg => cfg.UseSqlServer(Configuration.ConnectionString));

            services.AddAutoMapper(cfg => cfg.AddProfile<SweetshopProfile>());

            services.AddTransient<IReader, ConsoleReader>();

            services.AddTransient<IDbInitialise, DbInitialise>();

            services.AddTransient<IController, EmployeeController>();

            services.AddTransient<ICommandInterpreter, CommandInterpreter>();

            return services.BuildServiceProvider();
        }
    }
}
