using MiniORM.App.Data;
using System.Collections.Generic;
using System.Linq;

namespace MiniORM.App
{
    using Data.Entities;
    public class Startup
    {
        public static void Main()
        {
            const string connectionString = "Server=DESKTOP-8DBTK91\\SQLEXPRESS02;Database=MiniORM;Integrated Security=True";
            var context = new SoftUniDbContext(connectionString);

            context.Employees.Add(new Employee
            {
                FirstName = "Traiko",
                LastName = "Peshov",
                DepartmentId = context.Departments.First().Id,
                IsEmployeed=true
            });
            context.SaveChanges();
        }
    }
}
