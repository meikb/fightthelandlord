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
        public bool isStart = false;
        public List<Poker> Pokers;

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

        public void AcceptStart()  //循环检测server端是否发送过Start消息,如果发送则this.isStart = true;
        {
            NetworkStream NsStart = client.GetStream();
            byte[] byteStart = new byte["Start".Length];
            string strStart = "";
            while (true)
            {
                NsStart.Read(byteStart, 0, "Start".Length);
                strStart = Encoding.Default.GetString(byteStart);
                if (strStart.StartsWith("St"))
                {
                    this.isStart = true;
                    break;
                }
            }
        }

        public List<Poker> AcceptPokers() //接受server传送过来的已序列化的List<Poker>牌组对象并反序列化,然后把引用传给this.Pokers
        {
            try
            {
                NetworkStream NsPokers = client.GetStream();
                IFormatter serializer = new BinaryFormatter();
                this.Pokers = (List<Poker>)(serializer.Deserialize(NsPokers));
                return this.Pokers;
            }
            catch
            {
                return null;
            }
        }

        public bool SendOk() //给服务器发送准备指令
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

        public bool SendPokers(List<Poker> pokers)  //出牌请求,暂未完成.
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
