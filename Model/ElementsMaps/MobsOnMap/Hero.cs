using CTF_GAME.Model.FightsAttack;
using CTF_GAME.Model.FightsAttack.PhysicsAttack;
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

        private int _health = 100;

        private int _armor = 15;

        private int _changeDodge = 5;

        private int _changeCriticalDamage = 1;

        private int _damage = 15;

        private int _maxHealthPoint = 100;

        private int _experienceForUpMobs = 100;

        public override byte GetASCIIOnMaps => (byte)' ';

        public override string GetASCIIArtStart => "";

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

        protected override int ExperienceForUpMobs { get => _experienceForUpMobs; set => _experienceForUpMobs = value; }

        protected override int ExperienceForDeath => 100 * lvlMobs;

        public override int MaxHealthPoint { get => _maxHealthPoint; set => _maxHealthPoint = value; }

        public override string GetASCIIArtEnd => throw new NotImplementedException();


        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap { typeRandom = TypeRandom.Never };
        }

        public override object Clone()
        {
            return new Hero();
        }
    }
}
