namespace Sweetshop.App.Core.DTOs
{
    using System.Collections.Generic;

    using Models;


    public class ManagerDTO
    {
        public ManagerDTO()
        {
            this.EmployeesDTOs = new List<EmployeeDTO>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int EmployeesCount => EmployeesDTOs.Count;

        public List<EmployeeDTO> EmployeesDTOs { get; set; }
    }
}
