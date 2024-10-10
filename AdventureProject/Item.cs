namespace AdventureF24;

public class Item
{
    public string Name;
    //function
    public string Description;
    public string InitialLocationDescription;
    public int UseCount;
    //expiration
    public bool IsTakeable;
    public bool IsEdible;
    public bool HasBeenPickedUp = false;
    

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
            return Description;
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