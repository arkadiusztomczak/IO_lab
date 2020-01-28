using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        public static void Main()
        {
            ThreadPool.QueueUserWorkItem(Server);
            ThreadPool.QueueUserWorkItem(Client, "Client1");
            ThreadPool.QueueUserWorkItem(Client, "Client2");
            Thread.Sleep(1000);
        }

        private void Server(Object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                ThreadPool.QueueUserWorkItem(Conn, client);
            }
        }

        private void Client(Object stateInfo)
        {
            var client = new TcpClient();
            var buffer = new byte[1024];
            var message = "TEST";

            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));
            client.GetStream().Write(message, 0, message.Length);
            client.GetStream().Read(buffer, 0, buffer.Length);
            Console.WriteLine($"Otrzymano[KLIENT]: {Encoding.UTF8.GetString(buffer)}");
        }

        public void Conn(Object stateInfo)
        {
            var client = stateInfo as TcpClient;
            byte[] buffer = new byte[1024];
            client.GetStream().Read(buffer, 0, 1024);      
            Console.WriteLine($"Otrzymano[SERWER]: {Encoding.UTF8.GetString(buffer)}");
            client.GetStream().Write(buffer, 0, 1024);
            client.Close();
        }
    }
}
