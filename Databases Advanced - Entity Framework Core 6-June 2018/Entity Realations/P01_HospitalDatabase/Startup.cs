namespace P01_HospitalDatabase
{
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Data;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            using (HospitalContext context = new HospitalContext())
            {
                var name = context.Patients.Include(f => f.Prescriptions);

                var last = context.Patients.Select(l => l.LastName);

                foreach (var item in name)
                {
                    System.Console.WriteLine(item.FirstName);
                }
                foreach (var item in last)
                {
                    System.Console.WriteLine(item);
                }
                
            }
        }
    }
}
