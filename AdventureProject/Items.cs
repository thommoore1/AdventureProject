using System.Text.Json;

namespace AdventureF24;

public static class Items
{
    private static Dictionary<ItemType, Item> nameToItem = new Dictionary<ItemType, Item>();

    public static void Initialize()
    {
        string path = Path.Combine(Environment.CurrentDirectory, "Items.json");
        string rawText = File.ReadAllText(path);
        
        ItemsJsonData data = JsonSerializer.Deserialize<ItemsJsonData>(rawText);
        
        Item key = CreateItem(ItemType.key, "An old, rusty key", "there is a key poking out from the dust");
        Map.AddItem(key, "Meadow");
        
        Item? beer = CreateItem(ItemType.beer, "Beer's beer", " there is beer here");
        Map.AddItem(beer, "Meadow");
    }

    public static Item? CreateItem(ItemType itemType, string description, string initalLocationDescription, bool isTakeable = true)
    {
        if (nameToItem.ContainsKey(itemType))
        {
            IO.Error($"Item {itemType.ToString()} already exists");
            return null;
        }
        Item item = new Item(itemType, description, initalLocationDescription, isTakeable);
        nameToItem.Add(itemType, item);

        return item;
    }

    public static Item FindItem(ItemType itemType)
    {
        return nameToItem[itemType];
    }
}