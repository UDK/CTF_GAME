using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    /// <summary>
    /// От этого интерфейса должны наследоваться все игровые объекты на карте
    /// </summary>
    public interface IObjectGameOnMap
    {

        /// <summary>
        /// Класс работы с рандомом
        /// </summary>
        int GetRandom();
        /// <summary>
        /// Возвращает ASCII представление объекта
        /// </summary>
        /// <returns>Представление объекта на карте, в виде ASCII кода</returns>
        public byte GetASCII { get; }

        public void Action(ref MapGame mapGame, string textAction);
    }
}
