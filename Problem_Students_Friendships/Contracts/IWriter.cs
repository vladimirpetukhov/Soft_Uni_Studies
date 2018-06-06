namespace Second_Way.Contracts
{
    using System;
    using System.Text;
    public interface IWriter
    {
        string StoredMessage { get; }

        void WriteLine(string output);

        void StoreMessage(string message);
    }
}
