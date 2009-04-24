using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace FightTheLandLord
{
    class Server
    {
        public static TcpListener listener = new TcpListener(IPAddress.Any ,Properties.Settings.Default.Port);
    }
}
