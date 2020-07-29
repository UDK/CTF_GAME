﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CTF_GAME.Model.Exception;

namespace CTF_GAME.Model
{
    public class OasisGameOnMap : IObjectGameOnMap
    {
        private char ASCII = '8';

        public byte GetASCII
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

        public string Action(ref MapGame mapGame, string textAction)
        {
            throw new GameEndException("Thanks for the game, Wanderer");
        }

        public string EventStepOnGameObject(string textAction)
        {
            return "flag_ctf{govno}";
        }

        public ChangeAppearObjectMap GetRandom()
        {
            ChangeAppearObjectMap objChange = new ChangeAppearObjectMap() { changeRandom = 0, typeRandom = TypeRandom.UniqueRandom };
            return objChange;
        }
    }
}
