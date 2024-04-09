using GameLibrary.Classes.Damage;
using GameLibrary.Classes.Items;
using GameLibrary.Classes.World;
using GameLibrary.Interfaces;
using GameLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace GameLibrary.Classes.Creatures
{
    /// <summary>
    /// Creature class all enemies should inherit from
    /// </summary>
    public abstract class Creature : WorldObject, ITakeDamage, IGiveDamage
    {
        // The creatures position in the world
        public Position Position { get; protected set; }
        // Loot, the creature is carrying
        public List<Item>? Loot {  get; protected set; }
        // Amount of health points a creature have
        public double HealthPoints { get; protected set; }
        // The name of a creature
        public string Name { get; protected set; }
        // Used to log trace/logging
        public IGameLogging GameLogging { get; protected set; }
        // Used to generate random numbers, in inherited classes
        protected Random RandomGenerator = new Random();
        // Returns true, if a creature is dead
        public bool IsDead
        {
            get { return HealthPoints < 0; }
        }
        public Creature(Position position, int healthPoints, string name, IGameLogging gameLogging, List<Item>? carriedLoot = null) 
        {
            Position = position;
            if(carriedLoot != null)
            {
                Loot = carriedLoot;
            }
            else
            {
                Loot = null;
            }
            HealthPoints = healthPoints;
            Name = name;
            GameLogging = gameLogging;
            GameLogging.WriteInformationToText("Creature created with name: " + Name);
        }
        /// <summary>
        /// Calculates how much damage a creature takes
        /// </summary>
        /// <param name="taken">Amount of damage the creature taken</param>
        /// <returns>The actual amount a creature takes</returns>
        public abstract Damage.Damage TakeDamage(Damage.Damage taken);
        /// <summary>
        /// Calculates how much damage a creature gives
        /// </summary>
        /// <returns>The amount of damage to give</returns>
        public abstract Damage.Damage GiveDamage();
    }
}
