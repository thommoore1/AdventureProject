namespace AdventureF24;

public class CommandHandler
{
    public static void Handle(Command command)
    {
        switch (States.GetCurrentState())
        {
            case StateType.Exploring:
                ExplorationCommandHandler.Handle(command);
                break;
            case StateType.Conversation:
                ConversationCommandHandler.Handle(command);
                break;
        }
    }
}