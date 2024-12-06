namespace AdventureF24;
public static class Player
{
    private static Location currentLocation;
    public static List<Item> Inventory = new List<Item>();

    public static void Initialize()
    {
        currentLocation = Map.StartLocation;
        IO.WriteLine(currentLocation.GetDescription());
    }
    
    public static void Move(Command command)
    {
        if (currentLocation.CanMoveInDirection(command.Noun))
        {
            currentLocation = currentLocation.GetLocationInDirection(command.Noun);
            IO.WriteLine(currentLocation.GetDescription());
        }
        else
        {
            IO.WriteLine("Can't go that way.");
        }
    }

    public static void Take(Command command)
    {
        IO.WriteLine($"Taking {command.Noun}");

        Item item = currentLocation.FindItem(command.Noun);

        if (item == null)
        {
            IO.WriteLine($"There is no {command.Noun} found here");
        }
        else if (!item.IsTakeable)
        {
            IO.WriteLine($"The {command.Noun} cannot be taken");
        }
        else
        {
            item.PickUp();
            Inventory.Add(item);
            currentLocation.RemoveItem(item);
            IO.WriteLine($"You take the {item.Name}.");
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
            IO.WriteLine($"You drop the {item.Name}.");

            if (item.Name == "Key")
            {
                Conditions.IsTrue(ConditionType.HasKey);
            }
        }
    }

    public static void ShowInventory()
    {
        if (Inventory.Count == 0)
        {
            IO.WriteLine("You are empty-handed.");
        }
        else
        {
            IO.WriteLine("You are carrying ");
            foreach (Item item in Inventory)
            {
                var article = SemanticTools.CreateArticle(item.Name);
                IO.WriteLine(" " + article + " " + item.Name);
            }
        }
    }

    public static void Use(Command command)
    {
        if (command.Noun == "beer")
        {
            Conditions.ChangeCondition(ConditionType.IsDrunk, true);
        }
    }

    public static void MoveToLocation(string locationName)
    {
        Location? newLocation = Map.GetLocationByName(locationName);
        
        if (newLocation == null)
        {
            IO.WriteLine($"There is no location named {locationName}.");
            return;
        }
        currentLocation = newLocation;
        IO.WriteLine(currentLocation.GetDescription());
    }

    public static void AddToInventory(ItemType itemType)
    {
        Item item = Items.FindItem(itemType);
        if (item == null)
        {
            return;
        }
        Inventory.Add(item);
    }

    public static void RemoveFromInventory(ItemType itemType)
    {
        Item item = Items.FindItem(itemType);
        if (item == null)
        {
            return;
        }
        Inventory.Remove(item);
    }
}