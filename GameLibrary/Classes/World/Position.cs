using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.World
{
    public class Position
    {
        public int X {  get; private set; }
        public int Y { get; private set; }

        public Position(int x, int y)
        {
            if(x < 0 || y < 0)
            {
                throw new ArgumentException("Values must not be less than zero");
            }
            X = x;
            Y = y;
        }
    }
}
