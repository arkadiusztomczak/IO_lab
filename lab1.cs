using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 8080);
            server.Start();

            TcpClient client = server.AcceptTcpClient();

            Byte[] tab = new Byte[100];
            NetworkStream stream = client.GetStream();

            while (true)
            {
                int readBytes = stream.Read(tab,0,100);
                if (readBytes != 0)
                {
                    stream.Write(tab, 0, readBytes);
                }
            }
        }
    }
}
