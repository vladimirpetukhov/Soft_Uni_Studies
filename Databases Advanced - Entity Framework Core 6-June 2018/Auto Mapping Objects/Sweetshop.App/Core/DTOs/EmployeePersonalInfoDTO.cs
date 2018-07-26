namespace Sweetshop.App.Core.DTOs
{
    using System;

    public class EmployeePersonalInfoDTO
    {
        
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public DateTime Birthday { get; set; }

        public string Adress { get; set; }
    }
}
