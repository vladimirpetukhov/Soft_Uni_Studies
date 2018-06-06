using System.Collections.Generic;

namespace Second_Way
{
    public abstract class Unit : IStudent
    {
        private IList<IStudent> students;
        private int id;
        private string name;
        private string gender;


        protected Unit(int id, string name, string gender)
        {
            this.students = new List<IStudent>();
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
        }

        public int Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Gender
        {
            get { return this.gender; }
            set { this.gender = value; }
        }

        public IList<IStudent> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
