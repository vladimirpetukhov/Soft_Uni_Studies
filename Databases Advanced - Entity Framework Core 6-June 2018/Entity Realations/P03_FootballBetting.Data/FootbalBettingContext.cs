namespace P03_FootballBetting.Data
{
    
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Configurations;
    
    public class FootballBettingContext:DbContext
    {
        public FootballBettingContext()
        {
                
        }
        public FootballBettingContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(Connection.ConectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TeamConfig());
            builder.ApplyConfiguration(new ColorConfig());
            builder.ApplyConfiguration(new TownConfig());
            builder.ApplyConfiguration(new CountryConfig());
            builder.ApplyConfiguration(new PlayerConfig());
            builder.ApplyConfiguration(new PositionConfig());
            builder.ApplyConfiguration(new PlayerStatisticConfig());
            builder.ApplyConfiguration(new GameConfig());
            builder.ApplyConfiguration(new BetConfig());
            builder.ApplyConfiguration(new UserConfig());
        }
    }
}
