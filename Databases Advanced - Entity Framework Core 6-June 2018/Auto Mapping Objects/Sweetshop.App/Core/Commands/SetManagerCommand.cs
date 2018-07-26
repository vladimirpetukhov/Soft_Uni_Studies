namespace Sweetshop.App.Core.Commands
{
    using Contracts;
    using Controlers;

    public class SetManagerCommand:Command
    {
        public SetManagerCommand(IController controller) : base(controller)
        {
        }

        
        public override string Execute(string[] arguments)
        {
            var emloyeeId = int.Parse(arguments[0]);
            var managerId = int.Parse(arguments[1]);
            
            this.controller.SetManager(emloyeeId, managerId);

            return $"Manager was seted!";
        }
    }
}
