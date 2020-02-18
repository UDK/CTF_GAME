using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CTF_GAME.Controllers
{
    public class CommunicationServer
    {
        const string _helloWorld = " #     # ###    ######                                                                        \n #     #  #     #     # #####   ####         #    # #  ####  ######    #####  #  ####  #    # \n #     #  #     #     # #    # #    #        ##   # # #    # #         #    # # #    # #   #  \n #######  #     ######  #    # #    #        # #  # # #      #####     #    # # #      ####   \n #     #  #     #     # #####  #    # ###    #  # # # #      #         #    # # #      #  #   \n #     #  #     #     # #   #  #    # ###    #   ## # #    # #         #    # # #    # #   #  \n #     # ###    ######  #    #  ####   #     #    # #  ####  ######    #####  #  ####  #    # \n";
        
        private NetworkStream networkStreamWithClient;
        public CommunicationServer(NetworkStream networkStream)
        {
            this.networkStreamWithClient = networkStream;
            Start();
        }

        public void Start()
        {
            Hello();
        }

        public void Hello()
        {
            Server.ResponseServerAsync(this.networkStreamWithClient, _helloWorld).GetAwaiter().GetResult();
        }



    }
}
