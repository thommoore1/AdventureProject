namespace AdventureF24;

public static class Map
{
    public static Location StartLocation;
    
    private static Dictionary<string, Location> locations = new Dictionary<string, Location>();
    public static void Initialize()
    {
        Location entranceHall = addLocation("Entrance Hall", "A grand hall. Doors lead north and east.");
        Location library = addLocation("Library", "Books and more books. A door leads south");
        Location meadow = addLocation("Meadow", "a meadow with flowers and butterflies");
        Location forrest = addLocation("Forrest", "a forrest with sunlight streaking through the leaves");
        Location deepForrest = addLocation("Deep Forrest", "A forrest dense with trees. It's quite dark");
        Location castle = addLocation("Castle", "A castle in a clearing of the forrest");
        Location town = addLocation("Town", "A small bustling town");
        Location lake = addLocation("Lake", "A beautiful blue lake");
        Location river = addLocation("River", "A river rushing past");
        Location foothills = addLocation("Foothills", "A foothills with a mountain looming behind");
        Location mountain = addLocation("Mountain", "A large mountain capped with snow");
        Location lavaFlats = addLocation("Lava Flats", "lava flats with rivers of lava streking the ground");

        entranceHall.AddConnection("north", library);
        library.AddConnection("south", entranceHall);
        
        meadow.AddConnection("north", lavaFlats);
        meadow.AddConnection("south", town);
        meadow.AddConnection("east", river);
        meadow.AddConnection("west", forrest);
        
        forrest.AddConnection("east", meadow);
        forrest.AddConnection("west", deepForrest);
        
        deepForrest.AddConnection("east", forrest);
        deepForrest.AddConnection("west", castle);
        
        castle.AddConnection("east", deepForrest);
        castle.AddConnection("west", town);
        town.AddConnection("north", meadow);
        town.AddConnection("east", lake);
        town.AddConnection("west", castle);
        
        lake.AddConnection("west", lake);
        lake.AddConnection("north",river);
        
        river.AddConnection("south", lake);
        river.AddConnection("west", meadow);
        river.AddConnection("east", foothills);
        
        foothills.AddConnection("west", river);
        foothills.AddConnection("north", mountain);
        
        mountain.AddConnection("south", foothills);
        mountain.AddConnection("west", lavaFlats);
        
        lavaFlats.AddConnection("east", mountain);
        lavaFlats.AddConnection("south", meadow);

        StartLocation = meadow;
        
        Item key = new Item("key", "A key", "there is a key poking out from the ground");
        Item beer = new Item("beer", "Beer's beer", "there is beer on a tree stump");
        Item alligator = new Item("alligator", "Alligator's alligator", "there is alligator's alligator");
        meadow.AddItem(key);
        meadow.AddItem(beer);
        meadow.AddItem(alligator);
    }

    private static Location addLocation(string name, string description)
    {
        Location location = new Location(name, description);
        locations.Add(name, location);
        return location;
    }

    public static void AddConnection(string startLocation, string direction, string endLocation)
    {
        Location? start = FindLocation(startLocation);
        Location? end = FindLocation(startLocation);

        if (start == null || end == null)
        {
            IO.Error($"Could not find location: {startLocation} and/or {endLocation}");
            return;
        }
        start.AddConnection(direction, end);
    }
    
    public static void RemoveConnection(string locationName, string direction)
    {
        Location? location = FindLocation(locationName);

        if (location == null)
        {
            return;
        }
        location.RemoveConnection(direction);
    }
    

    public static Location? FindLocation(string location)
    {
        if (locations.ContainsKey(location))
        {
            return locations[location];
        }
        return null;
    }

    public static bool DoesLocationExist(string locationName)
    {
        if (locations.ContainsKey(locationName))
        {
            return true;
        }

        return false;
    }

    public static Location? GetLocationByName(string locationName)
    {
        Location location = FindLocation(locationName);
        return location;
    }
}