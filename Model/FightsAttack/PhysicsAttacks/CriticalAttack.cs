using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack.PhysicsAttack
{
    public class CriticalAttack : IAttack
    {
        public override string NameAttack => "Tricky hit";

        public override int Damage => 15;

        public override int ChangeCritical => 25;
    }
}
