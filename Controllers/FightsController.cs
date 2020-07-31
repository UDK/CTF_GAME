using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Controllers
{
    public class FightsController
    {
        private AbstractMobsOnMap _hero;

        private AbstractMobsOnMap _enemy;

        public FightsController(AbstractMobsOnMap hero, AbstractMobsOnMap enemy)
        {
            _hero = hero;
            _enemy = enemy;
        }

        public void FightsDo(string action)
        { 
            
        }
    }
}
