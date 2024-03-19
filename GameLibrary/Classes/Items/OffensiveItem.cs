using GameLibrary.Classes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Items
{
    /// <summary>
    /// Class meant for item, used to conflict damage
    /// </summary>
    public abstract class OffensiveItem : Item
    {
        public Damage.Damage DamageGive {  get; private set; }
        public OffensiveItem(string name, string description, Damage.Damage damage) : base(name, description) 
        {
            DamageGive = damage;
        }
    }
}
