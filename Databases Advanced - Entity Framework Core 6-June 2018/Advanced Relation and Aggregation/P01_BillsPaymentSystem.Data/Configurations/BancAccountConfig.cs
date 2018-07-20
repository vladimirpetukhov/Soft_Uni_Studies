namespace P01_BillsPaymentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class BancAccountConfig : IEntityTypeConfiguration<BancAccount>
    {
        public void Configure(EntityTypeBuilder<BancAccount> builder)
        {
            builder.HasOne(p => p.PaymentMethod)
                .WithOne(b => b.BancAccount)
                .HasForeignKey<PaymentMethod>(b => b.BankAccountId);
        }
    }
}
