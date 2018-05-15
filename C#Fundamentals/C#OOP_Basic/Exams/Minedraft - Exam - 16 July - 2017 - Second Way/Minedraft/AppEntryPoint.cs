namespace Minedraft
{
    using System.Collections.Generic;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    public class AppEntryPoint
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();
            IDictionary<string, IHarvester> harvester = new Dictionary<string, IHarvester>();
            IDictionary<string, IProvider> providers = new Dictionary<string, IProvider>();
            
            IRepository repository = new Repository(harvester,providers);


            Engine engine = new Engine(serviceProvider);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection serviceBag = new ServiceCollection();

            serviceBag.AddTransient<IFactory, HarvesterFactory>();
            serviceBag.AddTransient<IFactory, ProviderFactory>();
            serviceBag.AddSingleton<IRepository, Repository>();
            

            IServiceProvider serviceProvider = serviceBag.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
