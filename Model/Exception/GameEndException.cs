using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.Exception
{
    /// <summary>
    /// Исключения для конца игры
    /// </summary>
    public class GameEndException : System.Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Сообщение для вывода игроку при окончании игры</param>
        public GameEndException(string message)
            : base(message) { }
    }
}
