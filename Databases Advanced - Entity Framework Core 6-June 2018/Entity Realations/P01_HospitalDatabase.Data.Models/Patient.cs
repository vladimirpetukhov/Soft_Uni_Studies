namespace P01_HospitalDatabase.Data.Models
{
    using System.Collections.Generic;
    public class Patient
    {
        public Patient()
        {
            this.Prescriptions = new HashSet<PatientMedicament>();
            this.Diagnoses = new HashSet<Diagnose>();
            this.Visitations = new HashSet<Visitation>();
        }
        public int PatientId { get; set; }
        public string FirstName { get; set; }//(up to 50 characters, unicode)
        public string LastName { get; set; }//(up to 50 characters, unicode)
        public string Address { get; set; }//(up to 250 characters, unicode)
        public string Email { get; set; }//(up to 80 characters, not unicode)
        public bool HasInsurance { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; }
        public ICollection<Diagnose> Diagnoses { get; set; }
        public ICollection<Visitation> Visitations { get; set; }



    }
}
