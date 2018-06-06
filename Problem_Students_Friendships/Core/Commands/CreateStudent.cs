namespace Second_Way.Core.Commands
{
    using Contracts;
    using Core.Factory;
    using System.Collections.Generic;
    using System;
    public class CreateStudent : Command
    {
        private IFactory factory;
        public CreateStudent(IRepository repository,string[] args) : base(repository,args)
        {
            this.factory = new StudentFactory();
        }

        public override string Execute(string[] args)
        {
            string message = string.Empty;
            
            IStudent student=this.factory.CreateStudent(args);
            try
            {
                this.Repository.AddStudent(student);
                message = $"Student with Id:{student.Id} -- Name:{student.Name} is added!";
            }
            catch(ArgumentException e)
            {
                message = e.Message;
            }

            return message;
        }
    }
}
