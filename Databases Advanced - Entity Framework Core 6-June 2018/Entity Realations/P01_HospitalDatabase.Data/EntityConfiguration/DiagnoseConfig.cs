namespace P01_HospitalDatabase.Data.Models
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DiagnoseConfig : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder.HasKey(k => k.DiagnoseId);

            builder.Property(n => n.Name)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(c => c.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            

            //FK
        }
    }
}
