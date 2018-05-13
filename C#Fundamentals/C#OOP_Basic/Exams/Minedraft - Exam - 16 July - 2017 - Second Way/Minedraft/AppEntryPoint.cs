namespace Minedraft
{
    using System.Collections.Generic;
    public class AppEntryPoint
    {
        public static void Main()
        {
            IDictionary<string, IHarvester> harvester = new Dictionary<string, IHarvester>();
            IDictionary<string, IProvider> providers = new Dictionary<string, IProvider>();
            
            IRepository repository = new Repository(harvester,providers);


            Engine engine = new Engine(repository);
            engine.Run();
        }
    }
}
