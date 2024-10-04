namespace AdventureF24;

public static class Vocabulary
{
    public static List<string> notStandaloneVerbs = new List<string>()
        { "look", "eat", "get", "go", "take" };
    
    public static List<string> standaloneVerbs = new List<string>()
        { "look", "inventory", "exit", "tron", "troff"};
    
    public static List<string> nouns = new List<string>()
        { "north", "south", "west", "east", "up", "down" };

    public static bool IsNoun(string noun)
    {
        return nouns.Contains(noun);
    }

    public static bool IsVerb(string verb)
    {
        return standaloneVerbs.Contains(verb) || notStandaloneVerbs.Contains(verb);
    }
    
    public static bool IsStandaloneVerb(string word)
    {
        return standaloneVerbs.Contains(word);
    }

    public static void AddNoun(string noun)
    {
        if (!nouns.Contains(noun))
        {
            nouns.Add(noun);
        }
    }
}