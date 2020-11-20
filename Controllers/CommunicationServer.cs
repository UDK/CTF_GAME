using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CTF_GAME.Model.ModelForEvent;
using CTF_GAME.Model.Exception;

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

        const string _helloWorld = " #     #                                                                                                                        \n #  #  # ###### #       ####   ####  #    # ######    #####  ####     ##### #    # ######                                       \n #  #  # #      #      #    # #    # ##  ## #           #   #    #      #   #    # #                                            \n #  #  # #####  #      #      #    # # ## # #####       #   #    #      #   ###### #####                                        \n #  #  # #      #      #      #    # #    # #           #   #    #      #   #    # #                                            \n #  #  # #      #      #    # #    # #    # #           #   #    #      #   #    # #                                            \n  ## ##  ###### ######  ####   ####  #    # ######      #    ####       #   #    # ######                                       \n                                                                                                                                \n                                                                                                                                \n   ##   #####  #    # ###### #    # ##### #    # #####  ######         ####  ##### #####    ##   #    #  ####  ###### #####     \n  #  #  #    # #    # #      ##   #   #   #    # #    # #             #        #   #    #  #  #  ##   # #    # #      #    #    \n #    # #    # #    # #####  # #  #   #   #    # #    # #####          ####    #   #    # #    # # #  # #      #####  #    #    \n ###### #    # #    # #      #  # #   #   #    # #####  #      ###         #   #   #####  ###### #  # # #  ### #      #####     \n #    # #    #  #  #  #      #   ##   #   #    # #   #  #      ###    #    #   #   #   #  #    # #   ## #    # #      #   #     \n #    # #####    ##   ###### #    #   #    ####  #    # ######  #      ####    #   #    # #    # #    #  ####  ###### #    #    \n                                                               #                                                                \n Press Enter for continue...";

        private GameController gameController;

        public NetworkStream networkStreamWithClient { get; set; }

        public CommunicationServer(NetworkStream networkStream)
        {
            gameController = new GameController();
            this.networkStreamWithClient = networkStream;
        }

        /// <summary>
        /// Ассинхронно стартуем обработку всех приходящих ответов с клиента
        /// </summary>
        public async Task Start()
        {
            Hello();
            //Этот прекрасный while true надо будет заменить на проверку работы сервера или проверку соединения
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
                catch (GameEndException e)
                {
                    await ServerSettings.ResponseServerAsync(networkStreamWithClient, e.Message);
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
            int indexCut = textCommand.IndexOf('\n');
            return textCommand.Substring(0, indexCut == -1 ? throw new IOException() : indexCut);
        }

    }
}
