namespace Sweetshop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    
    public class Employee
    {
        public Employee()
        {
            this.EmployeeManager = new List<Employee>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName =("decimal(16,2)"))]
        public decimal Salary { get; set; }

        public DateTime? Birthday { get; set; }

        [MaxLength(255)]
        public string Adress { get; set; }

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> EmployeeManager { get; set; }
       
    }
}
