namespace _05.Comparing_Objects
{
    using System;
    public class Person : IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; }

        public int Age { get; }

        public string Town { get; }
        
        public int CompareTo(Person other)
        {
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            var ageComparison = Age.CompareTo(other.Age);
            return ageComparison != 0 ? ageComparison : string.Compare(Town, other.Town, StringComparison.Ordinal);
        }
    }
}
