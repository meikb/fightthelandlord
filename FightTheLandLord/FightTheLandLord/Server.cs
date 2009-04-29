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

        /// <summary>
        /// 寻远接收客户端的连接请求，当连接2个客户端后关闭端口监听。
        /// </summary>
        public void Connection() //循环检测是否有连接请求,接受最先请求的两个连接,得到两个TcpClient,然后拒绝其他的所有连接
        {
            try
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
            catch
            {
               // return false;
            }
            //return true;
        }

        /// <summary>
        /// 循环接收客户端的准备请求，一旦所有客户端准备完毕，就向客户端发送Start命令
        /// </summary>
        public void AccpetOk()
        {
            NetworkStream NsOk1 = client1.GetStream();
            NetworkStream NsOk2 = client2.GetStream();
            byte[] byteOk1 = new byte[4];
            string strOk1 = "";
            byte[] byteOk2 = new byte[4];
            string strOk2 = "";
            while (true)
            {
                NsOk1.Read(byteOk1, 0, 3);
                NsOk2.Read(byteOk2, 0, 3);
                strOk1 = Encoding.Default.GetString(byteOk1);
                strOk2 = Encoding.Default.GetString(byteOk2);
                if (strOk1.StartsWith("OK") && strOk2.StartsWith("OK"))
                {
                    this.everyOneIsOk = true;
                    byte[] byteStart = Encoding.Default.GetBytes("Start");
                    NsOk1.Write(byteStart, 0, byteStart.Length);
                    NsOk2.Write(byteStart, 0, byteStart.Length);
                    break;
                }
            }
        }

        /// <summary>
        /// 把Poker的集合对象序列化后发送给2个客户端
        /// </summary>
        public bool SendPokerForClient(List<Poker> player2Pokers, List<Poker> player3Pokers)  
        {
            try
            {
                NetworkStream Ns1 = this.client1.GetStream();
                NetworkStream Ns2 = this.client2.GetStream(); //得到两个客户端的网络流对象
                MemoryStream memStream1 = new MemoryStream();
                MemoryStream memStream2 = new MemoryStream();  
                IFormatter serializer = new BinaryFormatter();
                serializer.Serialize(memStream1, player2Pokers);
                serializer.Serialize(memStream2, player3Pokers);  //把给客户端的2组牌序列化并写入2个 MemoryStream 对象
                byte[] bytePlayer2Pokers = memStream1.GetBuffer();
                byte[] bytePlayer3Pokers = memStream2.GetBuffer();  //通过2个 MemoryStream对象获取代表2组牌的 比特流对象
                Ns1.Write(bytePlayer2Pokers, 0, bytePlayer2Pokers.Length);
                Ns2.Write(bytePlayer3Pokers, 0, bytePlayer3Pokers.Length);  //把2个比特流对象写入server与client的连接管道中.
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 循环接收客户端出牌
        /// </summary>
        public void AcceptPokers()
        {
            while (true)
            {
                NetworkStream NsPokers = client.GetStream();
                IFormatter serializer = new BinaryFormatter();
                List<Poker> leadedPokers = (List<Poker>)(serializer.Deserialize(NsPokers));
                Rules.leadedPokers.Add(leadedPokers);
            }
        }

        public void SendOrder(int Num)
        {
            NetworkStream Ns1 = client1.GetStream();
            NetworkStream Ns2 = client2.GetStream();
            byte[] byteOrder = Encoding.Default.GetBytes("lead");
            switch (Num)
            {
                case 1:
                    this.haveOrder = true;
                    break;
                case 2:
                    Ns1.Write(byteOrder, 0, byteOrder.Length);
                    break;
                case 3:
                    Ns2.Write(byteOrder, 0, byteOrder.Length);
                    break;
            }
        }
    }
}
