using GameLibrary.Classes.Items;
using GameLibrary.Classes.World;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Player
{
    /// <summary>
    /// Player to be controlled
    /// </summary>
    public class Player
    {
        public string Name { get; private set; }
        public int HealthPoint { get; private set; }
        public Position Position { get; set; }
        public List<Item> Inventory { get; }
        private IGameLogging GameLogging { get; set; }
        public Player(string name, IGameLogging gameLogging, int healthPoints = 100) 
        {
            Name = name;
            HealthPoint = healthPoints;
            Position = new Position(0,0);
            Inventory = new List<Item>();
            GameLogging = gameLogging;
        }
        /// <summary>
        /// Adds item to inventory
        /// </summary>
        /// <param name="item">Item to be added to the inventory</param>
        public void AddToInventory(Item item) 
        {
            Inventory.Add(item);
            GameLogging.WriteInformationToText("Added item: " + item.Name + " to inventory");
        }
        /// <summary>
        /// Gets offensive items from the players inventory
        /// </summary>
        /// <returns>List of offensive items</returns>
        public List<OffensiveItem> GetOffensiveItems()
        {
            return Inventory.OfType<OffensiveItem>().ToList();
        }
        /// <summary>
        /// Gets defensive items from the players inventory
        /// </summary>
        /// <returns>List of defensive items</returns>
        public List<DefensiveItem> GetDefensiveItems()
        {
            return Inventory.OfType<DefensiveItem>().ToList();
        }
    }
}
