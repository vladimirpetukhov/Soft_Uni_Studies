namespace Sweetshop.App.Core.Controlers
{
    using System;
    using System.Linq;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Contracts;
    using Data;
    using Models;
    using Sweetshop.App.Core.DTOs;
    using DTOs;
    using Sweetshop;

    public class EmployeeController : IController
    {
        private const string InvalidId = "Invalid id!";
        private readonly SweetshopContext context;
        private readonly IMapper mapper;

        public EmployeeController(SweetshopContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            var employeeDTO = mapper.Map<Employee>(employee);

            this.context.Employees.Add(employeeDTO);

            this.context.SaveChanges();

        }

        public EmployeeDTO EmployeeInfo(int id)
        {
            var employee = FindEmployee(id);

            var employeeDto = mapper.Map<EmployeeDTO>(employee);

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);
            }

            return employeeDto;

        }

        public EmployeePersonalInfoDTO EmployeePersonalInfo(int id)
        {
            var employee = FindEmployee(id);

            var employeeDTO = mapper.Map<EmployeePersonalInfoDTO>(employee);

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);

            }

            return employeeDTO;
        }

        public void Exit()
        {
            Environment.Exit(0);
        }

        public void SetAdress(int id, string adress)
        {
            var employee = FindEmployee(id);

            employee.Adress = adress;

            context.SaveChanges();


        }

        public void SetBirthday(int id, DateTime birthday)
        {
            var employee = FindEmployee(id);

            employee.Birthday = birthday;

            context.SaveChanges();

        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = FindEmployee(employeeId);
            var manager = FindEmployee(managerId);

            if (employee.ManagerId != null)
            {
                throw new InvalidOperationException($"Employee {employee.FirstName} {employee.LastName} already have manager!");
                
            }
            employee.Manager = manager;
           

            context.SaveChanges();
        }

        public ManagerDTO ManagerInfo(int managerId)
        {
            

            var managerDto = context.Employees
                .ProjectTo<ManagerDTO>()
                .SingleOrDefault(i => i.Id == managerId);

            return managerDto;
        }

        public string[] ListEmployeesOlderThan(int age)
        {
            var employees = this.context.Employees
                .Where(e => e.Birthday != null)
                .Select(e => new
                {
                    Employee = Mapper.Map<EmployeeDTO>(e),
                    Manager = Mapper.Map<ManagerDTO>(e.Manager),
                    Age = Math.Ceiling((DateTime.Now - e.Birthday.Value).TotalDays / 365.2422),
                    e.Salary
                })
                .Where(e => e.Age > age)
                .OrderByDescending(e => e.Salary)
                .Select(e => e.Manager == null
                    ? $"{e.Employee.FirstName} {e.Employee.LastName} - ${e.Employee.Salary:F2} - Manager: [no manager]"
                    : $"{e.Employee.FirstName} {e.Employee.LastName} - ${e.Employee.Salary:F2} - Manager: {e.Manager.LastName}")
                .ToArray();

            return employees;
        }
        private Employee FindEmployee(int id)
        {
            var employee = context.Employees.Find(id);

           

            if (employee == null)
            {
                throw new ArgumentException(InvalidId);
            }

            return employee;
        }
    }
}
