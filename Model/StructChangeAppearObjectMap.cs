using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model
{
    public enum TypeRandom
    {
        UniqueRandom = 1,
        RepeatingRandom = 2
    }
    public struct ChangeAppearObjectMap
    {
        public TypeRandom typeRandom;
        public int changeRandom;
    }
}
