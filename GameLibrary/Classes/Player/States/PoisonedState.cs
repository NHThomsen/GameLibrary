using GameLibrary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Classes.Player.States
{
    public class PoisonedState : IState
    {
        public Damage.Damage CalculateTakeDamage(Damage.Damage taken)
        {
            return new Damage.Damage(taken.DamageAmount + 1);
        }
    }
}
