namespace Second_Way.Contracts
{
    using System.Collections.Generic;
    public interface IFactory
    {
        IStudent CreateStudent(string[] studentArguments);
    }
}
