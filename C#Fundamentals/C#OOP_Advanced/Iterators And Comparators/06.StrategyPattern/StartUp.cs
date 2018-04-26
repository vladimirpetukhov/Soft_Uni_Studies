namespace _06.StrategyPattern
{
    using Comparators;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            var personsSortedByName = new SortedSet<Person>(new NameComparator());
            var personsSortedByAge = new SortedSet<Person>(new AgeComparator());

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var personInfo = Console.ReadLine()
                    ?.Split()
                    .ToList();
                var name = personInfo?[0];
                var age = int.Parse(personInfo?[1]);

                personsSortedByName.Add(new Person(name, age));
                personsSortedByAge.Add(new Person(name, age));
            }
            
            PrintPersons(personsSortedByName);
            PrintPersons(personsSortedByAge);
        }

        private static void PrintPersons(IEnumerable<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
