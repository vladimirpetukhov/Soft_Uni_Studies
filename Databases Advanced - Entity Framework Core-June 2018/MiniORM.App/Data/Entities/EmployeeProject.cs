
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniORM.App.Data.Entities
{
    public class EmployeeProject
    {
        [Key]
        [ForeignKey(nameof(Entities.Employee))]
        public int EmployeeId { get; set; }
        [Key]
        [ForeignKey(nameof(Entities.Project))]
        public int ProjectId { get; set; }
        
        public Employee Employee { get; set; }
        public Project Project { get; set; }

    }
}
