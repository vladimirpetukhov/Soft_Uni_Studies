namespace _04.WorkForce
{
    using Models;
    using Models.Employees;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public delegate void JobDoneEventHandler(object sender, JobEventArgs e);

        public static void Main()
        {
            var jobs = new JobsList();
            var employees = new List<Employee>();

            while (true)
            {
                var input = Console.ReadLine().Split();
                if (input[0] == "End") break;

                switch (input[0])
                {
                    case "Job":
                        var name = input[1];
                        var hours = int.Parse(input[2]);
                        var employee = employees.FirstOrDefault(e => e.Name == input[3]);
                        Job job = new Job(name, hours, employee);

                        job.JobDone += job.OnJobDone;
                        jobs.Add(job);
                        break;
                    case "StandardEmployee":
                        name = input[1];
                        employees.Add(new StandartEmployee(name));
                        break;
                    case "PartTimeEmployee":
                        name = input[1];
                        employees.Add(new PartTimeEmployee(name));
                        break;
                    case "Pass":
                        jobs.ForEach(j => j.Update());
                        break;
                    case "Status":
                        foreach (var j in jobs)
                        {
                            if (!j.IsDone)
                            {
                                Console.WriteLine(j.ToString());
                            }
                        }
                        break;
                }
            }
        }
    }
}
