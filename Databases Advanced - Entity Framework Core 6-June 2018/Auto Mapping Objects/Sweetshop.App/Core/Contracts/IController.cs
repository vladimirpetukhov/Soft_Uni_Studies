namespace Sweetshop.App.Core.Contracts
{
    using System;

    using DTOs;

    public interface IController
    {
        void AddEmployee(EmployeeDTO employee);

        void SetBirthday(int id, DateTime birthday);

        void SetAdress(int id, string adress);

        EmployeeDTO EmployeeInfo(int id);

        EmployeePersonalInfoDTO EmployeePersonalInfo(int id);

        void SetManager(int employeeId, int managerId);

        ManagerDTO ManagerInfo(int managerId);

        string[] ListEmployeesOlderThan(int age);

        void Exit();
    }
}
