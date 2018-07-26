using Sweetshop.App.Core.Contracts;
using System.Text;

namespace Sweetshop.App.Core.Commands
{
    public class EmployeePersonalInfoCommand : Command
    {
        public EmployeePersonalInfoCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            StringBuilder sb = new StringBuilder();

            int id = int.Parse(arguments[0]);

            var emloyee=this.controller.EmployeePersonalInfo(id);

            sb.AppendLine($"ID: - {emloyee.FirstName} {emloyee.LastName} - ${emloyee.Salary:f2}");
            sb.AppendLine($"Birthday: {emloyee.Birthday.ToString("dd-MM-yyyy")}");
            sb.AppendLine($"Adress: {emloyee.Adress}");

            return sb.ToString().Trim();
        }
    }
}
