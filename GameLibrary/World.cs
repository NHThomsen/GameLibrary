using System.Xml;

namespace GameLibrary
{
    public class World
    {
        public string Name { get;  private set; }
        public int WorldLength { get; private set; }
        private int length;
        public int WorldHeight { get; private set; }
        private int height;
        private XmlDocument? configDocument = new XmlDocument();

        public World()
        {
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

            XmlNode lengthNode = configDocument.DocumentElement.SelectSingleNode("Length");
            if (int.TryParse(lengthNode.InnerText.Trim(), out length))
            {
                WorldLength = length;
            }
            else
            {
                WorldLength = 10;
            }

            XmlNode heightNode = configDocument.DocumentElement.SelectSingleNode("Height");
            if(int.TryParse(heightNode.InnerText.Trim(),out height))
            {
                WorldHeight = height;
            }
            else
            {
                WorldHeight = 10;
            }
        }
    }
}
