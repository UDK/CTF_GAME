﻿using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public abstract class IAttackMagic : IAttacks
    {
        public IAttackMagic(AbstractMobsOnMap hero) : base(hero)
        { }
    }
}
