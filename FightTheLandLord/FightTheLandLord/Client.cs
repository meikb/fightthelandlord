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
        /// 接收服务器发送的数据
        /// </summary>
        public void AcceptServerData() 
        {
            NetworkStream Ns = client.GetStream();
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
            }
        }

        /// <summary>
        /// 向服务器发送准备请求
        /// </summary>
        public bool SendOk() //给服务器发送准备指令
        {
            this.SendDataForServer("OK");
            return true;
        }

        /// <summary>
        /// 向服务器发送出牌请求
        /// </summary>
        public bool SendDataForServer(string str)
        {
            NetworkStream Ns = this.client.GetStream();
            byte[] bytes = Encoding.Default.GetBytes(str);
            Ns.Write(bytes, 0, bytes.Length);  
            return true;
        }
        public bool SendDataForServer(PokerGroup pg)
        {
            NetworkStream Ns = this.client.GetStream();
            byte[] bytes = pg.GetBuffer();
            Ns.Write(bytes, 0, bytes.Length); 
            return true;
        }
    }
}
