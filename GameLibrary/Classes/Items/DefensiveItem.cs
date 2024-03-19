using GameLibrary.Classes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Items
{
    public class DefensiveItem : Item
    {
        public DamageReduction DamageReduction { get; set; }
        public DefensiveItem(string name, string description, DamageReduction damageReduction) : base(name, description) 
        {
            DamageReduction = damageReduction;
        }
    }
}
