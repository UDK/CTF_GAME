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
    /// Посредник между логикой и клиентом, здесь обрабатываем все приходящие сообщения от сервера и ответы от Игрового контроллера
    /// </summary>
    public class CommunicationServer
    {
        const string _helloWorld = " #     # ###    ######                                                                        \n #     #  #     #     # #####   ####         #    # #  ####  ######    #####  #  ####  #    # \n #     #  #     #     # #    # #    #        ##   # # #    # #         #    # # #    # #   #  \n #######  #     ######  #    # #    #        # #  # # #      #####     #    # # #      ####   \n #     #  #     #     # #####  #    # ###    #  # # # #      #         #    # # #      #  #   \n #     #  #     #     # #   #  #    # ###    #   ## # #    # #         #    # # #    # #   #  \n #     # ###    ######  #    #  ####   #     #    # #  ####  ######    #####  #  ####  #    # \n";

        private GameController gameController;

        private NetworkStream networkStreamWithClient;

        public CommunicationServer(NetworkStream networkStream)
        {
            gameController = new GameController();
            this.networkStreamWithClient = networkStream;
            Start();
        }

        /// <summary>
        /// Ассинхронно стартуем обработку всех приходящих ответов с клиента
        /// </summary>
        private async void Start()
        {
            Hello();
            while (true)
            {
                string responseOfClient = await ServerSettings.ReadServerAsync(networkStreamWithClient);
                string response = gameController.HandlerAction(responseOfClient);
                await ServerSettings.ResponseServerAsync(networkStreamWithClient, response);
            }
        }

        private void Hello()
        {
            ServerSettings.ResponseServerAsync(this.networkStreamWithClient, _helloWorld).GetAwaiter().GetResult();
        }
    }
}
