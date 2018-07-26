using Sweetshop.App.Core.Contracts;
using System.Text;

namespace Sweetshop.App.Core.Commands
{
    public class ListEmployeesOlderThanCommand : Command
    {
        public ListEmployeesOlderThanCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            StringBuilder sb = new StringBuilder();

            var age = int.Parse(arguments[0]);

            var result= this.controller.ListEmployeesOlderThan(age);

            foreach (var item in result)
            {
                sb.AppendLine(item);
            }

            return sb.ToString().Trim();
        }
    }
}
