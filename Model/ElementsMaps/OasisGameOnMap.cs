using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return "flag_ctf{govno}";
        }

        public int GetRandom()
        {
            throw new NotImplementedException();
        }
    }
}
