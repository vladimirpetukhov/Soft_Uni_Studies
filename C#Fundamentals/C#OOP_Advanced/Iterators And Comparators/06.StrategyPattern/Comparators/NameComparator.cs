namespace _06.StrategyPattern.Comparators
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class NameComparator : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            var result = x.Name.Length.CompareTo(y.Name.Length);

            if (result != 0) return result;

            var xFirstLetter = char.ToLower(x.Name[0]);
            var yFirstLetter = char.ToLower(y.Name[0]);

            result = xFirstLetter.CompareTo(yFirstLetter);

            return result;
        }
    }
}
