using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTF_GAME.Controllers;

namespace CTF_GAME.Model.ElementsMaps
{
    public abstract class AbstractMobsOnMap : IObjectGameOnMap
    {
        /// <summary>
        /// отвечает за то, первый раз находится герой на это позиции или повторный?
        /// </summary>
        private bool _checkThis = true;

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

        private const string _startFight = " ###### #  ####  #    # #####     ####  #####   ##   #####  ##### \n #      # #    # #    #   #      #        #    #  #  #    #   #   \n #####  # #      ######   #       ####    #   #    # #    #   #   \n #      # #  ### #    #   #           #   #   ###### #####    #   \n #      # #    # #    #   #      #    #   #   #    # #   #    #   \n #      #  ####  #    #   #       ####    #   #    # #    #   #   ";

        private FightsController fightsAttack;

        public string Action(ref MapGame mapGame, string textAction)
        {
            if (fightsAttack == null)
                fightsAttack = new FightsController(mapGame.hero, this);
            fightsAttack.FightsDo(textAction);
            //
            return "       # ##### ##### ##### ##### ##### ##### ##### ##### ##### #       \n      #                                                         #      \n     #                                                           #     \n    #                                                             #    \n   #                                                               #   \n  #                                                                 #  \n #                                                                   #  \n              HERO                                ENEMY                                       \n #                                 #                                 #  \n #      HP:                        #      HP: {HealthPoint}          #  \n #                                 #                                 #  \n        ARMOR:                            ARMOR:                                           \n #                                 #                                 #  \n #      CHANGE DODGE:              #      CHANGE DODGE:              #  \n #                                 #                                 #  \n                                                                       \n #                                                                   # \n  #                                                                 #  \n   #                                                               #   \n    #    													      #    \n     #                                                           #     \n      #                                                         #      \n       # ##### ##### ##### ##### ##### ##### ##### ##### ##### #  ";
        }

        public string EventStepOnGameObject(string textAction)
        {
            if (_checkThis)
            {
                _checkThis = false;
                return _startFight;
            }
            else
                return "";
        }

        public abstract ChangeAppearObjectMap GetRandom();

        public abstract AbstractMobsOnMap LevelUp();
    }
}
