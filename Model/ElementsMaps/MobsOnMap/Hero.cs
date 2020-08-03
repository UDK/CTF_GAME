using CTF_GAME.Model.FightsAttack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.MobsOnMap
{
    public class Hero : AbstractMobsOnMap
    {
        public Hero()
        {
            attacksTechniques.Add(new CriticalAttack());
        }

        protected int _health = 100;

        protected int _armor = 25;

        protected int _changeDodge = 5;

        protected int _changeCriticalDamage = 1;

        protected int _damage = 35;

        public override byte GetASCII => (byte)' ';

        public override string GetASCIIArt => "";

        public override int lvlMobs => 1;

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
                    return _changeDodge * 10;
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

        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap { typeRandom = TypeRandom.Never};
        }

        public override AbstractMobsOnMap LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
