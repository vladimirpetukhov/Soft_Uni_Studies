namespace MiniORM.App.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Department
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Employee> Employees { get; }
    }
}
