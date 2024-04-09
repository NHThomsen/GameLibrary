using GameLibrary.Classes.Items;
using GameLibrary.Classes.World;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Creatures
{
    public class Minotaur : Creature
    {
        public Minotaur(Position position, int healthPoints, string name, IGameLogging gameLogging, List<Item>? carriedLoot) : base(position, healthPoints, name, gameLogging, carriedLoot)
        {
        }

        public override Damage.Damage GiveDamage()
        {
            return new Damage.Damage(RandomGenerator.Next(5, 20));
        }

        public override Damage.Damage TakeDamage(Damage.Damage taken)
        {
            HealthPoints -= taken.DamageAmount;
            return new Damage.Damage(taken.DamageAmount);
        }
    }
}
