using GameLibrary.Classes.Creatures;
using GameLibrary.Classes.Items;
using GameLibrary.Interfaces;
using GameLibrary.Logging;
using System.Xml;

namespace GameLibrary.Classes.World
{
    /// <summary>
    /// The world is singleton because values get loaded from a config
    /// </summary>
    public class World
    {
        public string Name { get; private set; }
        public int WorldLength { get; private set; }
        private int length;
        public int WorldHeight { get; private set; }
        private int height;
        private XmlDocument? configDocument = new XmlDocument();
        private IGameLogging GameLogging;
        private List<WorldObject> WorldObjects = new List<WorldObject>();

        private static World? instance;
        
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

        private World()
        {
            GameLogging = Logging.GameLogging.Instance;
            configDocument.Load("WorldConfig.xml");
            XmlNode? nameNode = configDocument.DocumentElement.SelectSingleNode("Name");
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

            XmlNode? lengthNode = configDocument.DocumentElement.SelectSingleNode("Length");
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

            XmlNode? heightNode = configDocument.DocumentElement.SelectSingleNode("Height");
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
        public void AddToWorld(WorldObject worldObject)
        {
            WorldObjects.Add(worldObject);
        }
        public void RemoveFromWorld(WorldObject worldObject) 
        {
            WorldObjects.Remove(worldObject);
        }
        public List<Creature> GetCreaturesInWorld()
        {
            return new List<Creature>(WorldObjects.OfType<Creature>().ToList());
        }
        public List<LootContainer> GetLootContainersInWorld() 
        {
            return new List<LootContainer>(WorldObjects.OfType<LootContainer>().ToList());
        }
    }
}
