﻿using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CTF_GAME.Model.ModelForEvent;

namespace CTF_GAME.Controllers
{
    /// <summary>
    /// Посредник между логикой и клиентом, здесь обрабатываем все приходящие сообщения от сервера и ответы от Игрового контроллера
    /// </summary>
    public class CommunicationServer
    {
        public delegate void ClientNetworkClose(object sender, EventArgsNetworkClose args);

        public event ClientNetworkClose networkClose;

        private int ID { get; set; }

        const string _helloWorld = " #     # ###    ######                                                                        \n #     #  #     #     # #####   ####         #    # #  ####  ######    #####  #  ####  #    # \n #     #  #     #     # #    # #    #        ##   # # #    # #         #    # # #    # #   #  \n #######  #     ######  #    # #    #        # #  # # #      #####     #    # # #      ####   \n #     #  #     #     # #####  #    # ###    #  # # # #      #         #    # # #      #  #   \n #     #  #     #     # #   #  #    # ###    #   ## # #    # #         #    # # #    # #   #  \n #     # ###    ######  #    #  ####   #     #    # #  ####  ######    #####  #  ####  #    # \n";

        private GameController gameController;

        public NetworkStream networkStreamWithClient { get; set; }

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
                try
                {
                    string responseOfClient = await ServerSettings.ReadServerAsync(networkStreamWithClient);
                    string response = gameController.HandlerAction(Cut(responseOfClient));
                    await ServerSettings.ResponseServerAsync(networkStreamWithClient, response);
                }
                catch (IOException)
                {
                    networkClose(this, new EventArgsNetworkClose(this.ID));
                    break;
                }
            }
        }

        private void Hello()
        {
            ServerSettings.ResponseServerAsync(this.networkStreamWithClient, _helloWorld).GetAwaiter().GetResult();
        }

        private string Cut(string textCommand)
        {
            return textCommand.Substring(0, textCommand.IndexOf('\n'));
        }

    }
}
