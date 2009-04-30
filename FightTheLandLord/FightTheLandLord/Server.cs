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
        public bool AcceptedLeadPokers;
        public bool AcceptedPokers;

        /// <summary>
        /// 寻远接收客户端的连接请求，当连接2个客户端后关闭端口监听。
        /// </summary>
        public void Connection() //循环检测是否有连接请求,接受最先请求的两个连接,得到两个TcpClient,然后拒绝其他的所有连接
        {
            //try
            //{
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
            //}
            //catch
            //{
            //   // return false;
            //}
            //return true;
        }

        /// <summary>
        /// 循环接收客户端的准备请求，一旦所有客户端准备完毕，就向客户端发送Start命令
        /// </summary>
        public void AccpetMessage()
        {
            NetworkStream Ns1 = client1.GetStream();
            NetworkStream Ns2 = client2.GetStream();
            byte[] bytes1 = new byte[108];
            byte[] bytes2 = new byte[108];
            string str1 = "";
            string str2 = "";
            while (true)
            {
                str1 = Encoding.Default.GetString(Ns1.Read
                str2 = 
                //Ns1.Read(byte1, 0, 2048);
                //Ns2.Read(byte2, 0, 2048);
                //str1 = Encoding.Default.GetString(byte1);
                //str2 = Encoding.Default.GetString(byte2);
                if (str1.StartsWith("OK") && str2.StartsWith("OK"))
                {
                    this.everyOneIsOk = true;
                    //byte[] byteStart = Encoding.Default.GetBytes("EveryOneIsOk");
                    //NsOk1.Write(byteStart, 0, byteStart.Length);
                    //NsOk2.Write(byteStart, 0, byteStart.Length);
                    this.SendMessageForClient("EveryOneIsOk", 1);
                    this.SendMessageForClient("EveryOneIsOk", 2);
                }
                if (str1.StartsWith("AcceptedPokers") && str2.StartsWith("AcceptedPokers"))
                {
                    this.AcceptedPokers = true;
                }
                if (str1.StartsWith("AcceptedLeadPokers") && str2.StartsWith("AcceptedLeadPokers"))
                {
                    this.AcceptedLeadPokers = true;
                }
            }
        }

        ///// <summary>
        ///// 把Poker的集合对象序列化后发送给2个客户端
        ///// </summary>
        //public bool SendPokerForClient(PokerGroup player2Pokers, PokerGroup player3Pokers)  
        //{
        //    try
        //    {
        //        NetworkStream Ns1 = this.client1.GetStream();
        //        NetworkStream Ns2 = this.client2.GetStream(); //得到两个客户端的网络流对象
        //        MemoryStream memStream1 = new MemoryStream();
        //        MemoryStream memStream2 = new MemoryStream();  
        //        IFormatter serializer = new BinaryFormatter();
        //        serializer.Serialize(memStream1, player2Pokers);
        //        serializer.Serialize(memStream2, player3Pokers);  //把给客户端的2组牌序列化并写入2个 MemoryStream 对象
        //        byte[] bytePlayer2Pokers = memStream1.GetBuffer();
        //        byte[] bytePlayer3Pokers = memStream2.GetBuffer();  //通过2个 MemoryStream对象获取代表2组牌的 比特流对象
        //        Ns1.Write(bytePlayer2Pokers, 0, bytePlayer2Pokers.Length);
        //        Ns2.Write(bytePlayer3Pokers, 0, bytePlayer3Pokers.Length);  //把2个比特流对象写入server与client的连接管道中.
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        public bool SendMessageForClient(PokerGroup pg, int client)
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
        public bool SendMessageForClient(string str, int client)
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
                IFormatter serializer = new BinaryFormatter();
                if (c1Poker.DataAvailable)
                {
                    this.SendMessageForClient((PokerGroup)serializer.Deserialize(c1Poker), 2);
                }
                if (c2Poker.DataAvailable)
                {
                    this.SendMessageForClient((PokerGroup)serializer.Deserialize(c2Poker), 1);
                }
            }
        }

        public void SendOrder(int Num)
        {
            //NetworkStream Ns1 = client1.GetStream();
            //NetworkStream Ns2 = client2.GetStream();
            //IFormatter serializer = new BinaryFormatter();
            //MemoryStream memStram = new MemoryStream();
            //serializer.Serialize(memStram, "lead");
            //byte[] byteOrder = memStram.GetBuffer();
            switch (Num)
            {
                case 1:
                    this.haveOrder = true;
                    break;
                case 2:
                    this.SendMessageForClient("lead", 1);
                    break;
                case 3:
                    this.SendMessageForClient("lead", 2);
                    break;
            }
        }
    }
}
