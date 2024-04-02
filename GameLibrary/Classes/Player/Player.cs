using GameLibrary.Classes.Items;
using GameLibrary.Classes.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Player
{
    public class Player
    {
        public string Name { get; private set; }
        public int HealthPoint { get; private set; }
        public Position Position { get; set; }
        public List<Item> Inventory { get; }
        public Player(string name, int healthPoints = 100) 
        {
            Name = name;
            HealthPoint = healthPoints;
        }
        public void AddToInventory(Item item) 
        {
            Inventory.Add(item);
        }
        public List<OffensiveItem> GetOffensiveItems()
        {
            return Inventory.OfType<OffensiveItem>().ToList();
        }
        public List<DefensiveItem> GetDefensiveItems()
        {
            return Inventory.OfType<DefensiveItem>().ToList();
        }
    }
}
