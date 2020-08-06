using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack.PhysicsAttacks
{
    public class HeavyAttack : IAttack
    {
        public override string NameAttack => "Heavy attack heavy weapons";

        public override int Damage => 44;

        public override int ChangeCritical => 7;
    }
}
