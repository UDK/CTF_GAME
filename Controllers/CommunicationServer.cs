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
        const string _helloWorld = "Hi Bro, nice dick";
        
        private NetworkStream networkStreamWithClient;
        public CommunicationServer(NetworkStream networkStream)
        {
            this.networkStreamWithClient = networkStream;
            Hello();
            Console.WriteLine(Server.ReadServerAsync(networkStreamWithClient).GetAwaiter().GetResult());
        }

        public void Hello()
        {
            Server.ResponseServerAsync(this.networkStreamWithClient, _helloWorld).GetAwaiter().GetResult();
        }



    }
}
