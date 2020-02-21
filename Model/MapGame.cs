using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    /// <summary>
    /// Карта с созданными объекатами на ней ней
    /// </summary>
    public class MapGame
    {
        /// <summary>
        /// Где находится игрок по вертикали
        /// </summary>
        private int gameVert;

        /// <summary>
        /// Где находится игрок по горизонтали
        /// </summary>
        private int gameHor;
        int GameVert
        {
            get
            {
                return gameVert;
            }
            set
            {
                switch(value)
                {
                    case 0:
                        gameVert = 0;
                        break;
                    case _lngMaps:
                        gameVert = _lngMaps;
                        break;
                    default:
                        gameVert = value;
                        break;
                }
            }
        }

        int GameHor
        {
            get
            {
                return gameHor;
            }
            set
            {
                switch (value)
                {
                    case 0:
                        gameHor = 0;
                        break;
                    case _lngMaps:
                        gameHor = _lngMaps;
                        break;
                    default:
                        gameHor = value;
                        break;
                }
            }
        }

        const int _lngMaps = 2000;

        private IObjectGameOnMap[,] mapsObject = new IObjectGameOnMap[_lngMaps, _lngMaps];

        public void Initialization(params IObjectGameOnMap[] obj)
        {
            for (int vert = 0; vert < mapsObject.GetLength(1); vert++)
            {
                for (int hor = 0; hor < mapsObject.GetLength(0); hor++)
                {
                    //Тестовый вариант, мб для этого стоит сделать ветку с dev. Надо будет заменить с рандомным выпадением
                    mapsObject[hor, vert] = obj[0];
                }
            }
        }
    }
}
