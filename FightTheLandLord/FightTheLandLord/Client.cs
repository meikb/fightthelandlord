using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace FightTheLandLord
{
    public class Client
    {
        /// <summary>
        /// 客户端的名称
        /// </summary>
        public string Name;
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
                if (str.StartsWith("CName"))
                {
                    str = str.Replace("CName", "");
                    DConsole.OtherClientName = str;
                    continue;
                }
                if (str.StartsWith("SPokerCount"))
                {
                    str = str.Replace("SPokerCount","");
                    int pokerCount = Convert.ToInt32(str);
                    DConsole.PaintServer(pokerCount);
                    continue;
                }
                if (str.StartsWith("PokerCount"))
                {
                    str = str.Replace("PokerCount","");
                    int pokerCount = Convert.ToInt32(str);
                    DConsole.PaintClient(pokerCount);
                    continue;
                }
                if (str.StartsWith("EveryOneIsOk"))
                {
                    this.everyIsOk = true;
                    continue;
                }
                if (str.StartsWith("lead"))
                {
                    this.haveOrder = true;
                    continue;
                }
                if (str.StartsWith("StartPokers"))
                {
                    this.Pokers.GetPokerGroup(bytes);
                    continue;
                }
                if (str.StartsWith("server"))
                {
                    PokerGroup pokers = new PokerGroup();
                    str = str.Replace("server", "");
                    byte[] bytePg = Encoding.Default.GetBytes(str);
                    pokers.GetPokerGroup(bytePg);
                    DConsole.leadedPokers.Add(pokers);
                    DConsole.WriteLeadedPokers();
                    DConsole.PaintPlayer2LeadPoker(pokers);
                    continue;
                }
                if (str.StartsWith("client"))
                {
                    PokerGroup pokers = new PokerGroup();
                    str = str.Replace("client", "");
                    byte[] bytePg = Encoding.Default.GetBytes(str);
                    pokers.GetPokerGroup(bytePg);
                    DConsole.leadedPokers.Add(pokers);
                    DConsole.WriteLeadedPokers();
                    DConsole.PaintPlayer3LeadPoker(pokers);
                    continue;
                }
                if (str.StartsWith("Order"))
                {
                    this.haveOrder = true;
                    continue;
                }
                //接收服务器分配的牌组
                if (!str.StartsWith("EveryOneIsOk") && !str.StartsWith("lead"))
                {
                    PokerGroup pokers = new PokerGroup();
                    pokers.GetPokerGroup(bytes);
                    if (pokers.Count == 17 | pokers.Count == 20)
                    {
                        this.Pokers = pokers;
                    }
                    continue;
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
        public bool SendDataForServer(string head,PokerGroup pg)
        {
            NetworkStream Ns = client.GetStream();
            byte[] bytePg = pg.GetBuffer();  //通过2个 MemoryStream对象获取代表2组牌的 比特流对象
            string strPg = Encoding.Default.GetString(bytePg);
            string strSender = head + strPg;  //组合两个字符串
            byte[] byteSender = Encoding.Default.GetBytes(strSender);  //把要发送的数据转换为byte[]
            Ns.Write(byteSender, 0, byteSender.Length);  //把2个比特流对象写入server与client的连接管道中
            return true;
        }
    }
}
