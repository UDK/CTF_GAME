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

        public void Action(ref MapGame mapGame, string textAction)
        {
            Move(ref mapGame, textAction);
        }

        int IObjectGameOnMap.GetRandom()
        {
            return 100;
        }
        /// <summary>
        /// Обработка перемещения
        /// </summary>
        /// <param name="textAction">комманда от клиента</param>
        private void Move(ref MapGame mapGame, string textAction)
        {
            if (textAction == "d")
            {
                mapGame.GameHor += 1;
            }
            if (textAction == "a")
            {
                mapGame.GameHor -= 1;
            }
            if (textAction == "w")
            {
                mapGame.GameVert -= 1;
            }
            if (textAction == "s")
            {
                mapGame.GameVert += 1;
            }
        }
    }
}
