namespace AdventureF24;
public static class Player
{
    private static Location currentLocation;
    public static List<Item> Inventory = new List<Item>();

    public static void Initialize()
    {
        currentLocation = Map.StartLocation;
        IO.Write(currentLocation.GetDescription());
    }
    
    public static void Move(Command command)
    {
        if (currentLocation.CanMoveInDirection(command.Noun))
        {
            currentLocation = currentLocation.GetLocationInDirection(command.Noun);
            IO.Write(currentLocation.GetDescription());
        }
        else
        {
            IO.Write("Can't go that way.");
        }
    }

    public static void Take(Command command)
    {
        IO.Write($"Taking {command.Noun}");

        Item item = currentLocation.FindItem(command.Noun);

        if (item == null)
        {
            IO.Write($"There is no {command.Noun} found here");
        }
        else if (!item.IsTakeable)
        {
            IO.Write($"The {command.Noun} cannot be taken");
        }
        else
        {
            item.PickUp();
            Inventory.Add(item);
            currentLocation.RemoveItem(item);
            IO.Write($"You take the {item.Name}.");
        }
    }

    public static string GetLocationDescription()
    {
        return currentLocation.GetDescription();
    }

    public static void Drop(Command command)
    {
        Item? item = Inventory.FirstOrDefault(i => i.Name.ToLower() == command.Noun.ToLower());

        if (item != null)
        {
            Inventory.Remove(item);
            currentLocation.AddItem(item);//add drop item method?
            IO.Write($"You drop the {item.Name}.");
        }
    }

    public static void ShowInventory()
    {
        if (Inventory.Count == 0)
        {
            IO.Write("You are empty-handed.");
        }
        else
        {
            IO.Write("You are carrying ");
            foreach (Item item in Inventory)
            {
                var article = SemanticTools.CreateArticle(item.Name);
                IO.Write(" " + article + " " + item.Name);
            }
        }
    }
}