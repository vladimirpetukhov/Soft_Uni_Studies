namespace Second_Way.Contracts
{
    using System.Collections.Generic;
    public interface IRepository
    {
        IList<IStudent> Friendship { get; }
        
        void AddStudent(IStudent student);

        string AddFriends(string[] studentsIds);
        

    }
}
