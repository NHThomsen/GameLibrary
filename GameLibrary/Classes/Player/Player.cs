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
        // The name of the player
        public string Name { get; private set; }
        // Amount of health points a player has
        public double HealthPoints { get; private set; }
        // The players position in the world
        public Position Position { get; private set; }
        // The inventory of the player
        public List<Item> Inventory { get; } = new List<Item>();
        // The state of the player
        public IState State { get; private set; }
        // Used for trace/logging
        private IGameLogging GameLogging { set; get; }
        // The equipped offensive item a player, CAN have
        public OffensiveItem? EquippedOffensive { get; private set; }
        // The equipped defense item a player, CAN have
        public DefensiveItem? EquippedDefensive { get; private set; }
        // Used to generate the possible damage
        private Random RandomGenerator = new Random();
        // Returns true, if the player is poisoned
        public bool IsPoisoned
        {
            get 
            {
                return State.GetType() == typeof(PoisonedState);
            }
        }
        // Returns true, if the player has less than or equal to zero health points
        public bool IsDead
        {
            get { return HealthPoints <= 0; }
        }
        public Player(string name, IGameLogging gameLogging, int healthPoints = 100) 
        {
            Name = name;
            HealthPoints = healthPoints;
            Position = new Position(0,0);
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
        /// <summary>
        /// Calculates the damage a player takes and subtracts it
        /// Depends on the state a player is in
        /// </summary>
        /// <param name="taken">The damage the players gets</param>
        /// <returns>The damage the player takes</returns>
        public Damage.Damage CalculateTakeDamage(Damage.Damage taken)
        {
            Damage.Damage dmgToTake = State.CalculateTakeDamage(taken,EquippedDefensive);
            HealthPoints -= dmgToTake.DamageAmount;
            return dmgToTake;
        }
        /// <summary>
        /// Calculates the damage a player gives
        /// Depends on the state a player is in
        /// </summary>
        /// <returns>The damage the player gives</returns>
        public Damage.Damage CalculateGiveDamage()
        {
            return State.CalculateGiveDamage(
                new Damage.Damage(RandomGenerator.Next(5, 10)), 
                EquippedOffensive);
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
