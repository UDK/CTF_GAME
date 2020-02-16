using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CTF_GAME.Controllers
{
    [Route("/")]
    public class Controller : ControllerBase
    {
        public char[] Get()
        {
            return new char[] {'s','g'};
        }
    }
}