using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public class BaseAttack : IAttack
    {
        public override int Damage => 38;

        public override int ChangeCritical => 0;

        public override string NameAttack => "Base attack";
    }
}
