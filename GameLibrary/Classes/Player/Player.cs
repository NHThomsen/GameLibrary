using GameLibrary.Classes.Items;
using GameLibrary.Classes.Player.States;
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
        public IState State { get; private set; }
        public Player(string name, int healthPoints = 100) 
        {
            Name = name;
            HealthPoint = healthPoints;
            Position = new Position(0,0);
            Inventory = new List<Item>();
            State = new NormalState();
        }
        /// <summary>
        /// Adds item to inventory
        /// </summary>
        /// <param name="item">Item to be added to the inventory</param>
        public void AddToInventory(Item item) 
        {
            Inventory.Add(item);
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
        /// <summary>
        /// Method meant to called when something poisons them
        /// </summary>
        public void PoisonPlayer()
        {
            State = new PoisonedState();
        }
    }
}
