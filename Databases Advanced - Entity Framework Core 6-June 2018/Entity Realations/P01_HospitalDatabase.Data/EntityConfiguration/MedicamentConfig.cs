namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;

    public class MedicamentConfig : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(k => k.MedicamentId);

            builder.Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.HasMany(p => p.Prescriptions)
                .WithOne(m => m.Medicaments)
                .HasForeignKey(m => m.MedicamentId);
        }
    }
}
