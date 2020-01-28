using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace lab2
{
    public class Program
    {
        public main()
        {
            ThreadPool.QueueUserWorkItem(Server);
            ThreadPool.QueueUserWorkItem(Client);
            Thread.Sleep(5000);
        }

        void Server(object stateInfo)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 2048);
            server.Start();
            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                byte[] buffer = new byte[1024];
                client.GetStream().Read(buffer, 0, 1024);
                client.GetStream().Write(buffer, 0, buffer.Length);
                client.Close();
            }
        }

        void Client(object stateInfo)
        {
            TcpClient client = new TcpClient();

            var stream = new NetworkStream(client.Client, false);
            var buffer = new byte[1024];
            var message = "QWERTYUIOPASDFGHJKLZXCVBNM";
            client.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 2048));

            stream.Write(Encoding.ASCII.GetBytes(message), 0, message.Length);
            Console.WriteLine("Wysłano: " + message);

            stream.Read(buffer, 0, buffer.Length);
            Console.WriteLine("Otrzymano:" + System.Text.Encoding.ASCII.GetString(buffer));
        }
    }
}
