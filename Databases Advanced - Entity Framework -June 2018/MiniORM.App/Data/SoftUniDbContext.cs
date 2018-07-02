namespace MiniORM.App.Data
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using Entities;
    public class SoftUniDbContext:DbContext
    {
        public SoftUniDbContext(string connectionString) : base(connectionString)
        {
        }
        
        public DbSet<Employee> Employees { get; }
        public DbSet<Department> Departments { get; }
        public DbSet<EmployeeProject> EmployeesProjects { get; }

        public DbSet<Project> Projects { get; }
    }
}
