using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.MobsOnMap
{
    public class CunningGoblin : AbstractMobsOnMap
    {
        private int _health = 110;

        private int _armor = 9;

        private int _changeDodge = 20;

        private int _changeCriticalDamage = 25;

        private int _damage = 32;

        private int _maxHealthPoint = 110;

        private int _experienceForUpMobs = 500;

        public override byte GetASCIIOnMaps => (byte)'2';

        public override string GetASCIIArtStart => null;

        public override string GetASCIIArtEnd => "             ,      ,\n            /(.-\"\"-.)\\\n        |\\  \\/      \\/  /|\n        | \\ / =.  .= \\ / |\n        \\( \\   o\\/o   / )/\n         \\_, '-/  \\-' ,_/\n           /   \\__/   \n           \\ \\__/\\__/ /\n         ___\\ \\|--|/ /___\n       /`    \\      /    `\n  jgs /       '----'       ";

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

        protected override int ExperienceForUpMobs { get => _experienceForUpMobs; set => _experienceForUpMobs = value; }

        protected override int ExperienceForDeath => 135 * lvlMobs;

        public override object Clone()
        {
            return new CunningGoblin();
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap() { changeRandom = 6, typeRandom = TypeRandom.RepeatingRandom };
        }
    }
}
