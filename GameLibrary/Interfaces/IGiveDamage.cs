﻿using GameLibrary.Classes.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Interfaces
{
    public interface IGiveDamage
    {
        public abstract Damage GiveDamage();
    }
}