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
        private IGameLogging gameLogging;

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
            gameLogging = GameLogging.Instance;
            configDocument.Load("WorldConfig.xml");
            XmlNode? nameNode = configDocument.DocumentElement.SelectSingleNode("Name");
            if (nameNode != null)
            {
                Name = nameNode.InnerText.Trim();
            }
            else
            {
                Name = "Standard world";
            }
            gameLogging.WriteInformationToText("World name: " + Name);

            XmlNode? lengthNode = configDocument.DocumentElement.SelectSingleNode("Length");
            if (int.TryParse(lengthNode?.InnerText.Trim(), out length))
            {
                WorldLength = length;
            }
            else
            {
                WorldLength = 10;
            }
            gameLogging.WriteInformationToText("World length: " + WorldLength);

            XmlNode? heightNode = configDocument.DocumentElement.SelectSingleNode("Height");
            if (int.TryParse(heightNode?.InnerText.Trim(), out height))
            {
                WorldHeight = height;
            }
            else
            {
                WorldHeight = 10;
            }
            gameLogging.WriteInformationToText("World height: " + WorldHeight);
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
    }
}
