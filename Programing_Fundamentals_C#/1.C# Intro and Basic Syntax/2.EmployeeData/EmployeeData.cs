


namespace EmployeeData
{
    using System;
    public class Program
    {
        public static void Main()
        {
            // Name – no formatting
            // Age – no formatting
            // Employee ID – 8 - digit padding(employee id 356 is 00000356)
            // Monthly Salary – formatted to 2 decimal places(2345.56789 becomes 2345.56)

            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string employeeID = Console.ReadLine();
            decimal monthlySalary = decimal.Parse(Console.ReadLine());

            employeeID = employeeID.PadLeft(8, '0');

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Age: {age}");
            Console.WriteLine($"Employee ID: {employeeID}");
            Console.WriteLine($"Salary: {monthlySalary:F2}");
        }
    }
}
