using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.MobsOnMap
{
    public class SimpleMobs : AbstractMobsOnMap
    {
        private char ASCII = 'q';

        private int _health = 75;

        private int _armor = 1;

        private int _changeDodge = 0;

        private int _changeCriticalDamage = 0;

        private int _maxHealthPoint = 75;

        private int _damage = 10;

        private int _experienceForUpMobs = 1000;

        public override byte GetASCIIOnMaps
        {
            get => (byte)ASCII;
        }

        public override string GetASCIIArtStart => "                              _.--\"\"-._\n  .                         .\"         \".\n / \\    ,^.         /(     Y             |      )\\n/   `---. |--'\\    (  \\__..'--   -   -- -'\"\"-.-'  )\n|        :|    `>   '.     l_..-------.._l      .'\n|      __l;__ .'      \"-.__.||_.-'v'-._||`\"----\"\n \\  .-' | |  `              l._       _.'\n  \\/    | |                   l`^^'^^'j\n        | |                _   \\_____/     _\n j |               l `--__)-'(__.--' |\n        | |               | /`---``-----'\"1 |  ,-----.\n        | |               )/  `--' '---'   \'-'  ___  `-.\n        | |              //  `-'  '`----'  /  ,-'   I`.  \\n      _ L |_            //  `-.-.'`-----' /  /  |   |  `. \\n     '._' / \\         _/(   `/   )- ---' ;  /__.J   L.__.\\ :\n      `._;/7(-.......'  /        ) (     |  |            | |\n      `._;l _'--------_/        )-'/     :  |___.    _._./ ;\n        | |                 .__ )-'\\  __  \\  \\  I   1   / /\n        `-'                /   `-\\-(-'   \\ \\  `.|   | ,' /\n                           \\__  `-'    __/  `-. `---'',-'\n                              )-._.-- (        `-----'\n                             )(  l\\ o ('..-.\n                       _..--' _'-' '--'.-. |\n                __,,-'' _,,-''            \\ \\\n               f'. _,,-'                   \\ \\\n              ()--  |                       \\ \\\n                \\.  |                       /  \\\n                  \\ \\                      |._  |\n                   \\ \\                     |  ()|\n                    \\ \\                     \\  /\n                     ) `-.                   | |\n                    // .__)                  | |\n                 _.//7'                      | |\n               '---'                         j_| `\n                                            (| |\n                                             |  \\n                                             |lllj\n                                             |||||  -nabis";

        public override int HealthPoint { get => _health; set => _health = value; }

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

        public override int MaxHealthPoint { get => _maxHealthPoint; set => _maxHealthPoint = value; }

        public override string GetASCIIArtEnd => "    \t\t\t\t                   ,--.\n                                                  {    }\n                                                  K,   }\n                                                 /  `Y`\n                                            _   /   /\n                                           {_'-K.__/\n                                             `/-.__L._\n                                             /  ' /`\\_}\n                                            /  ' /     -ART BY ZEUS-\n                                    ____   /  ' /\n                             ,-'~~~~    ~~/  ' /_\n                           ,'             ``~~~%%',\n                          (                     %  Y\n                         {                      %% I\n                        {      -                 %  `.\n                        |       ',                %  )\n                        |        |   ,..__      __. Y\n                        |    .,_./  Y ' / ^Y   J   )|\n                        \\           |' /   |   |   ||\n                         \\          L_/    . _ (_,.'(\n                          \\,   ,      ^^\"\"' / |      )\n                            \\_  \\          /,L]     /\n                              '-_`-,       ` `   ./`\n                                 `-(_            )\n                                     ^^\\..___,.--`\n Press \" for continue...";

        protected override int ExperienceForUpMobs { get => _experienceForUpMobs; set => _experienceForUpMobs = value; }

        protected override int ExperienceForDeath => 105 * lvlMobs;

        public override object Clone()
        {
            return new SimpleMobs();
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap
            {
                typeRandom = TypeRandom.RepeatingRandom,
                changeRandom = 8
            };
        }
    }
}
