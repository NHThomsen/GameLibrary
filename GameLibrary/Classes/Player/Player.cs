using GameLibrary.Classes.Damage;
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
    /// Player in the game
    /// </summary>
    public class Player
    {
        public string Name { get; private set; }
        public double HealthPoints { get; private set; }
        public Position Position { get; private set; }
        public List<Item> Inventory { get; }
        public IState State { get; private set; }
        private IGameLogging GameLogging { set; get; }
        public OffensiveItem? EquippedOffensive { get; private set; }
        public DefensiveItem? EquippedDefensive { get; private set; }
        public bool IsPoisoned
        {
            get 
            {
                return State.GetType() == typeof(PoisonedState);
            }
        }
        public bool IsDead
        {
            get { return HealthPoints < 0; }
        }
        public Player(string name, IGameLogging gameLogging, int healthPoints = 100) 
        {
            Name = name;
            HealthPoints = healthPoints;
            Position = new Position(0,0);
            Inventory = new List<Item>();
            State = new NormalState();
            GameLogging = gameLogging;
            GameLogging.WriteInformationToText(Name + " was created");
        }
        /// <summary>
        /// Adds item to inventory
        /// </summary>
        /// <param name="item">Item to be added to the inventory</param>
        public void AddToInventory(Item item) 
        {
            Inventory.Add(item);
            GameLogging.WriteInformationToText("Added item " + item.Name + " to inventory");
        }
        /// <summary>
        /// Gets offensive items from the players inventory
        /// </summary>
        /// <returns>List of offensive items</returns>
        public List<OffensiveItem> GetOffensiveItems()
        {
            return new List<OffensiveItem>(Inventory.OfType<OffensiveItem>().ToList());
        }
        /// <summary>
        /// Gets defensive items from the players inventory
        /// </summary>
        /// <returns>List of defensive items</returns>
        public List<DefensiveItem> GetDefensiveItems()
        {
            return new List<DefensiveItem>(Inventory.OfType<DefensiveItem>().ToList());
        }
        public Damage.Damage CalculateTakeDamage(Damage.Damage taken)
        {
            return State.CalculateTakeDamage(taken,EquippedDefensive);
        }
        /// <summary>
        /// Method meant to called when something poisons them
        /// </summary>
        public void PoisonPlayer()
        {
            State = new PoisonedState();
            GameLogging.WriteInformationToText("Player has been poisoned");
        }
        /// <summary>
        /// Method meant to remove status effects on a player
        /// </summary>
        public void CurePlayer()
        {
            State = new NormalState();
        }
        /// <summary>
        /// Used to move to a new position in the world
        /// </summary>
        /// <param name="position">The new position in the world</param>
        /// <returns>Returns true, if the position is in the world and sets the position. Else false, if the position is not in the world</returns>
        public bool MoveToPosition(Position position) 
        {
            if(World.World.Instance.InsideWorld(position))
            {
                Position = position;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Equips an offensive item
        /// If an item is already equipped, the previous item gets put in the inventory
        /// </summary>
        /// <param name="item">The offensive item to be equipped</param>
        public void EquipOffensive(OffensiveItem item)
        {
            if(EquippedOffensive != null)
            {
                AddToInventory(EquippedOffensive);
            }
            EquippedOffensive = item;
        }
        /// <summary>
        /// Equips an offensive item
        /// If an item is already equipped, the previous item gets put in the inventory
        /// </summary>
        /// <param name="item">The defensive item to be equipped</param>
        public void EquipDefensive(DefensiveItem item) 
        {
            if(EquippedDefensive != null)
            {
                AddToInventory(EquippedDefensive);
            }
            EquippedDefensive = item;
        }
    }
}
