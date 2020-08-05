using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.ElementsMoveOnMap
{
    public class MedicalKitGameOnMap : AbstactMethodCooperationWithMap
    {
        private readonly string [] message = {
            "You found a delicious bun and ate it :)\n",
            "It turned out to exchange a couple of beautiful shells for a pack of plasters\n",
            "You came across a tavern where there was a competition for eating meat bugs. You didn't win, but you had a good dinner.\n"
        };

        private readonly Random random = new Random();

        public override byte GetASCIIOnMaps => (byte)'+';

        public override string Action(ref MapGame mapGame, string textAction)
        {
            mapGame.hero.HealthPoint += 20;
            Move(ref mapGame, textAction);
            return mapGame.CenterViewMap();
        }

        public override object Clone()
        {
            return new MedicalKitGameOnMap();
        }

        public override string EventStepOnGameObject(string textAction)
        {
            return message[random.Next(0, message.Length)];
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap() { typeRandom = TypeRandom.RepeatingRandom, changeRandom = 3 };
        }
    }
}
