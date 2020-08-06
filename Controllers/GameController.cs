using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTF_GAME.Model;
using System.Text;
using CTF_GAME.Model.ElementsMaps.MobsOnMap;
using CTF_GAME.Model.ElementsMaps.ElementsMoveOnMap;

namespace CTF_GAME.Controllers
{
    /// <summary>
    /// Здесь будет весь функционал взаимодействия с игроком(вся логика)
    /// </summary>
    public class GameController
    {

        MapGame mapGame;
        public MapGame MapGame { get => mapGame; private set=> this.mapGame = value; }
        public GameController()
        {
            MapGame = new MapGame(30);
            MapGame.Initialization(new FieldGameOnMap(), new OasisGameOnMap(), new SwoardGameOnMap(),
                new SimpleMobs(), new DwarfFortressGameOnMap(), new MedicalKitGameOnMap(), new BigBoss(),
                new CunningGoblin());
        }

        /// <summary>
        /// Обрабтка присланной команды от клиента
        /// </summary>
        /// <param name="textAction">комманда</param>
        /// <returns>Ответ либо карта, либо что-то другое</returns>
        public string HandlerAction(string textAction)
        {
            //Здесь на StringBuilder желательно заменить
            string actionResponse = MapGame.GetObjectPointMap(MapGame.GameHor, MapGame.GameVert).Action(ref this.mapGame, textAction);
            string eventResponse = MapGame.GetObjectPointMap(MapGame.GameHor, MapGame.GameVert).EventStepOnGameObject(textAction);
            return actionResponse + '\n' + eventResponse;
        }
        /// <summary>
        /// Получаем карту с определенной областью видимости вокруг
        /// </summary>
        /// <param name="sizeHori">видимость по горизонтали</param>
        /// <param name="sizeVert">видимость по вертикали</param>
        /// <returns></returns>
        public string GetGameMap(int sizeHori, int sizeVert)
        {
            return MapGame.CenterViewMap();
        }
    }
}
