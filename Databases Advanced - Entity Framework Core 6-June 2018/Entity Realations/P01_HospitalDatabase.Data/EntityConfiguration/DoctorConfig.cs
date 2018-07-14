namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class DoctorConfig : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(i => i.DoctorId);

            builder.Property(n => n.Name)
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(s => s.Speciality)
                .HasMaxLength(100)
                .IsUnicode();

            builder.HasMany(v => v.Visitations)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);


        }
    }
}
