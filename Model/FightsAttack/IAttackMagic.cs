using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public abstract class IAttackMagic : IAttack
    {
        public int Damage => throw new NotImplementedException();

        public int ChangeCritical => throw new NotImplementedException();
    }
}
