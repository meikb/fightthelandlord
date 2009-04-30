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
        public UdpClient uClient;
        /// <summary>
        /// 所有用户是否已准备
        /// </summary>
        public bool everyIsOk = false;
        /// <summary>
        /// 引用服务器发送的牌组对象
        /// </summary>
        public PokerGroup Pokers;
        /// <summary>
        /// 是否有出牌权限
        /// </summary>
        public bool haveOrder;
        public bool AcceptedPokers;
        public bool AcceptedLeadPokers;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Client()
        {
            client = new TcpClient();
            uClient = new UdpClient();
        }

        /// <summary>
        /// 向服务器发送连接请求
        /// </summary>
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

        /// <summary>
        /// 循环检测服务器的Start命令
        /// </summary>
        public void AcceptMessage()  //循环检测server端是否发送过Start消息,如果发送则this.isStart = true;
        {
            NetworkStream Ns = client.GetStream();
           // Stream stream = new MemoryStream();
            string str = "";
            while (true)
            {
                byte[] bytes = new byte[108];
                Ns.Read(bytes, 0, 108);
                str = Encoding.Default.GetString(bytes);
                if (str.StartsWith("EveryOneIsOk"))
                {
                    this.everyIsOk = true;
                }
                if (str.StartsWith("lead"))
                {
                    this.haveOrder = true;
                }
                if (!str.StartsWith("EveryOneIsOk") && !str.StartsWith("lead"))
                {
                    PokerGroup pokers = new PokerGroup();
                    pokers.GetPokerGroup(bytes);
                    if (pokers.Count == 17 | pokers.Count == 20)
                    {
                        this.Pokers = pokers;
                    }
                    else
                    {
                        DConsole.leadedPokers.Add(pokers);
                        DConsole.WriteLeadedPokers();
                    }
                }
                //switch (str)
                //{
                //    case "EveryOneIsOk":
                //        this.everyIsOk = true;
                //        break;
                //    case "lead":
                //        this.haveOrder = true;
                //        break;
                //    default:
                //        memStream.Write(byteMessage, 0, byteMessage.Length);
                //        this.Pokers = (PokerGroup)(serializer.Deserialize(memStream));
                //        break;
                //}
                //if (str.StartsWith("EveryOneIsOk"))
                //{
                //    this.everyIsOk = true;
                //} 
                //if (str.StartsWith("lead"))
                //{
                //    this.haveOrder = true;
                //}
            }
        }

        /// <summary>
        /// 接收服务器发送的牌组
        /// </summary>
        //public void AcceptPokers() //接受server传送过来的已序列化的PokerGroup牌组对象并将其反序列化,然后把它的引用传给this.Pokers
        //{
        //    NetworkStream NsPokers = client.GetStream();
        //    IFormatter serializer = new BinaryFormatter();
        //    this.Pokers = (PokerGroup)(serializer.Deserialize(NsPokers));
        //    //NsPokers.Flush();
        //}

        /// <summary>
        /// 接收其他人的出牌
        /// </summary>
        //public void AcceptLeadPokers()
        //{
        //    NetworkStream NsPokers = client.GetStream();
        //    while (true)
        //    {
        //        IFormatter serializer = new BinaryFormatter();
        //        try
        //        {
        //            PokerGroup leadedPokers = (PokerGroup)(serializer.Deserialize(NsPokers));
        //            DConsole.leadedPokers.Add(leadedPokers);
        //            DConsole.WriteLeadedPokers();
        //        }
        //        catch
        //        {
        //        }
        //    }
        //}

        /// <summary>
        /// 向服务器发送准备请求
        /// </summary>
        public bool SendOk() //给服务器发送准备指令
        {
            this.SendMessageForServer("OK");
            return true;
        }

        /// <summary>
        /// 向服务器发送出牌请求
        /// </summary>
        public bool SendPokers(PokerGroup pokers)  //出牌请求
        {
            NetworkStream Ns = this.client.GetStream();
            MemoryStream memStream = new MemoryStream();
            IFormatter serializer = new BinaryFormatter();
            serializer.Serialize(memStream, pokers);
            byte[] bytePokers = memStream.GetBuffer();
            Ns.Write(bytePokers, 0, bytePokers.Length);
            return true;
        }
        public bool SendMessageForServer(string str)
        {
            NetworkStream Ns = this.client.GetStream();
            byte[] bytes = Encoding.Default.GetBytes(str);
            Ns.Write(bytes, 0, bytes.Length);  
            return true;
        }
        public bool SendMessageForServer(PokerGroup pg)
        {
            NetworkStream Ns = this.client.GetStream();
            byte[] bytes = pg.GetBuffer();
            Ns.Write(bytes, 0, bytes.Length); 
            return true;
        }

        /// <summary>
        /// 循环检测服务器是否发送允许出牌消息
        /// </summary>
        //public void AcceptOrder()
        //{
        //    NetworkStream Ns = this.client.GetStream();
        //    byte[] byteOrder = new byte["lead".Length];
        //    string strOrder = "";
        //    while (true)
        //    {
        //        Ns.Read(byteOrder, 0, "lead".Length);
        //        strOrder = Encoding.Default.GetString(byteOrder);
        //        if (strOrder.StartsWith("lead"))
        //        {
        //            this.haveOrder = true;
        //        }
        //    }
        //}
    }
}
