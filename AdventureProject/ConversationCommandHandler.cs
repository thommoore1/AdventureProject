namespace AdventureF24;

public static class ConversationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap = new Dictionary<string, Action<Command>>()
    {
        { "y", yes },
        { "n", no },
        { "leave", leave }
    };
    public static void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
        else
        {
            IO.WriteLine("I don't understand that command.");
        }
    }
    
    private static void yes(Command command)
    {
        Debugger.Write("Debugger handling yes");
    }

    private static void no(Command command)
    {
        Debugger.Write("Debugger handling no");
    }

    private static void leave(Command command)
    {
        Debugger.Write("Trying to switch to exploration state");
        States.ChangeState(StateType.Exploring);
    }
}