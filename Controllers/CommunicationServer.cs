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
    /// <summary>
    /// Здесь отдаем ответ клиенту
    /// </summary>
    public class CommunicationServer
    {
        const string _helloWorld = " #     # ###    ######                                                                        \n #     #  #     #     # #####   ####         #    # #  ####  ######    #####  #  ####  #    # \n #     #  #     #     # #    # #    #        ##   # # #    # #         #    # # #    # #   #  \n #######  #     ######  #    # #    #        # #  # # #      #####     #    # # #      ####   \n #     #  #     #     # #####  #    # ###    #  # # # #      #         #    # # #      #  #   \n #     #  #     #     # #   #  #    # ###    #   ## # #    # #         #    # # #    # #   #  \n #     # ###    ######  #    #  ####   #     #    # #  ####  ######    #####  #  ####  #    # \n";
        
        private NetworkStream networkStreamWithClient;
        public CommunicationServer(NetworkStream networkStream)
        {
            this.networkStreamWithClient = networkStream;
            Start();
        }

        public async void Start()
        {
            Hello();
            while (true)
            {
                string responseOfClient = await ServerSettings.ReadServerAsync(networkStreamWithClient);
                
            }
        }

        public void Hello()
        {
            ServerSettings.ResponseServerAsync(this.networkStreamWithClient, _helloWorld).GetAwaiter().GetResult();
        }


    }
}
