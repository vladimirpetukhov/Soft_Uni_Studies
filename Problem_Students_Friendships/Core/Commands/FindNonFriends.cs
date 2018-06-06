using Second_Way.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Second_Way.Core.Commands
{

    public class FindNonFriends : Command
    {
        public FindNonFriends(IRepository repository, string[] args) : base(repository, args)
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

            var allFriendsMyFriends = new List<IStudent>();

            foreach (var std in student.Students)
            {
                foreach (var item in std.Students)
                {

                    allFriendsMyFriends.Add(item);

                }

                
            }

            foreach (var friends in allFriendsMyFriends)
            {
                var stIds = student.Students.Select(s => s.Id).ToList();

                if (!stIds.Contains(friends.Id) && student.Id!=friends.Id)
                {
                    sb.AppendLine($"{friends.Id}");
                }
            }
            
            return sb.ToString();
        }
    }
}
