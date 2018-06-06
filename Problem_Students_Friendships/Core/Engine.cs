namespace Second_Way.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Engine : IEngine
    {
        private const string TerminateProgram = "end";
        


        private ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = new Reader();
            this.writer = new Writer();
        }


        public void Run()
        {
            //1. First Create Students format: id name gender
            //2. Create friendsips format: id id1 id2....
            //3. Search:
            //3.1. For search friends format: FindFriends id
            //3.2. For search friends on my friends format: FindFriendsMyFriends id
            //3.3. For search friends on my firends who is not my friends format: FindNonFriends id
            string input = string.Empty;

            while (!(input = reader.Read()).Equals(TerminateProgram, StringComparison.OrdinalIgnoreCase))
            {
                string[] arguments = input.Split();

                var commandName = commandInterpreter.InterpredCommand(arguments);

                var commandResult = commandName.Execute(arguments);
                
                this.writer.StoreMessage(commandResult);
                this.writer.WriteLine(this.writer.StoredMessage);
            }
        }
    }
}
    //Create students
//1234 Milen male
//4454 Todor male
//3323 Maria female
//6546 Georgi male
//4454 Elena female
//3323 Veronika female
//6546 Vasil male
//37888 Mikel male
//9000 Eaton male
//8722 John male
    //Create friendships
//1234 4454 3323 6546
//4454 1234 3323
//6546 4454 37888 9000
    //Test Commands
//FindFriends 1234
//FindFriends 4454
//FindFriends 6546
//FindFriendsMyFriends 1234
//FindFriendsMyFriends 4454
//FindNonFriends 1234
//FindNonFriends 4454