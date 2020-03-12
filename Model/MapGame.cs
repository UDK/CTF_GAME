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
        const int _sizeHor = 100;
        /// <summary>
        /// Размер выводимой карты по вертикали
        /// </summary>
        const int _sizeVert = 50;
        /// <summary>
        /// Максимальный размер карты
        /// </summary>
        const int _lngMaps = 2000;
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
                else if (value > _lngMaps)
                {
                    gameVert = _lngMaps;
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
                else if (value > _lngMaps)
                {
                    gameHor = _lngMaps;
                }
                else
                {
                    gameHor = value;
                }
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


        private IObjectGameOnMap[,] mapsObject = new IObjectGameOnMap[_lngMaps, _lngMaps];

        public void Initialization(params IObjectGameOnMap[] obj)
        {
            InitializationRandomObject(obj);
        }

        private void InitializationRandomObject(IObjectGameOnMap[] obj)
        {
            List<IObjectGameOnMap> objRepeating = obj.Where(ob => ob.GetRandom().typeRandom == TypeRandom.RepeatingRandom).ToList();
            for (int vert = 0; vert < mapsObject.GetLength(1); vert++)
            {
                for (int hor = 0; hor < mapsObject.GetLength(0); hor++)
                {
                    mapsObject[hor, vert] = ChoiceRandomObject(ref objRepeating);
                }
            }
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
        /// <param name="obj">Передаю по ссылке, чтобы работало быстрее</param>
        /// <returns></returns>
        private IObjectGameOnMap ChoiceRandomObject(ref List<IObjectGameOnMap> obj)
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

        public string CenterViewMap(int conclusionLenghtZoneHor = _sizeHor, int conclusionLenghtZoneVert = _sizeVert)
        {
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
            if (hor < 0 || hor > _lngMaps || vert < 0 || vert > _lngMaps)
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
            if (hor < 0 || hor > _lngMaps || vert < 0 || vert > _lngMaps)
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
