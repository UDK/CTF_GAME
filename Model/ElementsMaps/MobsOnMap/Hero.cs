using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.MobsOnMap
{
    public class Hero : AbstractMobsOnMap
    {
        public override byte GetASCII => throw new NotImplementedException();

        public override string GetASCIIArt => throw new NotImplementedException();

        public override int lvlMobs => throw new NotImplementedException();

        public override int HealthPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Armor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int ChangeDodge { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int Damage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override int ChangeCriticalDamage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override ChangeAppearObjectMap GetRandom()
        {
            throw new NotImplementedException();
        }

        public override AbstractMobsOnMap LevelUp()
        {
            throw new NotImplementedException();
        }
    }
}
