namespace AdventureF24;

public static class Game
{
    private static bool isPlaying = true;
    
    public static void Play()
    {
        while (isPlaying)
        {
            Command command = CommandProcessor.GetCommand();
            if (command.isValid)
            {
                if (command.Verb == "tron")
                {
                    Debugger.Tron();
                }
                else if (command.Verb == "troff")
                {
                    Debugger.Troff();
                }
                Console.WriteLine(command.ToString());
            }
            else
            {
                Console.WriteLine("Invalid Command");
            }
        }
    }
}