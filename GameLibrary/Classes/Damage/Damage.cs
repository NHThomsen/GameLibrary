using GameLibrary.Interfaces;
using GameLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Damage
{
    /// <summary>
    /// Damage taken must never be negative
    /// </summary>
    public class Damage
    {
        public double DamageAmount { get; private set; }
        private IGameLogging GameLogging { set; get; }
        public Damage(double dmg) 
        {
            if(dmg < 0) 
            {
                GameLogging.WriteInformationToText("Damage was below zero");
                throw new ArgumentException("Damage must not be below 0");
            }
            DamageAmount = dmg;
        }
    }
}
