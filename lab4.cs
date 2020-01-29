using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using System.IO;

namespace Lab4
{
    class Program
    {
        static void callback(IAsyncResult state)
        {
            object[] args = (object[])state.AsyncState;
            FileStream fs = args[0] as FileStream;
            byte[] data = (byte[])args[1];
            Console.WriteLine(Encoding.UTF8.GetString(data));
            fs.Close();
        }

        static void Main(string[] args)
        {
            byte[] buf = new byte[255];

            FileStream fs = new FileStream("C:\\Users\\Arek\\Documents\\IO\\file.txt", FileMode.Open);
            fs.BeginRead(buffer, 0, buffer.Length, callback, new object[] { fs, buffer });

            Thread.Sleep(1000);
        }
    }
    
    
    class Client
    {
        private TcpClient client;
        private byte[] buf;

        public Client(TcpClient client, int size)
        {
            this.client = client;
            this.buffer = new byte[size];
        }

        static void writeMessage(string n)
        {
            Console.WriteLine(message);
        }

        public void Read()
        {
            var stream = client.GetStream();
            while (1)
            {
                int l = buf.Length;
                var r = stream.Read(buf, 0, l);
                byte[] send = new byte[r];
                if (r != 0)
                {
                    Array.Copy(buf, send, r);
                    Write(send);
                    Console.Write("Otrzymano: " + Encoding.UTF8.GetString(buf, 0, r));
                }
            }
        }

        public void Write(byte[] sendBuffer)
        {
            tcpClient.GetStream().Write(sendBuffer, 0, sendBuffer.Length);
        }

        public void Write() {
            tcpClient.GetStream().Write(buffer, 0, buffer.Length);
        }
    }


    class Program
    {
        delegate int dellegate(object args);        
        static void Main(string[] args)
        {

            FileStream fs = File.Open("C:\\Users\\Arek\\Documents\\IO\\file.txt", FileMode.Open);
            byte[] buf  = new byte[1024];

            dellegate Del;
            Del = new dellegate(ReadFile);
            
            var rs = Del.BeginInvoke(new object[] { fs, buffer });   
        }
    }
}
