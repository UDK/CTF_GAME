﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    /// <summary>
    /// Все объекты которые просто можно подобрать и продолжить движение
    /// </summary>
    public abstract class AbstactMethodCooperationWithMap : IObjectGameOnMap
    {
        public abstract byte GetASCIIOnMaps { get; }

        public abstract string Action(ref MapGame mapGame, string textAction);

        public abstract object Clone();

        public virtual string EventStepOnGameObject(string textAction)
        {
            return null;
        }

        public abstract ChangeAppearObjectMap GetRandom();

        /// <summary>
        /// Обработка перемещения
        /// </summary>
        /// <param name="textAction">комманда от клиента</param>
        protected void Move(ref MapGame mapGame, string textAction)
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
