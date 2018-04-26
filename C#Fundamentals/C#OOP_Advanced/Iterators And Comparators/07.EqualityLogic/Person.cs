namespace _07.EqualityLogic
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; }

        public int Age { get; }

        public int CompareTo(Person other)
        {
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            return nameComparison != 0 ? nameComparison : Age.CompareTo(other.Age);
        }

        public override bool Equals(object obj)
        {
            var item = (Person) obj;

            return item != null && this.Name.Equals(item.Name);
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.Age.GetHashCode();
        }
    }
}
