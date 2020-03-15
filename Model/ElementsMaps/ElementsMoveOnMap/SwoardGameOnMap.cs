using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class SwoardGameOnMap : AbstactMethodCooperationWithMap
    {
        private const string message = "WOW, this big and very powerful sword. I will have been hoping to me\n";
        private char ASCII = '|';
        public override byte GetASCII
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
            Move(ref mapGame, textAction);
            return mapGame.CenterViewMap();
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            ChangeAppearObjectMap objChange = new ChangeAppearObjectMap() { changeRandom = 0, typeRandom = TypeRandom.UniqueRandom };
            return objChange;
        }
        public override string EventStepOnGameObcject(string textAction)
        {
            return message;
        }
    }
}
