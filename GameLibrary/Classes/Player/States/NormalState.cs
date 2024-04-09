using GameLibrary.Classes.Items;
using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Player.States
{
    public class NormalState : IState
    {
        public Damage.Damage CalculateGiveDamage(Damage.Damage given, OffensiveItem? offensiveItem)
        {
            if(offensiveItem != null) 
            {
                return new Damage.Damage(given.DamageAmount + offensiveItem.DamageGive.DamageAmount);
            }
            return new Damage.Damage(given.DamageAmount);
        }

        public Damage.Damage CalculateTakeDamage(Damage.Damage taken, DefensiveItem? defensiveItem)
        {
            if(defensiveItem != null) 
            {
                return new Damage.Damage(taken.DamageAmount - defensiveItem.DamageReduction.DamageReductionAmount);
            }
            return taken;
        }
    }
}
