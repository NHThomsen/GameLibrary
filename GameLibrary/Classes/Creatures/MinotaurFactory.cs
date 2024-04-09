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
    public class MinotaurFactory
    {
        private IGameLogging GameLogging {  get; set; }
        public MinotaurFactory(IGameLogging gameLogging) 
        {
            GameLogging = gameLogging;
            GameLogging.WriteInformationToText("Factory created");
        }
        public Minotaur CreateMinotaur(Position position, int healthPoints, List<Item> loot, string name = "Minotaur") 
        {
            return new Minotaur(position, healthPoints, name, loot, GameLogging);
        }
    }
}
