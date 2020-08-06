using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class SwoardGameOnMap : AbstactMethodCooperationWithMap
    {
        private const string MESSAGE = "WOW, this big and very powerful sword. I will have been hoping to me\n";
        private const int ADD_DAMAGE = 52;
        private char ASCII = '|';
        public override byte GetASCIIOnMaps
        {
            get
            {
                try
                {
                    return (byte)ASCII;

                }
                catch
                {
                    return (byte)' ';
                }
            }
        }
        public override string Action(ref MapGame mapGame, string textAction)
        {
            mapGame.hero.Damage += ADD_DAMAGE;
            mapGame.ClearMapsCell();
            Move(ref mapGame, textAction);
            return mapGame.CenterViewMap();
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            ChangeAppearObjectMap objChange = new ChangeAppearObjectMap() { changeRandom = 0, typeRandom = TypeRandom.UniqueRandom };
            return objChange;
        }
        public override string EventStepOnGameObject(string textAction)
        {
            return MESSAGE;
        }

        public override object Clone()
        {
            return new SwoardGameOnMap();
        }
    }
}
