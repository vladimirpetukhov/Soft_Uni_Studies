namespace FestivalManager
{
    using Core;
    using Core.Controllers;
    using Core.Controllers.Contracts;
    using Core.IO;
    using Core.IO.Contracts;
    using Entities;
    using Entities.Contracts;
    using Entities.Factories;
    using Entities.Factories.Contracts;

    public static class StartUp
    {
        public static void Main(string[] args)
        {
            IPerformerFactory performerFactory = new PerformerFactory();
            ISetFactory setFactory = new SetFactory();
            ISongFactory songFactory = new SongFactory();
            IInstrumentFactory instrumentFactory = new InstrumentFactory();

            IStage stage = new Stage();
            IFestivalController festivalController = new FestivalController(stage, instrumentFactory, performerFactory, songFactory, setFactory);
            ISetController setController = new SetController(stage);

            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            var engine = new Engine(reader, writer, festivalController, setController);

            engine.Run();
        }
    }
}