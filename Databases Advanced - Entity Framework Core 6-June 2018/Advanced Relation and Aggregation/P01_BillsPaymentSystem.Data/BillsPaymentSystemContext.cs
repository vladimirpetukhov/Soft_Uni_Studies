namespace P01_BillsPaymentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    using P01_BillsPaymentSystem.Data.Configurations;

    public class BillsPaymentSystemContext : DbContext
    {
        public const string Path = @"C:\Users\Vlado\source\repos\ConectionString.txt";
        public BillsPaymentSystemContext()
        {

        }
        public BillsPaymentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users{ get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<BancAccount> BancAccounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var conecction = new Conection();
            var conectString = conecction.ConnectionString;

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(conecction.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BancAccountConfig());
            modelBuilder.ApplyConfiguration(new CreditCardConfig());
        }
    }
}
