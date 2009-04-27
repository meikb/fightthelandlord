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
        public TcpClient client1;
        public TcpClient client2;
        public bool everyOneIsOk = false;

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
                    NsOk1.Write(byteStart, 0, 4);
                    NsOk2.Write(byteStart, 0, 4);
                    break;
                }
            }
        }

        public bool SendPokerForClient(List<Poker> player2Pokers, List<Poker> player3Pokers)  //未完成
        {
            try
            {
                NetworkStream Ns1 = this.client1.GetStream();
                NetworkStream Ns2 = this.client2.GetStream();
                MemoryStream memStream1 = new MemoryStream();
                MemoryStream memStream2 = new MemoryStream();
                IFormatter serializer = new BinaryFormatter();
                serializer.Serialize(memStream1, player2Pokers);
                serializer.Serialize(memStream2, player3Pokers);
                byte[] bytePlayer2Pokers = memStream1.GetBuffer();
                byte[] bytePlayer3Pokers = memStream1.GetBuffer();
                Ns1.Write(bytePlayer2Pokers, 0, bytePlayer2Pokers.Length);
                Ns2.Write(bytePlayer3Pokers, 0, bytePlayer3Pokers.Length);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool AcceptPokers()
        {
            try
            {
                const int bufferSize = 4096;
                NetworkStream Ns = client1.GetStream();
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
