namespace AdventureF24;

public class ExplorationCommandHandler
{
    private Dictionary<string, Action<Command>> commandMap = new Dictionary<string, Action<Command>>()
    {
        {"go", Move},
        {"tron", Tron},
        {"troff", Troff},
        {"take", Take},
        {"look", Look},
        {"drop", Drop},
        {"inventory", Inventory}
    };

    private void Inventory(Command command)
    {
        Player.ShowInventory();
    }

    private void Drop(Command command)
    {
        Player.Drop(command);
    }

    private void Look(Command command)
    {
        IO.Write(Player.GetLocationDescription());
    }

    public void Handle(Command command)
    {
        if (commandMap.ContainsKey(command.Verb))
        {
            Action<Command> action = commandMap[command.Verb];
            action.Invoke(command);
        }
        else
        {
            //dont know
        }
    }

    private void Move(Command command)
    {
        Player.Move(command);
    }

    private void Take(Command command)
    {
        Player.Take(command);
    }

    private void Tron(Command command)
    {
        Debugger.Tron();
    }

    private void Troff(Command command)
    {
        Debugger.Troff();
    }
}