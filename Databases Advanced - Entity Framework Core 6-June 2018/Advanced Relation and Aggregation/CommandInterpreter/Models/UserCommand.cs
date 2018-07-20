using System;
using System.Collections.Generic;
using System.Text;
using P01_BillsPaymentSystem.Data;

namespace CommandInterpreter.Models
{
    public class UserCommand : Command
    {
        private const int NamesLenght = 50;
        private const int EmailLengt = 80;
        private const int PasswordLenght = 25;

        private string firstName;
        private string lastName;
        private string email;
        private string password;

        public UserCommand(string firstName, string lastName, string email, string password)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set
            {
                CheckLenght(value, NamesLenght);
                this.firstName = value;
            }
        }
        public string LastName
        {
            get { return this.lastName; }
            set
            {
                CheckLenght(value, NamesLenght);
                this.lastName = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                CheckLenght(value, EmailLengt);
                this.email = value;
            }
        }
        public string Password
        {
            get { return this.password; }
            set
            {
                CheckLenght(value,PasswordLenght);
                this.password = value;
            }
        }

        public override void PopulateTable(BillsPaymentSystemContext context, string table)
        {
            throw new NotImplementedException();
        }

        private void CheckLenght(string value, int lenght)
        {
            if (value.Length > lenght)
            {
                throw new ArgumentException($"{nameof(value)} must be at least {lenght} characters!");
            }
        }
    }
}
