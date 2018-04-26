namespace _09.LinkedListTraversal
{
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private readonly IList<T> collection;

        public LinkedList()
        {
            this.collection = new List<T>();
        }

        public int Count => this.collection.Count;

        public void Add(T element)
        {
            this.collection.Add(element);
        }

        public bool Remove(T element)
        {
            if (!this.collection.Contains(element))
            {
                return false;
            }

            var firstOccurenceToRemove = -1;
            for (int i = 0; i < this.Count; i++)
            {
                if (!this.collection[i].Equals(element)) continue;
                firstOccurenceToRemove = i;
                break;
            }
            this.collection.RemoveAt(firstOccurenceToRemove);
            return true;
        }

        public IEnumerator<T> GetEnumerator() => this.collection.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
