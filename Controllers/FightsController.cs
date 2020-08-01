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

        /// <summary>
        /// Процесс боя между двумя мобами с карты
        /// </summary>
        /// <param name="action">действие от игрока</param>
        /// <returns>Сообщает, закончился ли бой или нет</returns>
        public bool FightsDo(string action)
        {
            return false;
        }
    }
}
