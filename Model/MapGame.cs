using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public class MapGame
    {
        const int _lngMaps = 2000;

        private IObjectGameOnMap[,] mapsObject = new IObjectGameOnMap[_lngMaps,_lngMaps];
    }
}
