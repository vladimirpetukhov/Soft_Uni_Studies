namespace P01_BillsPaymentSystem.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CreditCardConfig : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasOne(p => p.PaymentMethod)
                .WithOne(c => c.CreditCard)
                .HasForeignKey<PaymentMethod>(c => c.CreditCardId);
        }
    }
}
