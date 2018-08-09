namespace FastFood.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class FastFoodDbContext : DbContext
	{
		public FastFoodDbContext()
		{
		}

		public FastFoodDbContext(DbContextOptions options)
			: base(options)
		{
		}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items{ get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Position> Positions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
		{
			if (!builder.IsConfigured)
			{
				builder.UseSqlServer(Configuration.ConnectionString);
			}
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.Entity<OrderItem>()
                .HasKey(k => new { k.OrderId, k.ItemId });

            builder.Entity<OrderItem>()
                .HasOne(o => o.Order)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(o => o.OrderId);

            builder.Entity<OrderItem>()
                .HasOne(i => i.Item)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(i => i.ItemId);

            builder.Entity<Employee>()
                .HasAlternateKey(n => n.Name);

            builder.Entity<Item>()
                .HasAlternateKey(n => n.Name);
                
		}
	}
}