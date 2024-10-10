namespace AdventureF24;

public class Location
{
    public string Name;
    public string Description;

    public Dictionary<string, Location> Connections;
    public List<Item> Items;
    public Location(string name, string description)
    {
        Name = name;
        Description = description;

        Connections = new Dictionary<string, Location>();
        Items = new List<Item>();
    }

    public void AddConnection(string direction, Location location)
    {
        Connections.Add(direction, location);
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public bool CanMoveInDirection(string direction)
    {
        return Connections.ContainsKey(direction);
    }

    public Location GetLocationInDirection(string direction)
    {
        return Connections[direction];
    }

    public string GetDescription()
    {
        string fullDescription = $"{Name}\n{Description}";
        foreach (Item item in Items)
        {
            fullDescription += $"\n{item.GetLocationDescription()}";
        }
        return fullDescription;
    }

    public Item FindItem(string itemName)
    {
        foreach (Item item in Items)
        {
            if (item.Name.ToLower() == itemName.ToLower())
            {
                return item;
            }
        }

        return null;
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }
}