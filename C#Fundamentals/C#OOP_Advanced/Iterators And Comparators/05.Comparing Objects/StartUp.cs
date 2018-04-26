namespace _05.Comparing_Objects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> persons = GetPersons();

            var personIndex = int.Parse(Console.ReadLine()) - 1;
            if (personIndex < 0 || personIndex >= persons.Count) return;
            {
                var person = persons[personIndex];
                var matchingPersons = persons.Count(p => p.CompareTo(person) == 0);

                Console.WriteLine(matchingPersons == 1
                    ? "No matches"
                    : $"{matchingPersons} {persons.Count - matchingPersons} {persons.Count}");
            }
        }

        private static List<Person> GetPersons()
        {
            var persons = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var personInfo = input
                    .Split();
                var name = personInfo[0];
                var age = int.Parse(personInfo[1]);
                var town = personInfo[2];

                var person = new Person(name, age, town);
                persons.Add(person);
            }

            return persons;
        }
    }
}
