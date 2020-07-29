using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public enum TypeRandom
    {
        /// <summary>
        /// Уникальный предмет, встречается один раз за игру
        /// </summary>
        UniqueRandom = 1,
        /// <summary>
        /// Предмет, который встречается один/несолько раз за игру
        /// </summary>
        RepeatingRandom = 2
    }
    public struct ChangeAppearObjectMap
    {
        public TypeRandom typeRandom;
        public int changeRandom;
    }
}
