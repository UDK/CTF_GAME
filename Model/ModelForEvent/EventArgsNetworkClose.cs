using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CTF_GAME.Model.ModelForEvent
{
    public class EventArgsNetworkClose
    {
        public EventArgsNetworkClose(int ID) { this.ID = ID; }

        public int ID {get;}
    }
}
