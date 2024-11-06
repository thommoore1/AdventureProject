namespace AdventureF24;

public static class IO
{
    public static void WriteLine(string output)
    {
        Console.WriteLine(output);
    }

    public static void Write(String output)
    {
        Console.Write(output);
    }

    public static string Read()
    {
        Prompt.Show();
        return Console.ReadLine();
    }

    public static void Error(string output)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(output);
    }
}