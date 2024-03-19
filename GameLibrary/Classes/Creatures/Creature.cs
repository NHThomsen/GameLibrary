using GameLibrary.Classes.Damage;
using GameLibrary.Classes.Items;
using GameLibrary.Classes.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Creatures
{
    public abstract class Creature
    {
        public Position Position { get; protected set; }
        public List<Item> Loot {  get; protected set; }
        public int Health { get; protected set; }
        public string Name { get; protected set; }
        public Creature(Position position, int health, string name) 
        {
            Position = position;
            Loot = new List<Item>();
            Health = health;
            Name = name;
        }
        public abstract Damage.Damage TakeDamage();
        public abstract Damage.Damage GiveDamage();
    }
}
