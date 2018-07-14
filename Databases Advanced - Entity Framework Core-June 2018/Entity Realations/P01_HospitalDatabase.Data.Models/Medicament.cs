using System.Collections.Generic;

namespace P01_HospitalDatabase.Data.Models
{
   public class Medicament
    {
        public Medicament()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
        }

        public int MedicamentId { get; set; }
        public string Name { get; set; }//(up to 50 characters, unicode)
        public ICollection<PatientMedicament> Prescriptions { get; set; }

    }
}
