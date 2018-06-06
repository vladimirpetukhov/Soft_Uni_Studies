namespace Second_Way.Core.Commands
{
    using Second_Way.Contracts;
    using System.Linq;
    using System.Text;
    using System;
    public class FindFriends : Command
    {
        public FindFriends(IRepository repository, string[] args) : base(repository, args)
        {
        }

        public override string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            
            var friendsList = this.Repository.Friendship.ToList();
            var id = int.Parse(args[1]);

            var student = friendsList.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new ArgumentException($"Student with Id-{id} does not exist");
            }

            foreach (var std in student.Students)
            {
                sb.AppendLine($"--{std.Id}");
            }

            return sb.ToString();
        }
    }
}
