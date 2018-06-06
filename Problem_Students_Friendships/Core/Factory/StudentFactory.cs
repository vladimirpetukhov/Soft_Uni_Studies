namespace Second_Way.Core.Factory
{
    using System.Collections.Generic;
    using Contracts;
    using Core.Units;
    public class StudentFactory : IFactory
    {
        public IStudent CreateStudent(string[] studentArguments)
        {
            int id = int.Parse(studentArguments[0]);
            string name = studentArguments[1];
            string gender = studentArguments[2];

            IStudent student = new Student(id, name, gender);

            return student;
        }
    }
}
