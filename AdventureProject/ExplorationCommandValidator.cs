namespace AdventureF24;

public class ExplorationCommandValidator : ICommandValidator
{
    
    public Command Validate(Command command)
    {
        if (Vocabulary.IsVerb(command.Verb))
        {
            if (Vocabulary.IsStandaloneVerb(command.Verb))
            {
                if (command.HasNoNoun())
                {
                    command.isValid = true;
                }
                else
                {
                    IO.Write("I don't know how to do that");
                }
            }
            else if (Vocabulary.IsNoun(command.Noun))
            {
                command.isValid = true;
            }
            else
            {
                IO.Write($"I don't know the word {command.Noun}.");
            }
            
        }
        else
        {
            IO.Write($"I do not know the word {command.Verb}.");
        }

        return command;
    }
}