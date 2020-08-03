using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public class BaseAttack : IAttack
    {
        public int Damage { get; } = 38;

        public int ChangeCritical { get; } = 0;
    }
}
