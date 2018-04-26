namespace FestivalManager.Core
{
    using Contracts;
    using Controllers.Contracts;
    using IO.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFestivalController festivalController;
        private readonly ISetController setController;

        public Engine(IReader reader, IWriter writer, IFestivalController festivalController, ISetController setController)
        {
            this.reader = reader;
            this.writer = writer;
            this.festivalController = festivalController;
            this.setController = setController;
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Trim();

                if (input == "END")
                    break;

                try
                {
                    string.Intern(input);

                    var result = this.ProcessCommand(input);
                    this.writer.WriteLine(result);
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine("ERROR: " + ex.InnerException.Message);
                }
            }

            var end = this.festivalController.ProduceReport();

            this.writer.WriteLine("Results:");
            this.writer.WriteLine(end);
        }

        public string ProcessCommand(string input)
        {
            var inputArgs = input.Split(" ".ToCharArray().First());

            var first = inputArgs.First();
            var parameters = inputArgs.Skip(1).ToArray();

            if (first == "LetsRock")
            {
                var sets = this.setController.PerformSets();
                return sets;
            }

            var festivalcontrolfunction = this.festivalController.GetType()
                .GetMethods()
                .FirstOrDefault(x => x.Name == first);

            var a = (string)festivalcontrolfunction.Invoke(this.festivalController, new object[] { parameters });

            return a;
        }
    }
}