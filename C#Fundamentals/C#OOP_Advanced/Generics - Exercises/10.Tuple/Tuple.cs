﻿namespace _10.Tuple
{
    public class Tuple<T, U>
{
    public Tuple(T item1, U item2)
    {
        this.Item1 = item1;
        this.Item2 = item2;
    }

    public T Item1 { get; set; }

    public U Item2 { get; set; }

    public override string ToString()
    {
        return $"{Item1} -> {Item2}";
    }
}
}
