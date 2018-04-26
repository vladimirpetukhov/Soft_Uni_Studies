namespace _11.Threeuple
{
    class Threeuple<T, U, V>
    {
        public Threeuple(T item1, U item2, V item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public T Item1 { get; set; }

        public U Item2 { get; set; }

        public V Item3 { get; set; }

        public override string ToString()
        {
            return $"{Item1} -> {Item2} -> {Item3}";
        }
    }
}
