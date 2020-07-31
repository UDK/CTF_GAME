using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public abstract class IAttacks
    {
        /// <summary>
        /// Герой со всеми свойствами
        /// </summary>
        protected AbstractMobsOnMap _hero;

        public IAttacks(AbstractMobsOnMap hero)
        {
            _hero = hero;
        }

        /// <summary>
        /// Наносимый урон
        /// </summary>
        int Damage { get; }

        /// <summary>
        /// Шанс критического удара
        /// </summary>
        int ChangeCritical { get; }
    }
}
