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
        /// <summary>
        /// 监听对象
        /// </summary>
        public TcpListener listener = new TcpListener(IPAddress.Any ,Properties.Settings.Default.Port);
        /// <summary>
        /// 客户端1
        /// </summary>
        public TcpClient client1;
        /// <summary>
        /// 客户端2
        /// </summary>
        public TcpClient client2;
        /// <summary>
        /// 所有用户是否已准备
        /// </summary>
        public bool everyOneIsOk = false;
        public bool haveOrder = false;
        public bool client1IsOk = false;
        public bool client2IsOk = false;

        /// <summary>
        /// 寻远接收客户端的连接请求，当连接2个客户端后关闭端口监听。
        /// </summary>
        public void Connection() //循环检测是否有连接请求,接受最先请求的两个连接,得到两个TcpClient,然后拒绝其他的所有连接
        {
            while (true)
            {
                if (client1 == null)
                {
                    client1 = listener.AcceptTcpClient();   //得到一个客户端
                }
                if (client2 == null)
                {
                    client2 = listener.AcceptTcpClient();  //得到另一个客户端
                }
                if (client1 != null && client2 != null)   //如果已有两个客户端,关闭监听,终端循环.
                {
                    listener.Stop();
                    break;
                }
            }
        }

        /// <summary>
        /// 循环接收客户端的准备请求，一旦所有客户端准备完毕，就向客户端发送Start命令
        /// </summary>
        public void AccpetClient1Data()
        {
            NetworkStream Ns1 = client1.GetStream();
            string str1 = "";
            while (true)
            {
                PokerGroup pg = new PokerGroup();
                byte[] bytes1 = new byte[108];
                Ns1.Read(bytes1, 0, 108);
                str1 = Encoding.Default.GetString(bytes1);
                if (str1.StartsWith("OK"))
                {
                    this.client1IsOk = true;
                }
                if (!str1.StartsWith("OK"))
                {
                    pg.GetPokerGroup(bytes1);
                    DConsole.leadedPokers.Add(pg);
                    DConsole.WriteLeadedPokers();
                }
                //if (str1.StartsWith("AcceptedPokers") && str2.StartsWith("AcceptedPokers"))
                //{
                //    this.AcceptedPokers = true;
                //}
                //if (str1.StartsWith("AcceptedLeadPokers") && str2.StartsWith("AcceptedLeadPokers"))
                //{
                //    this.AcceptedLeadPokers = true;
                //}
            }
        }
        public void AccpetClient2Data()
        {
            NetworkStream Ns2 = client2.GetStream();
            string str2 = "";
            while (true)
            {
                PokerGroup pg = new PokerGroup();
                byte[] bytes2 = new byte[108];
                Ns2.Read(bytes2, 0, 108);
                str2 = Encoding.Default.GetString(bytes2);
                if (str2.StartsWith("OK"))
                {
                    this.client2IsOk = true;
                }
                if (!str2.StartsWith("OK"))
                {
                    pg.GetPokerGroup(bytes2);
                    DConsole.leadedPokers.Add(pg);
                    DConsole.WriteLeadedPokers();
                }
                //if (str1.StartsWith("AcceptedPokers") && str2.StartsWith("AcceptedPokers"))
                //{
                //    this.AcceptedPokers = true;
                //}
                //if (str1.StartsWith("AcceptedLeadPokers") && str2.StartsWith("AcceptedLeadPokers"))
                //{
                //    this.AcceptedLeadPokers = true;
                //}
            }
        }

        public bool SendDataForClient(PokerGroup pg, int client)
        {

            NetworkStream Ns = null;
            if (client == 1)
            {
                Ns = this.client1.GetStream();
            }
            if (client == 2)
            {
                Ns = this.client2.GetStream();//得到客户端的网络流对象
            }
            if (client != 1 && client != 2)
            {
                return false;
            }
            byte[] bytePg = pg.GetBuffer();  //通过2个 MemoryStream对象获取代表2组牌的 比特流对象
            Ns.Write(bytePg, 0, bytePg.Length);  //把2个比特流对象写入server与client的连接管道中
            return true;
        }
        public bool SendDataForClient(string str, int client)
        {

            NetworkStream Ns = null;
            if (client == 1)
            {
                Ns = this.client1.GetStream();
            }
            if (client == 2)
            {
                Ns = this.client2.GetStream();//得到客户端的网络流对象
            }
            if (client != 1 && client != 2)
            {
                return false;
            }
            byte[] byteStr = Encoding.Default.GetBytes(str); 
            Ns.Write(byteStr, 0, byteStr.Length);  //把2个比特流对象写入server与client的连接管道中

            return true;
        }

        /// <summary>
        /// 循环接收客户端出牌
        /// </summary>
        public void AcceptPokers()
        {
            while (true)
            {
                NetworkStream c1Poker = client1.GetStream();
                NetworkStream c2Poker = client2.GetStream();
            }
        }

        public void SendOrder(int Num)
        {
            switch (Num)
            {
                case 1:
                    this.haveOrder = true;
                    break;
                case 2:
                    this.SendDataForClient("lead", 1);
                    break;
                case 3:
                    this.SendDataForClient("lead", 2);
                    break;
            }
        }
    }
}
