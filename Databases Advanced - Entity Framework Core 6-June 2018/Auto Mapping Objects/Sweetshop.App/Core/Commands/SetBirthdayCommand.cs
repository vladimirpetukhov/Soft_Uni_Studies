namespace Sweetshop.App.Core.Commands
{
    using System;
    using System.Globalization;

    using Contracts;

    public class SetBirthdayCommand : Command
    {
        public SetBirthdayCommand(IController controller) : base(controller)
        {
        }

        public override string Execute(string[] arguments)
        {
            int id = int.Parse(arguments[0]);
            DateTime date = DateTime.ParseExact(arguments[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

            this.controller.SetBirthday(id, date);

            return $"Birthday was added!";
        }
    }
}
