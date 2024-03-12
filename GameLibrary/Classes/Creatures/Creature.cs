using GameLibrary.Classes.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Creatures
{
    public class Creature
    {
        public Position Position;
        public Creature(Position position) 
        {
            Position = position;
        }
    }
}
