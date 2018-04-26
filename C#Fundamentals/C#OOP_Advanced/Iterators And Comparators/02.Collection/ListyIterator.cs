namespace _02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> collection;
        private int currentIndex;

        public ListyIterator()
            : this(new List<T>())
        {
        }

        public ListyIterator(IEnumerable<T> collection)
        {
            this.collection = new List<T>(collection);
            this.currentIndex = 0;
        }

        public bool Move()
        {
            var canMove = this.HasNext();
            if (canMove)
            {
                this.currentIndex++;
            }
            return canMove;
        }

        public bool HasNext() => this.currentIndex < this.collection.Count - 1;

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine(this.collection[this.currentIndex]);
        }

        public void PrintAll()
        {
            var sb = new StringBuilder();
            this.collection.ForEach(i => sb.Append($"{i} "));
            Console.WriteLine(sb.ToString().Trim());
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.collection.Count; i++)
            {
                yield return this.collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}