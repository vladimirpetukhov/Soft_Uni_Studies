namespace Second_Way.Core.Units
{
    using Contracts;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Student : Unit
    {
        public Student(int id, string name, string gender)
        : base(id, name, gender)
        {

        }

       
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Id} {Name} {Gender}");
            
            return sb.ToString().Trim();
        }


    }
}
