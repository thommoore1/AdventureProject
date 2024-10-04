namespace AdventureF24;

public static class Map
{
    public static Location StartLocation;
    public static void Initialize()
    {
        Location entranceHall = new Location("Entrance Hall", "A grand hall. Doors lead north and east.");
        Location library = new Location("Library", "Books and more books. A door leads south");
        
        Location meadow = new Location("Meadow", "a meadow with flowers and butterflies");
        Location forrest = new Location("Forrest", "a forrest with sunlight streaking through the leaves");
        Location deepForrest = new Location("Deep Forrest", "A forrest dense with trees. It's quite dark");
        Location castle = new Location("Castle", "A castle in a clearing of the forrest");
        Location town = new Location("Town", "A small bustling town");
        Location lake = new Location("Lake", "A beautiful blue lake");
        Location river = new Location("River", "A river rushing past");
        Location foothills = new Location("Foothills", "A foothills with a mountain looming behind");
        Location mountain = new Location("Mountain", "A large mountain capped with snow");
        Location lavaFlats = new Location("Lava Flats", "lava flats with rivers of lava streking the ground");

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
        
        Item key = new Item("Key", "A key", "there is a key here");
        Item beer = new Item("beer", "Beer's beer", "there is beer here");
        meadow.AddItem(key);
        meadow.AddItem(beer);
    }
}