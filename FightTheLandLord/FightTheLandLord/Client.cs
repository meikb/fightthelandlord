using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FightTheLandLord
{
    public class Client
    {
        public TcpClient client;

        public Client()
        {
            client = new TcpClient();
        }

        public bool Connection()
        {
            try
            {
                client.Connect(IPAddress.Parse(Properties.Settings.Default.Host), Properties.Settings.Default.Port);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SendOk()
        {
            try
            {
                NetworkStream NsOk = this.client.GetStream();
                byte[] byteOk = Encoding.Default.GetBytes("OK");
                NsOk.Write(byteOk, 0, byteOk.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool SendPokers(List<Poker> pokers)
        {
            try
            {
                NetworkStream Ns = this.client.GetStream();
                MemoryStream memStream = new MemoryStream();
                IFormatter serializer = new BinaryFormatter();
                serializer.Serialize(memStream, pokers);
                byte[] bytePokers = memStream.GetBuffer();
                Ns.Write(bytePokers, 0, bytePokers.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
