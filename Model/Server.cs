using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CTF_GAME
{
    class Server
    {
        const int _lenghtBuffer = 4096;
        private int _port = 9090;
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
            StartServer(new TcpListener(IpAddr,Port));
        }

        private void StartServer(TcpListener tcpServer)
        {
            tcpServer.Start();
            while(true)
            {
                TcpClient tcpClient = tcpServer.AcceptTcpClient();
                Console.WriteLine(ResponseServer(tcpClient.GetStream()));
                Console.WriteLine(ReadServer(tcpClient.GetStream()));
            }
        }

        //String надо будет заменить на класс, структуру которая будет приходить(структуру/класс надо ещё сделать)
        private string ReadServer(NetworkStream networkStream)
        {
            List<byte> resultText =  new List<byte>();
            byte[] textBuffer = new byte [_lenghtBuffer];
            int offset = 0;
            while(networkStream.CanRead)
            {
                textBuffer = new byte[_lenghtBuffer];
                networkStream.Read(textBuffer, offset, (int)networkStream.Length);
                offset += _lenghtBuffer;
                resultText.AddRange(textBuffer.Select(element => element));
            }
            return Encoding.ASCII.GetString(textBuffer);
        }

        private bool ResponseServer(NetworkStream networkStream)
        {
            networkStream.Write(Encoding.ASCII.GetBytes("HI"));
            return true;
        }
    }
}