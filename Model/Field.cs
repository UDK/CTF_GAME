using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class Field : IObjectGameOnMap
    {
        private char ASCII = '~';
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
    }
}
