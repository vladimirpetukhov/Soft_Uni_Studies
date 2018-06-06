namespace Second_Way.Core.Commands
{
    using Second_Way.Contracts;
    using System.Linq;
    using System.Collections.Generic;
    using System;

    public class AddFriends : Command
    {
        public AddFriends(IRepository repository, string[] args) : base(repository, args)
        {
        }

        public override string Execute(string[] args)
        {
            string msg = string.Empty;
            
            try
            {
                msg = this.Repository.AddFriends(args);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException($"Student with Id:{args[0]} does not exist!");
                msg = e.Message;
            }
            return msg;
        }
    }
}
