using GameLibrary.Classes.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Items
{
    public abstract class LootContainer : WorldObject
    {
        public List<Item>? Loot {  get; set; } = null;
        public int Count
        {
            get
            {
                return Loot?.Count ?? 0;
            }
        }
        public abstract void AddToContainer(Item item);
    }
}
