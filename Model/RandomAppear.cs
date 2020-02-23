using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class RandomAppear
    {

        private bool appearOnce { get; set; }

        private int changeAppereance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appearOnce">Появление этого вида элемента карты единожды</param>
        /// <param name="changeAppereance">Шанс рандома</param>
        public RandomAppear(bool appearOnce, int changeAppereance)
        {
            this.appearOnce = appearOnce;
            this.changeAppereance = changeAppereance;
        }

        //bool GetRandom()
        //{
        //    Random random = new Random();
        //    random.Next(1, 100);

        //}

    }
}
