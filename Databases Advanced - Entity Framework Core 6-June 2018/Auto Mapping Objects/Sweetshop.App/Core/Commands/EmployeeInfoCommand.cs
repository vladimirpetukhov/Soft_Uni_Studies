using Sweetshop.App.Core.Contracts;

namespace Sweetshop.App.Core.Commands
{
    public class EmployeeInfoCommand : Command
    {
        public EmployeeInfoCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            int id = int.Parse(arguments[0]);

            var employee = this.controller.EmployeeInfo(id);

            return $"ID: {employee.Id} - {employee.FirstName} {employee.LastName} -  ${employee.Salary:f2}";
        }
    }
}
