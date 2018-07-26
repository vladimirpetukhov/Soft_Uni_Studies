namespace Sweetshop.Data.EntityConfig
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(f => f.FirstName)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(l => l.LastName)
                .IsRequired(true)
                .HasMaxLength(30);

            builder.Property(s => s.Salary)
                .IsRequired(true)
                .HasColumnType("decimal(16,2)");

            builder.Property(b => b.Birthday)
                .HasColumnType("datetime2");

            builder.HasOne(m => m.Manager)
                .WithMany(e => e.EmployeeManager)
                .HasForeignKey(m => m.ManagerId);
        }
    }
}
