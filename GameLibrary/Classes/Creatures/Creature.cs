using GameLibrary.Classes.Damage;
using GameLibrary.Classes.Items;
using GameLibrary.Classes.World;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace GameLibrary.Classes.Creatures
{
    public abstract class Creature : WorldObject, ITakeDamage, IGiveDamage
    {
        public Position Position { get; protected set; }
        public List<Item> Loot {  get; protected set; }
        public int HealthPoints { get; protected set; }
        public string Name { get; protected set; }
        public bool IsDead
        {
            get { return HealthPoints < 0; }
        }
        public Creature(Position position, int healthPoints, string name, List<Item> carriedLoot) 
        {
            Position = position;
            Loot = carriedLoot;
            HealthPoints = healthPoints;
            Name = name;
        }
        public abstract Damage.Damage TakeDamage(Damage.Damage taken);
        public abstract Damage.Damage GiveDamage();
    }
}
