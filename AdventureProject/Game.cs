namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        Initialize();
        
        while (isPlaying)
        {
            Command command = CommandProcessor.GetCommand();
            if (command.isValid)
            {
                Debugger.Write(command.ToString());
                CommandHandler.Handle(command);
            }
        }
    }

    private static void Initialize()
    {
        States.Initialize();
        Map.Initialize();
        Player.Initialize();
    }
}