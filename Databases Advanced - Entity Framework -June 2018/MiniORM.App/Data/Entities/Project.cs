namespace MiniORM.App.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    public class Project
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<EmployeeProject> EmployeeProject { get;}
    }
}
