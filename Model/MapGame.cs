using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace CTF_GAME.Model
{
    /// <summary>
    /// Карта с созданными объекатами на ней ней
    /// </summary>
    public class MapGame
    {
        /// <summary>
        /// Размер выводимой карты по горизонтали
        /// </summary>
        int _sizeHor { get; set; }
        /// <summary>
        /// Размер выводимой карты по вертикали
        /// </summary>
        int _sizeVert { get; set; }
        /// <summary>
        /// Максимальный размер карты
        /// </summary>
        int _lngMaps;
        /// <summary>
        /// Символ персонажа
        /// </summary>
        const char _symbolPerson = '0';
        /// <summary>
        /// Символ конца карты
        /// </summary>
        const char _voidMapPoint = '\\';
        /// <summary>
        /// Где находится игрок по вертикали
        /// </summary>
        private int gameVert;
        /// <summary>
        /// Где находится игрок по горизонтали
        /// </summary>
        private int gameHor;
        public int GameVert
        {
            get
            {
                return gameVert;
            }
            set
            {
                if (value < 0)
                {
                    gameVert = 0;
                }
                else if (value >= _lngMaps)
                {
                    gameVert = gameVert;
                }
                else
                {
                    gameVert = value;
                }
            }
        }
        public int GameHor
        {
            get
            {
                return gameHor;
            }
            set
            {
                if (value < 0)
                {
                    gameHor = 0;
                }
                else if (value >= _lngMaps)
                {
                    gameHor = gameHor;
                }
                else
                {
                    gameHor = value;
                }
            }


        }

        public int LnghtMaps
        {
            get => _lngMaps;
            set
            {
                if (value <= _sizeVert)
                {
                    _sizeVert = value - 1;
                }
                if (value <= _sizeHor)
                {
                    _sizeHor = value - 1;
                }
                _lngMaps = value;
            }
        }

        IObjectGameOnMap this[int hor, int vert]
        {
            get
            {
                return this.mapsObject[hor, vert];
            }
            set
            {
                this.mapsObject[hor, vert] = value;
            }
        }

        public MapGame(int lenghtMaps = 2000, int sizeViewHor = 100, int sizeViewVert = 50)
        {
            _sizeHor = sizeViewHor;
            _sizeVert = sizeViewVert;
            LnghtMaps = lenghtMaps;
            this.mapsObject = new IObjectGameOnMap[LnghtMaps, LnghtMaps];
        }

        private IObjectGameOnMap[,] mapsObject;

        public async void Initialization(params IObjectGameOnMap[] obj)
        {
            await Task.Run(() => InitializationRandomObject(obj));
        }

        /// <summary>
        /// Инициализация объектов на карте
        /// </summary>
        /// <param name="obj"></param>
        private void InitializationRandomObject(IObjectGameOnMap[] obj)
        {
            PlacementRepeatingObjectMaps(obj);
            PlacementUniqueObjectMaps(obj);
        }

        private void PlacementRepeatingObjectMaps(IObjectGameOnMap[] obj)
        {
            List<IObjectGameOnMap> objRepeating = obj.Where(ob => ob.GetRandom().typeRandom == TypeRandom.RepeatingRandom).ToList();
            for (int vert = 0; vert < mapsObject.GetLength(1); vert++)
            {
                for (int hor = 0; hor < mapsObject.GetLength(0); hor++)
                {
                    mapsObject[hor, vert] = ChoiceRandomObject(objRepeating);
                }
            }
        }

        /// <summary>
        /// Расстановка уникальных объектов на карте
        /// </summary>
        /// <param name="obj"></param>
        private void PlacementUniqueObjectMaps(IObjectGameOnMap[] obj)
        {
            List<IObjectGameOnMap> objUnique = obj.Where(ob => ob.GetRandom().typeRandom == TypeRandom.UniqueRandom).ToList();
            foreach (var obUnique in objUnique)
            {
                Random random = new Random();
                mapsObject[random.Next(0, _lngMaps), random.Next(0, _lngMaps)] = obUnique;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj">массив объектов для карты</param>
        /// <returns></returns>
        private IObjectGameOnMap ChoiceRandomObject(List<IObjectGameOnMap> obj)
        {
            Random randomChange = new Random();
            IObjectGameOnMap objectGameOnMapBestRandom = null;
            int BestNumberRandom = -1;
            foreach (var ob in obj)
            {
                int randomIntChange = randomChange.Next(0, ob.GetRandom().changeRandom);
                if (BestNumberRandom < randomIntChange)
                {
                    objectGameOnMapBestRandom = ob;
                    BestNumberRandom = randomIntChange;
                }
            }
            return objectGameOnMapBestRandom;
        }

        /// <summary>
        /// Получить центр карты относительно игрока
        /// </summary>
        /// <returns></returns>
        public string CenterViewMap()
        {
            int conclusionLenghtZoneHor = _sizeHor, conclusionLenghtZoneVert = _sizeVert;
            StringBuilder viewMap = new StringBuilder();
            for (int vert = -conclusionLenghtZoneVert / 2; vert < conclusionLenghtZoneVert / 2; vert++)
            {
                for (int hor = -conclusionLenghtZoneHor / 2; hor < conclusionLenghtZoneHor / 2; hor++)
                {
                    viewMap.Append(GetCharPointMap(GameHor + hor, gameVert + vert));
                }
                viewMap.Append('\n');
            }
            return viewMap.ToString();
        }
        /// <summary>
        /// Получаем ASCII код с указанной точки на карте
        /// </summary>
        /// <param name="hor">точка по горизонтали</param>
        /// <param name="vert">точка по вертикали</param>
        /// <returns>полученный ответ</returns>
        public char GetCharPointMap(int hor, int vert)
        {
            if (hor < 0 || hor >= _lngMaps || vert < 0 || vert >= _lngMaps)
            {
                return _voidMapPoint;
            }
            else if (hor == GameHor && vert == GameVert)
            {
                return _symbolPerson;
            }
            else
            {
                return (char)mapsObject[hor, vert].GetASCII;
            }
        }
        public IObjectGameOnMap GetObjectPointMap(int hor, int vert)
        {
            if (hor < 0 || hor >= _lngMaps || vert < 0 || vert >= _lngMaps)
            {
                return null;
            }
            else
            {
                return mapsObject[hor, vert];
            }
        }

    }
}
