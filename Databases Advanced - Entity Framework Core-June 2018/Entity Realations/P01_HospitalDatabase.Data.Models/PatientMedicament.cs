namespace P01_HospitalDatabase.Data.Models
{
   public class PatientMedicament
    {
        public int PatientId { get; set; }
        public Patient Patients { get; set; }

        public int MedicamentId { get; set; }
        public Medicament Medicaments { get; set; }
    }
}
