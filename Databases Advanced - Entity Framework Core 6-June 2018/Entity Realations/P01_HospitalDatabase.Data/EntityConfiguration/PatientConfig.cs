namespace P01_HospitalDatabase.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(k => k.PatientId);
            builder.Property(n => n.FirstName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(l => l.LastName)
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(a => a.Address)
                .HasMaxLength(250)
                .IsUnicode();

            builder.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patients)
                .HasForeignKey(p => p.PatientId);

            builder.HasMany(v => v.Visitations)
                .WithOne(p => p.Patients)
                .HasForeignKey(p => p.PatientId);

            builder.HasMany(d => d.Diagnoses)
                .WithOne(p => p.Patients)
                .HasForeignKey(p => p.PatientId);
                                      
        }
    }
}
