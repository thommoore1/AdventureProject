namespace AdventureF24;

using System.Text.RegularExpressions;
public class SemanticTools
{
    public static string CreateArticle(string word)
    {
        string article = "a";
        bool startsWithVowel = Regex.IsMatch(word, "^[aeiou]");
        if (startsWithVowel)
        {
            article = "an";
        }

        return article;
    }
}