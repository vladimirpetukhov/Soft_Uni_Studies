namespace FestivalManager.Entities
{
    using Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class Stage : IStage
    {
        private readonly List<ISet> sets;
        private readonly List<ISong> songs;
        private readonly List<IPerformer> performers;

        public Stage()
        {
            this.sets = new List<ISet>();
            this.songs = new List<ISong>();
            this.performers = new List<IPerformer>();
        }

        public IReadOnlyCollection<ISet> Sets => this.sets;

        public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();

        public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

        public IPerformer GetPerformer(string name)
        {
            var performer = this.performers.FirstOrDefault(t => t.Name == name);

            return performer;
        }

        public ISong GetSong(string name)
        {
            var song = this.songs.FirstOrDefault(t => t.Name == name);

            return song;
        }

        public ISet GetSet(string name)
        {
            var set = this.sets.FirstOrDefault(t => t.Name == name);

            return set;
        }

        public void AddPerformer(IPerformer performer)
        {
            this.performers.Add(performer);
        }

        public void AddSong(ISong song)
        {
            this.songs.Add(song);
        }

        public void AddSet(ISet performer)
        {
            this.sets.Add(performer);
        }

        public bool HasPerformer(string name)
        {
            var performer = this.performers
                .FirstOrDefault(t => t.Name == name);

            if (performer == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSong(string name)
        {
            var song = this.songs
                .FirstOrDefault(t => t.Name == name);

            if (song == null)
            {
                return false;
            }

            return true;
        }

        public bool HasSet(string name)
        {
            var set = this.sets
                .FirstOrDefault(s => s.Name == name);

            if (set == null)
            {
                return false;
            }

            return true;
        }
    }
}
