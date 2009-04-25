using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;

namespace FightTheLandLord
{
    class Server
    {
        public TcpListener listener = new TcpListener(IPAddress.Any ,Properties.Settings.Default.Port);
        public TcpClient client;

        public void Connection()
        {
            try
            {
                client = listener.AcceptTcpClient();
            }
            catch
            {
               // return false;
            }
            //return true;
        }

        public bool AcceptPokers()
        {
            try
            {
                const int bufferSize = 4096;
                NetworkStream Ns = client.GetStream();
                MemoryStream memStream = new MemoryStream();
                byte[] bytePokers = new byte[bufferSize];
                int bytesRead = 0;
                do
                {
                    bytesRead = Ns.Read(bytePokers, 0, bufferSize);
                } while (bytesRead > 0);
                IFormatter serializer = new BinaryFormatter();
                List<Poker> acceptPoker = (List<Poker>)serializer.Deserialize(memStream);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
