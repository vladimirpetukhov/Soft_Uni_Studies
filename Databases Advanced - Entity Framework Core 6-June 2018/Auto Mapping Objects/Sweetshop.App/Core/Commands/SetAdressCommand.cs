namespace Sweetshop.App.Core.Commands
{
    using System.Linq;

    using Sweetshop.App.Core.Contracts;
    
    public class SetAdressCommand : Command
    {
        public SetAdressCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            int id = int.Parse(arguments[0]);
            string adress =arguments.Skip(1).ToString();

            this.controller.SetAdress(id, adress);

            return $"Adress was added!";
        }
    }
}
