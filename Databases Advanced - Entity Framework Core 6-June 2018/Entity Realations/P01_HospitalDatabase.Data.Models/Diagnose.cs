namespace P01_HospitalDatabase.Data.Models
{
    public class Diagnose
    {
        public int DiagnoseId { get; set; }
        public string Name { get; set; }//(up to 50 characters, unicode)
        public string Comments { get; set; }//(up to 250 characters, unicode)

        public int PatientId { get; set; }
        public Patient Patients { get; set; }

    }
}
