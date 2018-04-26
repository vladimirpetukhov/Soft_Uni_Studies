namespace _04.WorkForce.Models.Employees
{
    public abstract class Employee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; protected set; }

        public int WorkHoursPerWeek { get; protected set; }
    }
}
