using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class StructQuestionsForEndGame
    {
        //Стоит arAnswer и goodAnswer вынести в отдельный класс
        public StructQuestionsForEndGame(string questions, string [] arAnswer, int goodAnswer)
        {

        }
        public string questions { get;private set; }

        public int goodAnswer {private get; set; }

        public string[] arAnswer { get;private set; }

        public bool CheckAnswer(int option)
        {
            if(goodAnswer)
        }

    }
}
