using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZBWZ_DDZ;

namespace ZBWZ_DDZClient
{
    public static class MessageHandler
    {
        public static int PorxyID { get; set; }

        public static object _sync_sendWhisper;

        public static object _sync_ReceiveWhisper;

        public static void 发送_请求桌子数据()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_请求桌子数据) };
            发送数据(sendData);
        }

        public static void 发送_能否进入()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_能否进入) };
            发送数据(sendData);
        }

        public static void 发送_进入()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_进入) };
            发送数据(sendData);
        }


        public static void 发送_准备()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_准备) };
            发送数据(sendData);
        }

        public static void 发送_叫地主()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_叫地主) };
            发送数据(sendData);
        }

        public static void 发送_不叫()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_不叫) };
            发送数据(sendData);
        }

        public static void 发送_出牌(PokerGroup pg)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_出牌), pg.GetBuffer() };
            发送数据(sendData);
        }

        public static void 发送_Pass()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_Pass) };
            发送数据(sendData);
        }

        public static void 发送_断开()
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes((int)DDZActions.C_断开) };
            发送数据(sendData);
        }

        public static void 发送数据(byte[][] sendData)
        {
            lock (_sync_sendWhisper)
            {
                //todo 写客户端...
            }
        }
    }
}
