namespace AdventureF24;

public class ExplorationCommandHandler
{
    private static Dictionary<string, Action<Command>> commandMap = new Dictionary<string, Action<Command>>()
    {
        {"go", Move},
        {"tron", Tron},
        {"troff", Troff},
        {"take", Take},
        {"look", Look},
        {"drop", Drop},
        {"inventory", Inventory},
        {"talk", EnterConversationState},
    };

    private static void Use(Command command)
    {
        Player.Use(command);
    }

    private static void EnterConversationState(Command obj)
    {
        Debugger.Write("Trying to enter conersation state");States.ChangeState(StateType.Conversation);
    }

    private static void Inventory(Command command)
    {
        Player.ShowInventory();
    }

    private static void Drop(Command command)
    {
        Player.Drop(command);
    }

    private static void Look(Command command)
    {
        IO.WriteLine(Player.GetLocationDescription());
    }

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

    private static void Move(Command command)
    {
        Player.Move(command);
    }

    private static void Take(Command command)
    {
        Player.Take(command);
    }

    private static void Tron(Command command)
    {
        Debugger.Tron();
    }

    private static void Troff(Command command)
    {
        Debugger.Troff();
    }
}