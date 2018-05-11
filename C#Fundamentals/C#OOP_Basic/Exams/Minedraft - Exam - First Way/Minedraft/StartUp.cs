namespace Minedraft
{
    using Commands;
    public class StartUp
    {
        public static void Main()
        {
            CommandInterpreter command = new CommandInterpreter();
            Engine engine = new Engine(command);
            engine.Run();
        }
    }
}
