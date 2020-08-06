using CTF_GAME.Model.ElementsMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.FightsAttack
{
    public abstract class IAttack
    {
        /// <summary>
        /// Название атаки
        /// </summary>
        public abstract string NameAttack { get; }

        /// <summary>
        /// Наносимый урон
        /// </summary>
        public abstract int Damage { get; }

        /// <summary>
        /// Шанс критического удара
        /// </summary>
        public abstract int ChangeCritical { get; }

        /// <summary>
        /// Описание атаки которое надо выводить игроку 
        /// </summary>
        public string OutputText => $"{NameAttack}  ==Damage: {Damage}==  ==Change critical attack: {ChangeCritical}==";
    }
}
