namespace AdventureF24;

public class ConversationCommandValidator : ICommandValidator
{
    public Command Validate(Command command)
    {
        if (command.Verb == "y" || command.Verb == "no" || command.Verb == "leave")
        {
            command.isValid = true;
            return command;
        }

        return new Command();
    }
}