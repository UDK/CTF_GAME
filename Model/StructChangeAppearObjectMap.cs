using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public enum TypeRandom
    {
        /// <summary>
        /// Уникальный объект, встречается один раз за игру
        /// </summary>
        UniqueRandom = 1,
        /// <summary>
        /// Объект, который встречается один/несолько раз за игру
        /// </summary>
        RepeatingRandom = 2,
        /// <summary>
        /// Никогда не встречающийся объект
        /// </summary>
        Never = 3
    }
    public struct ChangeAppearObjectMap
    {
        public TypeRandom typeRandom;
        public int changeRandom;
    }
}
