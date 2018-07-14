namespace P01_HospitalDatabase.Data
{
    using Microsoft.EntityFrameworkCore;
    using Models;
    using P01_HospitalDatabase.Data.EntityConfiguration;

    public class HospitalContext : DbContext
    {
        public HospitalContext() { }
        public HospitalContext(DbContextOptions options):base(options) { }

        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Patient>  Patients { get; set; }
        public DbSet<PatientMedicament> Prescriptions { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new MedicamentConfig());
            builder.ApplyConfiguration(new PatientConfig());
            builder.ApplyConfiguration(new DiagnoseConfig());
            builder.ApplyConfiguration(new VisitationConfig());
            builder.ApplyConfiguration(new PatientMedicamentConfig());
            builder.ApplyConfiguration(new DoctorConfig());
            
        }
    }
}
