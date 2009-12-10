using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using JavaSharp;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace SLFightTheLandLord
{
    public static class Network
    {
        private static Socket _socket;

        public static Socket Socket
        {
            get { return _socket; }
            set { _socket = value; }
        }

        private static SocketAsyncEventArgs _sendEventArgs;

        private static SynchronizationContext syn;

        public static SynchronizationContext Syn
        {
            get { return syn; }
            set { syn = value; }
        }

        private static string _serverIPAddress = "192.168.1.5";

        public static string ServerIpAddress
        {
            get
            {
                return _serverIPAddress;
            }
            set
            {
                _serverIPAddress = value;
            }
        }

        public static void Connect()
        {
            syn = SynchronizationContext.Current;

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs args = new SocketAsyncEventArgs();
            args.RemoteEndPoint = new DnsEndPoint(ServerIpAddress, 4503);
            args.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketConnectComplete);

            _socket.ConnectAsync(args);
        }

        public static void SendStart()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            Converter.WriteShort(writer, (ushort)5000);
            byte[] bytes = ms.ToArray();
            SendData(bytes);
        }

        public static void SendLeadedPokers(PokerGroup pg)
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            Converter.WriteShort(writer, (ushort)5010);
            writer.Write(pg.GetBuffer());
            byte[] bytes = ms.ToArray();
            SendData(bytes);
        }

        static void OnSocketConnectComplete(object sender, SocketAsyncEventArgs e)
        {
            string data = "";
            if (!_socket.Connected)
                data = "无法连接服务器，请稍后再试";
            else
                data = "成功地连接上了服务器";

            StaticVar.ShowMessage(data);

            _sendEventArgs = new SocketAsyncEventArgs();
            _sendEventArgs.RemoteEndPoint = e.RemoteEndPoint; 


            byte[] response = new byte[1024];
            e.SetBuffer(response, 0, response.Length);

            e.Completed -= new EventHandler<SocketAsyncEventArgs>(OnSocketConnectComplete);
            e.Completed += new EventHandler<SocketAsyncEventArgs>(OnSocketReceiveComplete);

            
            _socket.ReceiveAsync(e);

        }

        static void OnSocketReceiveComplete(object sender, SocketAsyncEventArgs e)
        {
            //todo 网络部分，接收到数据以后的数据处理操作
            byte[] received = e.Buffer;
            MemoryStream ms = new MemoryStream(received);
            BinaryReader reader = new BinaryReader(ms);

            ushort MsgNum = Converter.ReadShort(reader);
            switch (MsgNum)
            {

                case 5001:     //准备好
                    int readyPlayerID = Converter.ReadInt(reader);
                    StaticVar.PlayReadyAnimation(readyPlayerID);
                    /**
                    if (readyPlayerID == StaticVar.LeftPlayerID)
                    {
                    }
                    else if (readyPlayerID == StaticVar.RightPlayerID)
                    {
                    }
                    else if (readyPlayerID == StaticVar.MyID)
                    {
                    }**/
                    break;   
                case 5011:     //发牌
                    byte[] bytePokers = reader.ReadBytes(34);
                    StaticVar.MyPoker = new PokerGroup(bytePokers);
                    StaticVar.Sort(StaticVar.MyPoker);
                    StaticVar.PlayDealAnimation();
                    break;
                case 5021:     //三张地主牌广播
                    byte[] byteLLPokers = reader.ReadBytes(6);
                    StaticVar.TheLandLordPokers = new PokerGroup(byteLLPokers);
                    //todo 在界面上表现出地主牌
                    break;
                case 5031:     //可以出牌广播
                    int LeadablePlayerID = Converter.ReadInt(reader);
                    if (LeadablePlayerID == StaticVar.LeftPlayerID)
                    {
                    }
                    else if (LeadablePlayerID == StaticVar.RightPlayerID)
                    {
                    }
                    else if (LeadablePlayerID == StaticVar.MyID)
                    {
                    }
                    break;
                case 5041:     //出牌确认
                    break;
                case 5051:     //出牌错误
                    break;
                case 5061:     //出牌超时
                    break;
                case 5071:     //开始游戏
                    break;
                case 5081:
                    int PlayerID = Converter.ReadInt(reader);
                    if (StaticVar.LeftPlayerID == 0)
                        StaticVar.LeftPlayerID = PlayerID;
                    else if (StaticVar.RightPlayerID == 0)
                        StaticVar.RightPlayerID = PlayerID;
                    break;
                case 5091: //谁是地主
                    int LandLordPlayerID = Converter.ReadInt(reader);
                    if (LandLordPlayerID == StaticVar.LeftPlayerID)
                    {
                    }
                    else if (LandLordPlayerID == StaticVar.RightPlayerID)
                    {
                    }
                    else if (LandLordPlayerID == StaticVar.MyID)
                    {
                    }
                    break;
                case 5101: //谁有权选择地主
                    int MaybeLandLordPlayerID = Converter.ReadInt(reader);
                    if (MaybeLandLordPlayerID == StaticVar.LeftPlayerID)
                    {
                    }
                    else if (MaybeLandLordPlayerID == StaticVar.RightPlayerID)
                    {
                    }
                    else if (MaybeLandLordPlayerID == StaticVar.MyID)
                    {
                    }
                    break;
                default:
                    break;
            }

            _socket.ReceiveAsync(e);
        }

        private static void SendData(byte[] bytes)
        {
            if (_socket.Connected)
            {
                _sendEventArgs.UserToken = bytes;
                _sendEventArgs.SetBuffer(bytes, 0, bytes.Length);
                //_sendEventArgs.BufferList =
                //    new List<ArraySegment<byte>>()
                //    {
                //        new ArraySegment<byte>(bbb)
                //    };

                _socket.SendAsync(_sendEventArgs);
            }
            else
            {
                StaticVar.ShowMessage("无法连接服务器。。。请稍后再试");
                _socket.Close();
            }
        }
    }
}
