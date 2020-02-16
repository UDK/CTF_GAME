using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CTF_GAME
{
    class Server
    {
        private int _port = 5666;
        private IPAddress _ipAddress = IPAddress.Parse("127.0.0.1");

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

        public Server()
        {

        }

        private async void StartServerAsync(TcpListener tcpServer, int port)
        {
            tcpServer.Start();
            TcpClient tcpClient = await tcpServer.AcceptTcpClientAsync();
            Console.WriteLine(await ResponseServerAsync(tcpClient.GetStream()));
            Console.WriteLine(await ReadServerAsync(tcpClient.GetStream()));
        }

        //String надо будет заменить на класс, структуру которая будет приходить(структуру/класс надо ещё сделать)
        private async Task<string> ReadServerAsync(NetworkStream networkStream)
        {
            while(networkStream.CanRead)
            {
                await networkStream.ReadAsync();
            }
        }

        private async Task<bool> ResponseServerAsync(NetworkStream networkStream)
        {
            await networkStream.WriteAsync(Encoding.ASCII.GetBytes("HI"));
            return true;
        }
    }
}