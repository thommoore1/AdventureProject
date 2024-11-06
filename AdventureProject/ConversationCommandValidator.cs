namespace AdventureF24;

public static class ConversationCommandValidator
{
    public static Command Validate(Command command)
    {
        if (command.Verb == "y" || command.Verb == "no" || command.Verb == "leave")
        {
            command.isValid = true;
            return command;
        }

        return new Command();
    }
}