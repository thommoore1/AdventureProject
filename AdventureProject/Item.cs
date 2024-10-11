namespace AdventureF24;

public class Item
{
    public string Name { get; }
    //function
    public string Description { get; }
    public string InitialLocationDescription { get; }
    public int UseCount;
    //expiration
    public bool IsTakeable { get; }
    public bool IsEdible { get; }
    public bool HasBeenPickedUp { get; private set; } = false;

    public string LocationDescription
    {
        get
        {
            string article = SemanticTools.CreateArticle(Name);
            return $"There is {article} {Name} here.";
        }
    }


    public Item(string name, string description, string initialLocationDescription, bool isTakeable = true)
    {
        Vocabulary.AddNoun(name);
        Name = name;
        Description = description;
        InitialLocationDescription = initialLocationDescription;
        IsTakeable = isTakeable;
    }

    public string GetLocationDescription()
    {
        if (HasBeenPickedUp)
        {
            return LocationDescription;
        }
        else
        {
            return InitialLocationDescription;
        }
    }

    public void PickUp()
    {
        HasBeenPickedUp = true;
    }
}