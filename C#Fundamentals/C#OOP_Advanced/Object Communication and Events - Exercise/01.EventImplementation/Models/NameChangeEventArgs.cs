namespace _01.EventImplementation.Models
{
    public class NameChangeEventArgs
    {
        public NameChangeEventArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}
