namespace Second_Way.Core.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Contracts;
    using Core.Units;
    using Core.Factory;
    using System.Linq;
    public class Repository : IRepository
    {



        private IList<IStudent> friendship;
        private IFactory factory;

        public Repository(IList<IStudent> friendship)
        {


            this.Friendship = friendship;
            this.factory = new StudentFactory();
        }

        public IList<IStudent> Friendship
        {
            get { return this.friendship; }
            private set { this.friendship = value; }
        }

        public string AddFriends(string[] studentIds)
        {
            StringBuilder sb = new StringBuilder();

            var parsedIds = studentIds.Select(int.Parse).ToArray();
            int firstStudentId = parsedIds[0];
            var friendsIds = parsedIds.Skip(1).ToList();

            var finalFriendsList = CheckFriendsIds(friendsIds);

            var student = this.Friendship.FirstOrDefault(v => v.Id == firstStudentId);

            foreach (var item in finalFriendsList)
            {

                student.Students.Add(item);

            }



            sb.AppendLine($"Student  {student} have new friends:");


            return sb.ToString().Trim();
        }
        public void AddStudent(IStudent student)
        {
            bool Exist = this.Friendship.Any(s => s.Id == student.Id);
            if (Exist)
            {
                throw new ArgumentException($"Student with Id-{student.Id} already exist!");
            }
            this.Friendship.Add(student);

        }
        private List<IStudent> CheckFriendsIds(List<int> friendsIds)
        {
            var result = new List<IStudent>();
            foreach (var ids in friendsIds)
            {
                foreach (var student in this.Friendship)
                {
                    if (student.Id == ids)
                    {
                        result.Add(student);
                    }
                }
            }
            return result;
        }





    }
}
