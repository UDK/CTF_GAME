using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ElementsMaps.ElementsMoveOnMap
{
    public class DwarfFortressGameOnMap : AbstactMethodCooperationWithMap
    {
        private const string message = "You've wandered into an abandoned dwarven fortress... It was once a bustling place, but now it has long been forgotten.\n";

        public override byte GetASCII => (byte)'u';

        public override string Action(ref MapGame mapGame, string textAction)
        {
            Move(ref mapGame, textAction);
            return mapGame.CenterViewMap();
        }

        public override string EventStepOnGameObject(string textAction)
        {
            return message;
        }

        public override ChangeAppearObjectMap GetRandom()
        {
            return new ChangeAppearObjectMap() { typeRandom = TypeRandom.UniqueRandom };
        }
    }
}
