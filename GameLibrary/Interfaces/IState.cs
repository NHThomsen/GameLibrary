using GameLibrary.Classes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IState
    {
        Damage CalculateTakeDamage(Damage taken);
    }
}
