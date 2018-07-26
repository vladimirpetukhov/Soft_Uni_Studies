namespace Sweetshop.App.Core.Commands
{
    using Contracts;
    using Controlers;
    using DTOs;

    public class AddEmployeeCommand : Command
    {
        public AddEmployeeCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            string firstName = arguments[0];
            string lastName = arguments[1];
            decimal salary = decimal.Parse(arguments[2]);

            var employee = new EmployeeDTO
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.controller.AddEmployee(employee);

            return $"Employee: {firstName} {lastName} was added!";
        }
    }
}
