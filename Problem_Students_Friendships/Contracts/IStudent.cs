namespace Second_Way
{
    using System.Collections.Generic;
    public interface IStudent
    {
        IList<IStudent> Students { get; }
        int Id { get; }
        string Name { get; }
        string Gender { get; }
    }
}
