using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public class BaseAttack : IAttacks
    {
        Random randomChange = new Random();

        private int _changeCriticalDamage = 0;

        private int _baseDamage = 38;
        public BaseAttack(AbstractMobsOnMap hero) : base(hero)
        { }

        public int Damage
        {
            get
            {
                return _baseDamage + _hero.Damage;
            }
        }

        public int ChangeCritical
        {
            get
            {
                return (100 - _changeCriticalDamage) * _hero.ChangeCriticalDamage + _changeCriticalDamage;
            }
        }
    }
}
