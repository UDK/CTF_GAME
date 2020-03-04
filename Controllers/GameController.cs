using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTF_GAME.Model;
using System.Text;

namespace CTF_GAME.Controllers
{
    /// <summary>
    /// Здесь будет весь функционал взаимодействия с игроком(вся логика)
    /// </summary>
    public class GameController
    {
        /// <summary>
        /// Размер выводимой карты по горизонтали
        /// </summary>
        const int _sizeHor = 100;

        /// <summary>
        /// Размер выводимой карты по вертикали
        /// </summary>
        const int _sizeVert = 50;

        MapGame mapGame;
        public MapGame MapGame { get => mapGame; private set=> this.mapGame = value; }
        public GameController()
        {
            MapGame = new MapGame();
            MapGame.Initialization(new FieldGameOnMap(100, false));
        }

        /// <summary>
        /// Обрабтка присланной команды от клиента
        /// </summary>
        /// <param name="textAction">комманда</param>
        /// <returns>Ответ либо карта, либо что-то другое</returns>
        public string HandlerAction(string textAction)
        {
            IObjectGameOnMap gameObject = MapGame.GetObjectPointMap(MapGame.GameHor, MapGame.GameVert);
            gameObject.Action(ref this.mapGame, textAction);
            return GetGameMap(_sizeHor, _sizeVert);

        }
        /// <summary>
        /// Получаем карту с определенной областью видимости вокруг
        /// </summary>
        /// <param name="sizeHori">видимость по горизонтали</param>
        /// <param name="sizeVert">видимость по вертикали</param>
        /// <returns></returns>
        public string GetGameMap(int sizeHori, int sizeVert)
        {
            return MapGame.CenterViewMap(sizeHori, sizeVert);
        }
    }
}
