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
        public Damage.Damage CalculateTakeDamage(Damage.Damage taken)
        {
            return taken;
        }
    }
}
