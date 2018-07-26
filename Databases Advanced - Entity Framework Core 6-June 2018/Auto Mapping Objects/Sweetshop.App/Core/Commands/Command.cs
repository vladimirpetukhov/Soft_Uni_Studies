namespace Sweetshop.App.Core.Commands
{
    using Contracts;
    using Controlers;

    public abstract class Command : ICommand
    {
        public readonly IController controller;

        public Command(IController controller)
        {
            this.controller = controller;
        }



        public abstract string Execute(string[] arguments);
    }
}
