namespace FestivalManager.Core.Controllers
{
    using Contracts;
    using Entities.Contracts;
    using Entities.Factories.Contracts;
    using System;
    using System.Linq;

    public class FestivalController : IFestivalController
    {
        private const string TimeFormat = "mm\\:ss";

        private readonly IStage stage;
        private readonly IInstrumentFactory instrumentFactory;
        private readonly IPerformerFactory performerFactory;
        private readonly ISongFactory songFactory;
        private readonly ISetFactory setFactory;

        public FestivalController(IStage stage, IInstrumentFactory instrumentFactory, IPerformerFactory performerFactory, ISongFactory songFactory, ISetFactory setFactory)
        {
            this.stage = stage;
            this.instrumentFactory = instrumentFactory;
            this.performerFactory = performerFactory;
            this.songFactory = songFactory;
            this.setFactory = setFactory;
        }

        private string Report()
        {
            var result = string.Empty;

            var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

            if (totalFestivalLength.Hours > 0)
            {
                result += ($"Festival length: {string.Format("{0}:{1:00}", totalFestivalLength.TotalMinutes, totalFestivalLength.Seconds)}") + "\n";

            }
            else
            {
                result += ($"Festival length: {totalFestivalLength.ToString(TimeFormat)}") + "\n";
            }

            foreach (var set in this.stage.Sets)
            {
                if (set.ActualDuration.Hours > 0)
                {
                    result += ($"--{set.Name} ({string.Format("{0}:{1:00}", set.ActualDuration.TotalMinutes, set.ActualDuration.Seconds)}):") + "\n";

                }
                else
                {
                    result += ($"--{set.Name} ({set.ActualDuration.ToString(TimeFormat)}):") + "\n";

                }

                var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
                foreach (var performer in performersOrderedDescendingByAge)
                {
                    var instruments = string.Join(", ", performer.Instruments
                        .OrderByDescending(i => i.Wear));

                    result += ($"---{performer.Name} ({instruments})") + "\n";
                }

                if (!set.Songs.Any())
                    result += ("--No songs played") + "\n";
                else
                {
                    result += ("--Songs played:") + "\n";
                    foreach (var song in set.Songs)
                    {
                        result += ($"----{song.Name} ({song.Duration.ToString(TimeFormat)})") + "\n";
                    }
                }
            }

            return result.Trim();
        }

        public string ProduceReport()
        {
            return this.Report();
        }

        public string RegisterSet(string[] args)
        {
            var name = args[0];
            var type = args[1];

            var performer = this.setFactory.CreateSet(name, type);
            this.stage.AddSet(performer);

            return $"Registered {type} set";
        }

        public string SignUpPerformer(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);

            var instrumentsArgs = args.Skip(2).ToArray();

            var currentInstruments = instrumentsArgs
                .Select(i => this.instrumentFactory.CreateInstrument(i))
                .ToArray();

            var performer = this.performerFactory.CreatePerformer(name, age);

            foreach (var instrument in currentInstruments)
            {
                performer.AddInstrument(instrument);
            }

            this.stage.AddPerformer(performer);

            return $"Registered performer {performer.Name}";
        }

        public string RegisterSong(string[] args)
        {
            var name = args[0];
            var duration = args[1].Split(':').ToList();
            var minutes = int.Parse(duration[0]);
            var seconds = int.Parse(duration[1]);
            var timespan = new TimeSpan(0, 0, minutes, seconds);


            var song = this.songFactory.CreateSong(name, timespan);
            this.stage.AddSong(song);

            return $"Registered song {song.Name} ({song.Duration.ToString(TimeFormat)})";
        }

        public string AddSongToSet(string[] args)
        {
            var songName = args[0];
            var setName = args[1];

            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            if (!this.stage.HasSong(songName))
            {
                throw new InvalidOperationException("Invalid song provided");
            }

            var set = this.stage.GetSet(setName);
            var song = this.stage.GetSong(songName);

            set.AddSong(song);

            return $"Added {song.Name} ({song.Duration.ToString(TimeFormat)}) to {set.Name}";
        }

        public string AddPerformerToSet(string[] args)
        {
            var performerName = args[0];
            var setName = args[1];

            if (!this.stage.HasPerformer(performerName))
            {
                throw new InvalidOperationException("Invalid performer provided");
            }
            if (!this.stage.HasSet(setName))
            {
                throw new InvalidOperationException("Invalid set provided");
            }

            var set = this.stage.GetSet(setName);
            var performer = this.stage.GetPerformer(performerName);

            set.AddPerformer(performer);

            return $"Added {performer.Name} to {set.Name}";
        }

        public string RepairInstruments(string[] args)
        {
            var instrumentsToRepair = this.stage.Performers
                .SelectMany(p => p.Instruments)
                .Where(i => i.Wear < 100)
                .ToArray();

            foreach (var instrument in instrumentsToRepair)
            {
                instrument.Repair();
            }

            return $"Repaired {instrumentsToRepair.Length} instruments";
        }
    }
}