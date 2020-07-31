using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps
{
    public abstract class AbstractMobsOnMap : IObjectGameOnMap
    {
        public abstract byte GetASCII { get; }

        public abstract string GetASCIIArt { get; }

        /// <summary>
        /// Уровень моба
        /// </summary>
        public abstract int lvlMobs { get; }

        /// <summary>
        /// Количество жизней
        /// </summary>
        public abstract int HealthPoint { get; set; }

        /// <summary>
        /// Шанс защиты. Возвращает число от 0 до 90, которое указывает на то, насколько должен быть снижен получемый урон
        /// </summary>
        public abstract int Armor { get; set; }

        /// <summary>
        /// Шанс Уклоненя. Возвращает число от 0 до 90, которое указывает на то, каков процент избежать урона
        /// </summary>
        public abstract int ChangeDodge { get; set; }

        /// <summary>
        /// Наносимый урон
        /// </summary>
        public abstract int Damage { get; set; }

        /// <summary>
        /// Шанс критического урона. Возвращает число от 0 до 90, шанс нанести урон в 200%
        /// </summary>
        public abstract int ChangeCriticalDamage { get; set; }

        private string _startFight = " ###### #  ####  #    # #####     ####  #####   ##   #####  ##### \n #      # #    # #    #   #      #        #    #  #  #    #   #   \n #####  # #      ######   #       ####    #   #    # #    #   #   \n #      # #  ### #    #   #           #   #   ###### #####    #   \n #      # #    # #    #   #      #    #   #   #    # #   #    #   \n #      #  ####  #    #   #       ####    #   #    # #    #   #   ";

        public string Action(ref MapGame mapGame, string textAction)
        {
            throw new NotImplementedException();
        }

        public string EventStepOnGameObject(string textAction)
        {
            return _startFight;
        }

        public abstract ChangeAppearObjectMap GetRandom();

        public abstract AbstractMobsOnMap LevelUp();
    }
}
