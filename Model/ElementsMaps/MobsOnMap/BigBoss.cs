using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.MobsOnMap
{
    public class BigBoss : AbstractMobsOnMap
    {
        private int _health = 1000;

        private int _armor = 35;

        private int _changeDodge = 15;

        private int _changeCriticalDamage = 8;

        private int _damage = 96;

        private int _maxHealthPoint = 1000;

        private int _lvlUpMobs = 10000;

        public override byte GetASCIIOnMaps => (byte)'!';

        public override string GetASCIIArtStart => "\n                 ___====-_  _-====___\n           _--^^^#####//      \\#####^^^--_\n        _-^##########// (    ) \\##########^-_\n       -############//  |\\^^/|  \\############-\n     _/############//   (@::@)   \\############\\_\n    /#############((     \\//     ))#############\n   -###############\\    (oo)    //###############-\n  -#################\\  / VV \\  //#################-\n -###################\\/      \\//###################-\n_#/|##########/\\######(   /\\   )######/\\##########|\\#_\n|/ |#/\\#/\\#/\\/  \\#/\\##\\  |  |  /##/\\#/  \\/\\#/\\#/\\#| \\|\n`  |/  V  V  `   V  \\#\\| |  | |/#/  V   '  V  V  \\|  '\n   `   `  `      `   / | |  | | \\   '      '  '   '\n                    (  | |  | |  )\n                   __\\ | |  | | /__\n                  (vvv(VVV)(VVV)vvv)";

        public override string GetASCIIArtEnd => "flag_ctf{DEMO_FLAG_PART_II}";

        public override int MaxHealthPoint { get => _maxHealthPoint; set => _maxHealthPoint = value; }

        public override int HealthPoint
        {
            get => _health;
            set
            {
                if (value > MaxHealthPoint)
                    _health = MaxHealthPoint;
                else
                    _health = value;
            }
        }
        public override int Armor
        {
            get
            {
                if (_armor <= 90 && _armor > 0)
                    return _armor;
                else if (_armor > 90)
                    return 90;
                else
                    return 0;
            }
            set => _armor = value;
        }
        public override int ChangeDodge
        {
            get
            {
                if (_changeDodge <= 90 && _changeDodge > 0)
                    return _changeDodge;
                else if (_changeDodge > 90)
                    return 90;
                else
                    return 0;
            }
            set => _changeDodge = value;
        }

        public override int Damage
        {
            get
            {
                if (_damage < 1)
                    return 1;
                else
                    return _damage;
            }
            set => _damage = value;
        }

        public override int ChangeCriticalDamage
        {
            get
            {
                if (_changeCriticalDamage < 0)
                    return 0;
                else if (_changeCriticalDamage > 100)
                    return 100;
                else
                    return _changeCriticalDamage;
            }
            set => _changeCriticalDamage = value;
        }

        protected override int ExperienceForUpMobs { get => _lvlUpMobs; set => _lvlUpMobs = value; }

        protected override int ExperienceForDeath => 500 * lvlMobs;

        public override object Clone()
        {
            return new BigBoss();
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap() { typeRandom = TypeRandom.UniqueRandom };
        }
    }
}
