namespace AdventureF24;

public static class ConditionActions
{
    public static Action WriteOutput(string message)
    {
        return () => IO.WriteLine(message);
    }
    
    
}