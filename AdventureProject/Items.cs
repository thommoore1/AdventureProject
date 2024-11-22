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
        
        foreach (ItemJsonData itemData in data.Items)
        {
            if (!Enum.TryParse(itemData.ItemType, true, out ItemType itemType))
            {
                IO.Error($"Invalid item type {itemData.ItemType} in Items.json");
                continue;
            }
            Item? item = new Item(itemData.Name, itemData.description, itemData.initalLocationText, itemData.isTakable);

            if (item != null)
            {
                Map.AddItem(itemType, itemData.Location);
            }
        }
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