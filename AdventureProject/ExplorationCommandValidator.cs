namespace AdventureF24;

public static class ExplorationCommandValidator
{
    public static Command Validate(Command command)
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
                    IO.WriteLine("I don't know how to do that");
                }
            }
            else if (Vocabulary.IsNoun(command.Noun))
            {
                command.isValid = true;
            }
            else
            {
                IO.WriteLine($"I don't know the word {command.Noun}.");
            }
            
        }
        else
        {
            IO.WriteLine($"I do not know the word {command.Verb}.");
        }

        return command;
    }
}