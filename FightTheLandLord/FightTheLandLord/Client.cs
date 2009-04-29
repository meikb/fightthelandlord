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
        /// <summary>
        /// 所有用户是否已准备
        /// </summary>
        public bool isStart = false;
        /// <summary>
        /// 引用服务器发送的牌组对象
        /// </summary>
        public List<Poker> Pokers;
        /// <summary>
        /// 是否有出牌权限
        /// </summary>
        public bool haveOrder;

        /// <summary>
        /// 构造函数
        /// </summary>
        public Client()
        {
            client = new TcpClient();
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
        public void AcceptStart()  //循环检测server端是否发送过Start消息,如果发送则this.isStart = true;
        {
            NetworkStream NsStart = client.GetStream();
            byte[] byteStart = new byte["Start".Length];
            string strStart = "";
            while (true)
            {
                NsStart.Read(byteStart, 0, "Start".Length);
                strStart = Encoding.Default.GetString(byteStart);
                if (strStart.StartsWith("Start"))
                {
                    this.isStart = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 接收服务器发送的牌组
        /// </summary>
        public void AcceptPokers() //接受server传送过来的已序列化的List<Poker>牌组对象并将其反序列化,然后把它的引用传给this.Pokers
        {
                NetworkStream NsPokers = client.GetStream();
                IFormatter serializer = new BinaryFormatter();
                this.Pokers = (List<Poker>)(serializer.Deserialize(NsPokers));
        }

        /// <summary>
        /// 接收其他人的出牌
        /// </summary>
        public void AcceptLeadPokers()
        {
            NetworkStream NsPokers = client.GetStream();
            while (true)
            {
                IFormatter serializer = new BinaryFormatter();
                List<Poker> leadedPokers = (List<Poker>)(serializer.Deserialize(NsPokers));
                DConsole.leadedPokers.Add(leadedPokers);
            }
        }

        /// <summary>
        /// 向服务器发送准备请求
        /// </summary>
        public bool SendOk() //给服务器发送准备指令
        {
            //try
            //{
                NetworkStream NsOk = this.client.GetStream();
                byte[] byteOk = Encoding.Default.GetBytes("OK");
                NsOk.Write(byteOk, 0, byteOk.Length);
            //}
            //catch
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 向服务器发送出牌请求
        /// </summary>
        public bool SendPokers(List<Poker> pokers)  //出牌请求
        {
            //try
            //{
                NetworkStream Ns = this.client.GetStream();
                MemoryStream memStream = new MemoryStream();
                IFormatter serializer = new BinaryFormatter();
                serializer.Serialize(memStream, pokers);
                byte[] bytePokers = memStream.GetBuffer();
                Ns.Write(bytePokers, 0, bytePokers.Length);
            //}
            //catch
            //{
            //    return false;
            //}
            return true;
        }

        /// <summary>
        /// 循环检测服务器是否发送允许出牌消息
        /// </summary>
        public void AcceptOrder()
        {
            NetworkStream Ns = this.client.GetStream();
            byte[] byteOrder = new byte["lead".Length];
            string strOrder = "";
            while (true)
            {
                Ns.Read(byteOrder, 0, "lead".Length);
                strOrder = Encoding.Default.GetString(byteOrder);
                if (strOrder.StartsWith("lead"))
                {
                    this.haveOrder = true;
                }
            }
        }
    }
}
