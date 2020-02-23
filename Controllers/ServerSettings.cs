using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CTF_GAME;

namespace CTF_GAME.Controllers
{
    /// <summary>
    /// Отвечает за начальную настройку tcp-сервера и его работу(чтение и ответ клиенту)
    /// </summary>
    class ServerSettings
    {
        const int _timeOutGetData = 5000;
        const int _lenghtBuffer = 1024;
        private int _port = 9090;
        private IPAddress _ipAddress = IPAddress.Parse("127.0.0.1");
        List<CommunicationServer> tcpClients = new List<CommunicationServer>();

        public int Port
        {
            get => _port;
            set => _port = value;
        }

        public IPAddress IpAddr
        {
            get => _ipAddress;
            set => _ipAddress = value;
        }

        public ServerSettings()
        {
            StartServer(new TcpListener(IpAddr, Port));
        }
        /// <summary>
        /// Стартуем + бесконечно читаем порт и работаем с клиентами
        /// </summary>
        /// <param name="tcpServer">Настроенный tcp-сервер</param>
        private void StartServer(TcpListener tcpServer)
        {
            tcpServer.Start();
            while (true)
            {
                tcpClients.Add(new CommunicationServer(tcpServer.AcceptTcpClient().GetStream()));
            }
        }
        /// <summary>
        /// Ассинхронно читаем, что прислал клиент
        /// </summary>
        /// <param name="networkStream">Рабочий поток для работы с клиентом</param>
        /// <returns>Ответ от клииента</returns>
        //String надо будет заменить на класс, структуру которая будет приходить(структуру/класс надо ещё сделать)
        static public async Task<string> ReadServerAsync(NetworkStream networkStream)
        {
            List<byte> resultText = new List<byte>();
            byte[] textBuffer = new byte[_lenghtBuffer];
            int offset = 0;
            await networkStream.ReadAsync(textBuffer, offset, _lenghtBuffer);
            offset += _lenghtBuffer;
            resultText.AddRange(textBuffer.Select(element => element));
            return Encoding.ASCII.GetString(textBuffer);
        }

        /// <summary>
        /// Отправляем ответ клиенту
        /// </summary>
        /// <param name="networkStream">рабочий поток для работы с клиентом</param>
        /// <param name="message">то что отправляем кленту</param>
        /// <returns></returns>
        static async public Task ResponseServerAsync(NetworkStream networkStream, string message)
        {
            await networkStream.WriteAsync(Encoding.ASCII.GetBytes(message));
        }
    }
}