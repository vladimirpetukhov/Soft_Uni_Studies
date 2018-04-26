namespace FestivalManager.Entities.Factories
{
    using Contracts;
    using Entities.Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class SongFactory : ISongFactory
    {
        public ISong CreateSong(string name, TimeSpan duration)
        {
            var type = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == "Song");

            return (ISong)Activator.CreateInstance(type, name, duration);
        }
    }
}