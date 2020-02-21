using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTF_GAME.Model;

namespace CTF_GAME.Controllers
{
    /// <summary>
    /// Здесь будет весь функционал взаимодействия с игроком(вся логика)
    /// </summary>
    static public class GameController
    {

        static public MapGame mapGame { get; set; }
        static public void Initialization()
        {
            mapGame = new MapGame();
            mapGame.Initialization(new FieldGameOnMap(100, false));
        }

        static public void HandlerAction(string textAction)
        {

        }
    }
}
