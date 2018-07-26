namespace Sweetshop.App.Core.Commands
{
    using Sweetshop.App.Core.Contracts;
    using System.Text;

    using DTOs;

    public class ManagerInfoCommand : Command
    {
        public ManagerInfoCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            StringBuilder sb = new StringBuilder();

            int managerId = int.Parse(arguments[0]);

            var manager=this.controller.ManagerInfo(managerId);
                                

            sb.AppendLine($"{manager.FirstName} {manager.LastName} | Employees: {manager.EmployeesDTOs.Count}");

            if (manager.EmployeesDTOs.Count>0)
            {
                foreach (var employee in manager.EmployeesDTOs)
                {
                   
                    sb.AppendLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}
