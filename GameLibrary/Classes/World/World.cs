using GameLibrary.Classes.Creatures;
using GameLibrary.Classes.Items;
using GameLibrary.Interfaces;
using GameLibrary.Logging;
using System.Xml;

namespace GameLibrary.Classes.World
{
    /// <summary>
    /// The world is singleton because values get loaded from a config.
    /// If values aren't found in config, default values will be loaded
    /// </summary>
    public class World
    {
        // Name of the world
        public string Name { get; private set; }
        // The X axis of the world
        public int WorldLength { get; private set; }
        // Used to parse world length, from config
        private int length;
        // The Y axis of the world
        public int WorldHeight { get; private set; }
        // Used to parse world height, from config
        private int height;
        // Used to handle loading in the config document
        private XmlDocument? configDocument = new XmlDocument();
        // Used for gamelogging
        private IGameLogging GameLogging;
        // List for all objects in the world
        private List<WorldObject> WorldObjects = new List<WorldObject>();
        // Instance for Singleton
        private static World? instance;
        // Getting the instance for Singleton
        public static World Instance
        {
            get
            {
                if(instance == null) 
                {
                    instance = new World();
                }
                return instance;
            }
        }
        // Loads in values from the config file. If not found, default values are loaded
        private World()
        {
            GameLogging = Logging.GameLogging.Instance;
            configDocument.Load("WorldConfig.xml");
            XmlNode? nameNode = configDocument.DocumentElement?.SelectSingleNode("Name");
            if (nameNode != null)
            {
                Name = nameNode.InnerText.Trim();
            }
            else
            {
                GameLogging.WriteWarningToText("World name not found");
                Name = "Standard world";
            }
            GameLogging.WriteInformationToText("World name: " + Name);

            XmlNode? lengthNode = configDocument.DocumentElement?.SelectSingleNode("Length");
            if (int.TryParse(lengthNode?.InnerText.Trim(), out length))
            {
                WorldLength = length;
            }
            else
            {
                GameLogging.WriteWarningToText("World length not found");
                WorldLength = 10;
            }
            GameLogging.WriteInformationToText("World length: " + WorldLength);

            XmlNode? heightNode = configDocument.DocumentElement?.SelectSingleNode("Height");
            if (int.TryParse(heightNode?.InnerText.Trim(), out height))
            {
                WorldHeight = height;
            }
            else
            {
                GameLogging.WriteWarningToText("World height not found");
                WorldHeight = 10;
            }
            GameLogging.WriteInformationToText("World height: " + WorldHeight);
        }
        // Used to determine if a position is inside the world
        public bool InsideWorld(Position position)
        {
            if(position.X < 0 || position.Y < 0)
            {
                return false;
            }
            if(position.X > WorldLength || position.Y > WorldHeight) 
            {
                return false;
            }
            return true;
        }
        // Adds an object to the world
        public void AddToWorld(WorldObject worldObject)
        {
            WorldObjects.Add(worldObject);
        }
        // Removes an object from the world
        public void RemoveFromWorld(WorldObject worldObject) 
        {
            WorldObjects.Remove(worldObject);
        }
        // Gets a copy, of a list with all creatures in the world
        public List<Creature> GetCreaturesInWorld()
        {
            return new List<Creature>(WorldObjects.OfType<Creature>().ToList());
        }
        // Gets a copy, of a list with all loot containers in the world
        public List<LootContainer> GetLootContainersInWorld() 
        {
            return new List<LootContainer>(WorldObjects.OfType<LootContainer>().ToList());
        }
    }
}
