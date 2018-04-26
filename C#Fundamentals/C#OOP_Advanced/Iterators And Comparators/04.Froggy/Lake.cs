namespace _04.Froggy
{
    using System.Collections;
    using System.Collections.Generic;

    public class Lake : IEnumerable<int>
    {
        private readonly IList<int> stones;

        public Lake(IEnumerable<int> stones)
        {
            this.stones = new List<int>(stones);
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i += 2)
            {
                yield return this.stones[i];
            }

            var oddPositions = this.stones.Count - 1;
            if (oddPositions % 2 == 0)
            {
                oddPositions--;
            }

            for (int i = oddPositions; i >= 0; i -= 2)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
