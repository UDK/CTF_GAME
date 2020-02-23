using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class FieldGameOnMap : IObjectGameOnMap
    {
        private char ASCII = '~';


        RandomAppear random;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="change">Шанс появление объект карты значение от 1 до 99</param>
        /// <param name="uniqueness">Уникальность, встретится объект карты единожды(true) или несколько раз(false)</param>
        public FieldGameOnMap(int change, bool uniqueness)
        {
            this.random = new RandomAppear(uniqueness, change);
        }

        byte IObjectGameOnMap.GetASCII
        {
            get
            {
                try
                {
                    return (byte)ASCII;
                }
                catch
                {
                    return (byte)' ';
                }
            }
        }

        int IObjectGameOnMap.GetRandom()
        {
            return 100;
        }
    }
}
