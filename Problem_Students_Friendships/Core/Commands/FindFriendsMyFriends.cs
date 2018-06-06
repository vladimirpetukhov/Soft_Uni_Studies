using Second_Way.Contracts;
using System;
using System.Linq;
using System.Text;

namespace Second_Way.Core.Commands
{
    public class FindFriendsMyFriends : Command
    {
        public FindFriendsMyFriends(IRepository repository, string[] args) : base(repository, args)
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
                foreach (var item in std.Students)
                {

                    sb.AppendLine($"--{item.Id}");
                }

            }
            //foreach (var std in student.Students)
            //{
            //    foreach (var item in std.Students)
            //    {
            //        if(!student.Students.Select(i=> i.Id).Contains(item.Id))
            //        sb.AppendLine($"--{item.Id}");
            //    }

            //}

            return sb.ToString();
        }
    }
}
