using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Damage
{
    public class Damage
    {
        public double DamageAmount { get; private set; }
        public Damage(double dmg) 
        {
            if(dmg < 0) 
            {
                throw new ArgumentException("Damage must not be below 0");
            }
            DamageAmount = dmg;
        }
    }
}
