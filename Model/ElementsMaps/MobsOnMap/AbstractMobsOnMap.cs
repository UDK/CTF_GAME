using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using CTF_GAME.Controllers;
using CTF_GAME.Model.FightsAttack;

namespace CTF_GAME.Model.ElementsMaps
{
    public abstract class AbstractMobsOnMap : IObjectGameOnMap
    {
        /// <summary>
        /// отвечает за то, первый раз находится герой на это позиции или повторный?
        /// </summary>
        private bool _checkThis = true;

        /// <summary>
        /// Текущее значения полученного опыта
        /// </summary>
        private int _experience = 1;

        protected int _lvl = 1;

        public abstract byte GetASCII { get; }

        public abstract string GetASCIIArt { get; }

        /// <summary>
        /// Значение при котором Моб повысит себе уровень
        /// </summary>
        protected abstract int LvlUpMobs { get; set; }

        /// <summary>
        /// Сколько опыта получить объект победивший этого моба
        /// </summary>
        protected abstract int ExperienceForDeath { get; }

        /// <summary>
        /// Максимальное количество жизней
        /// </summary>
        public abstract int MaxHealthPoint { get; set; }

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

        /// <summary>
        /// Все атаки моба
        /// </summary>
        public List<IAttack> attacksTechniques { get; set; } = new List<IAttack>(2);

        /// <summary>
        /// Уровень моба
        /// </summary>
        public int lvlMobs
        {
            get
            {
                return _lvl;
            }
            set
            {
                if (value >= LvlUpMobs)
                {
                    LvlUp();
                    lvlMobs = Math.Abs(value - LvlUpMobs);
                }
            }
        }

        public AbstractMobsOnMap()
        {
            attacksTechniques.Add(new BaseAttack());
        }

        public AbstractMobsOnMap(IAttack[] attacks)
        {
            attacksTechniques.AddRange(attacks);
        }

        private FightsController fightsAttack;

        private const string _startFight = " ###### #  ####  #    # #####     ####  #####   ##   #####  ##### \n #      # #    # #    #   #      #        #    #  #  #    #   #   \n #####  # #      ######   #       ####    #   #    # #    #   #   \n #      # #  ### #    #   #           #   #   ###### #####    #   \n #      # #    # #    #   #      #    #   #   #    # #   #    #   \n #      #  ####  #    #   #       ####    #   #    # #    #   #   ";

        public string Action(ref MapGame mapGame, string textAction)
        {
            if (fightsAttack == null)
                fightsAttack = new FightsController(mapGame.hero, this);
            if (fightsAttack.FightsDo(textAction))
                mapGame.ClearMapsCell();
            else
            {
                StringBuilder output = new StringBuilder($"\n       # ##### ##### ##### ##### ##### ##### ##### ##### ##### #     \n     #                                                           #     \n   #                                                               #    \n #                                                                   #  \n              HERO                                ENEMY               \n #                                 #                                 #  \n        HP:  {mapGame.hero.HealthPoint}                            HP: {HealthPoint}\n #                                 #                                 #  \n        ARMOR:  {mapGame.hero.Armor}                          ARMOR:  {Armor}\n #                                 #                                 #  \n        CHANGE DODGE:  {mapGame.hero.ChangeDodge}                   CHANGE DODGE:  {ChangeDodge}\n #                                 #                                 #  \n                                                                       \n #                                                                   # \n   #                                                               #   \n     #                                                           #        \n       # ##### ##### ##### ##### ##### ##### ##### ##### ##### #  ", 2048);
                StringBuilder indents = new StringBuilder(16);
                output.Append("\nEnter the number corresponding to the attack:");
                for (int i = 0; i < mapGame.hero.attacksTechniques.Count; i++)
                {
                    IAttack attack = mapGame.hero.attacksTechniques[i];
                    output.Append($"\n{i})");
                    output.Append(indents.Append(' '));
                    output.Append(indents);
                    output.Append(attack.OutputText);
                }
                return output.ToString();
            }
            return "qq";
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

        /// <summary>
        /// Увеличивает основные характеристики (использовать при получение нового уровня)
        /// </summary>
        public virtual void LvlUp()
        {
            LvlUpMobs *= 2;
            MaxHealthPoint += 30;
            HealthPoint = MaxHealthPoint;
            Armor += 2;
            ChangeCriticalDamage += 2;
            Damage += 5;
        }
    }
}
