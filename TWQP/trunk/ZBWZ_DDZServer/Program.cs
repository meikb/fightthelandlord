﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using System.Threading;
using System.ComponentModel;
using ConsoleHelper;
using ZBWZ_DDZ;
using DAL;

namespace ZBWZ_DDZServer
{
    class Program
    {
        public static Writer w = Writer.Instance;
        static void Main(string[] args)
        {
            var id = int.Parse(w.RL("请输入大于 100 的 Service ID"));
            var h = new Handler(id);
            Console.CursorVisible = false;
            new ContactCenterCallback(h);  // 连接至 ContactCenter 并准备好回调实例
            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(h.SendMessage);
            bw.RunWorkerAsync();
            var gameLooper = new GameLooper(h);   // 创建游戏循环并运行
            gameLooper.IsSpeedLimitMode = true; //限速循环
            gameLooper.LoopDurationLimit = 1000; //每次循环耗时1秒
            gameLooper.Loop();
        }
    }

    public class Handler : IContactCenterCallbackHandler, IGameLoopHandler
    {
        private Writer w = Writer.Instance;
        /// <summary>
        /// 状态处理程序
        /// </summary>
        StateHandler _currentStateHander = new StateHandler();
        #region Constructor
        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }
        #endregion

        #region IContactCenterCallbackHandler Members
        /// <summary>
        /// 自己的ID
        /// </summary>
        public int ServiceID { get; set; }
        /// <summary>
        /// 占用服务的大厅ID
        /// </summary>
        public int GameMainID { get; set; }
        public ContactCenterProxy ContactCenterProxy { get; set; }
        /// <summary>
        /// 玩家列表锁
        /// </summary>
        private static object _sync_players = new object();
        /// <summary>
        /// 收到消息列队锁
        /// </summary>
        private static object _sync_whispers = new object();
        /// <summary>
        /// 发送消息列队锁
        /// </summary>
        private static object _sync_sendWhispers = new object();
        /// <summary>
        /// 玩家列表
        /// </summary>
        private static PlayerCollection _players = new PlayerCollection();
        /// <summary>
        /// 收到消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _receivedWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 发送消息列队
        /// </summary>
        private static Queue<KeyValuePair<int, byte[][]>> _sendWhispers = new Queue<KeyValuePair<int, byte[][]>>();
        /// <summary>
        /// 服务流程状态
        /// </summary>
        private static ServiceStates serviceState = ServiceStates.等待客户端进入;
        /// <summary>
        /// 54张牌
        /// </summary>
        private PokerGroup AllPoker;
        /// <summary>
        /// 地主牌
        /// </summary>
        private PokerGroup LandLordPoker = new PokerGroup();

        public void Receive(int id, byte[][] data)
        {
            w.WL(id + ": " + data + Environment.NewLine);
        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            lock (_sync_whispers)
            {
                _receivedWhispers.Enqueue(new KeyValuePair<int, byte[][]>(id, data));
            }
        }

        public void ServiceEnter(int id)
        {
            w.WL("Service " + id + " enter at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void ServiceLeave(int id)
        {
            w.WL("Service " + id + " leave at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            w.WL("Connected at " + DateTime.Now.ToString() + " with service id " + this.ServiceID + Environment.NewLine);
            Console.Write("Current Service ID List = {");
            foreach (var serviceID in serviceIdList) Console.Write(serviceID + ",");
            Console.Write("}" + Environment.NewLine);
        }

        public void JoinFailed()
        {
            w.WL("Error: service id " + this.ServiceID + " already exist!");
        }

        public void ConnectField(Exception ex)
        {
            w.WL("Error: Cannot connect to service!");
            w.WL(ex.Message);
        }

        public bool Ping(byte[][] data)
        {
            //w.WL("Got ping at " + DateTime.Now.ToString());

            //var dt = data[0].ToObject<DataTable>();
            //w.W(dt);

            return true;
        }

        #endregion

        #region IGameLoopHandler Members

        public GameLooper GameLooper { get; set; }

        public void Init()
        {
            w.WL(@"
服务开始运行.
类型：FightTheLandLordGame Server
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
            _currentStateHander.AmountPlayer = 3;
            AllPoker = new PokerGroup(true); //初始化牌组
        }

        public void Process()
        {
            KeyValuePair<int, byte[][]>[] whispers = new KeyValuePair<int, byte[][]>[_receivedWhispers.Count];
            lock (_sync_whispers)
            {
                _sendWhispers.CopyTo(whispers, 0);
                _sendWhispers.Clear();
            }
            foreach (var whisper in whispers)
            {
                var playerid = BitConverter.ToInt32(whisper.Value[0],0);
                switch ((DDZActions)BitConverter.ToInt32(whisper.Value[1],0))
                {
                    case DDZActions.C_能否进入:
                        处理_能否进入(playerid);
                        break;
                    case DDZActions.C_进入:
                        处理_进入(playerid);
                        break;
                    case DDZActions.C_准备:
                        处理_准备(playerid);
                        break;
                    case DDZActions.C_叫地主:
                        处理_叫地主(playerid);
                        break;
                    case DDZActions.C_不叫:
                        处理_不叫(playerid);
                        break;
                    case DDZActions.C_出牌:
                        处理_出牌(playerid, whisper.Value);
                        break;
                    case DDZActions.C_Pass:
                        处理_Pass(playerid);
                        break;
                    case DDZActions.GM_请求服务数据:
                        处理_GM_请求服务数据();
                        break;
                }
            }
            #region 游戏状态管理
            if (serviceState == ServiceStates.等待客户端进入)
            {
                var h = _currentStateHander as IWatingJoin;
                if (h.JoinSuccess(_players))
                {
                    foreach (var player in _players)
                    {
                        player.Value.超时_准备超时 = GameLooper.Counter + 30; //30秒准备时间
                    }
                    serviceState = ServiceStates.等待客户端准备好;
                }
            }
            else if (serviceState == ServiceStates.等待客户端准备好)
            {
                var h = _currentStateHander as IWatingReady;

                if (!_players.IsInit)
                {
                    List<int> tempPlayerIDs = new List<int>();
                    foreach (var tempPlayer in _players)
                    {
                        tempPlayerIDs.Add(tempPlayer.Key);
                    }
                    _players.顺序索引(0).前面的玩家 = _players.顺序索引(2);
                    _players.顺序索引(0).后面的玩家 = _players.顺序索引(1);
                    _players.顺序索引(1).前面的玩家 = _players.顺序索引(0);
                    _players.顺序索引(1).后面的玩家 = _players.顺序索引(2);
                    _players.顺序索引(2).前面的玩家 = _players.顺序索引(1);
                    _players.顺序索引(2).后面的玩家 = _players.顺序索引(0);
                    _players.IsInit = true;
                }

                if (h.EveryOneIsReady(_players))
                {
                    发出_开始游戏();
                    serviceState = ServiceStates.正在游戏;
                }
            }
            else if (serviceState == ServiceStates.正在游戏)
            {

            }
            #endregion
        }

        #region 处理消息
        private void 处理_GM_请求服务数据()
        {
            发出_服务数据();
        }

        private void 发出_开始游戏()
        {
            Poker lastPoker;
            for (int i = 0; i < 5000; i++)  //洗牌,六个随机数向下替换.
            {
                //洗牌
                int num1 = new Random().Next(0, 27);
                lastPoker = AllPoker[num1];
                int num2 = new Random().Next(28, 54);
                AllPoker[num1] = AllPoker[num2];
                int num3 = new Random().Next(0, 54);
                AllPoker[num2] = AllPoker[num3];
                int num4 = new Random().Next(0, 10);
                AllPoker[num3] = AllPoker[num4];
                int num5 = new Random().Next(34, 54);
                AllPoker[num4] = AllPoker[num5];
                int num6 = new Random().Next(45, 54);
                AllPoker[num5] = AllPoker[num6];
                AllPoker[num6] = lastPoker;
                //发牌
                for (int j = 0; j < 17; j++)
                {
                    _players.顺序索引(0).MyPokerGroup.Add(AllPoker[j]);
                }
                for (int j = 17; j < 34; j++)
                {
                    _players.顺序索引(1).MyPokerGroup.Add(AllPoker[j]);
                }
                for (int j = 34; j < 51; j++)
                {
                    _players.顺序索引(2).MyPokerGroup.Add(AllPoker[j]);
                }
                var LandLordNum = new Random().Next(0, 3);
                var TheLandLord = _players.顺序索引(LandLordNum);
                TheLandLord.IsTheLandLord = true;
                for (int j = 51; j < 54; j++)
                {
                    LandLordPoker.Add(AllPoker[j]);
                }
                byte[][] sendData;
                foreach (var player in _players)
                {
                    sendData = new byte[][] { BitConverter.GetBytes(player.Key), 
                        BitConverter.GetBytes((int)DDZActions.S_开始游戏),
                        player.Value.MyPokerGroup.GetBuffer(),
                        BitConverter.GetBytes(TheLandLord.PlayerID) };
                    发出消息(sendData);
                }
            }
        }


        private void 处理_不叫(int playerid)
        {
            var tempPlayer = _players[playerid];
            if (tempPlayer.IsTheLandLord)
            {
                tempPlayer.IsTheLandLord = false;
                tempPlayer.后面的玩家.IsTheLandLord = true;
                发出_可以叫地主的玩家ID(tempPlayer.后面的玩家.PlayerID);
            }
        }

        private void 处理_叫地主(int playerid)
        {
            var tempPlayer = _players[playerid];
            if (tempPlayer.IsTheLandLord)
            {
                foreach (var poker in LandLordPoker)
                {
                    tempPlayer.MyPokerGroup.Add(poker);
                }
                tempPlayer.clientState = DDZClientStates.等待出牌;
                发出_地主牌(tempPlayer.PlayerID);
            }
        }
        private void 处理_Pass(int playerid)
        {
            DDZCharacter thisPlayer = _players[playerid];
            if (thisPlayer.clientState != DDZClientStates.已出牌)
            {
                thisPlayer.clientState = DDZClientStates.Pass;
                thisPlayer.后面的玩家.clientState = DDZClientStates.等待出牌;
                thisPlayer.后面的玩家.超时_出牌超时 = GameLooper.Counter + 30;
                发出_请出牌(thisPlayer.后面的玩家.PlayerID);
            }
        }

        private void 处理_出牌(int playerid, byte[][] p)
        {
            DDZCharacter thisPlayer = _players[playerid];
            PokerGroup tempPG = new PokerGroup();
            PokerGroup LastPlayerPokerGroup = thisPlayer.前面的玩家.LastPokerGroup;
            if (tempPG > LastPlayerPokerGroup && thisPlayer.clientState == DDZClientStates.等待出牌)
            {
                thisPlayer.clientState = DDZClientStates.已出牌;
                thisPlayer.LastPokerGroup = tempPG;
                thisPlayer.后面的玩家.clientState = DDZClientStates.等待出牌;
                thisPlayer.后面的玩家.超时_出牌超时 = GameLooper.Counter + 30; //30秒出牌
                发出_请出牌(thisPlayer.后面的玩家.PlayerID);
                List<int> removeIds = new List<int>();
                foreach (var tempPoker in tempPG)
                {
                    for (int i = 0; i < thisPlayer.MyPokerGroup.Count; i++)
                    {
                        var tempPoker2 = thisPlayer.MyPokerGroup[i];
                        if (tempPoker.pokerColor == tempPoker2.pokerColor && tempPoker.pokerNum == tempPoker2.pokerNum)
                        {
                            removeIds.Add(i);
                        }
                    }
                }
                foreach (var ID in removeIds)
                {
                    thisPlayer.MyPokerGroup.RemoveAt(ID);
                }
                if (thisPlayer.MyPokerGroup.Count == 0)
                {
                    foreach (var player in _players)
                    {
                        发出_本局结果(player.Value.PlayerID, thisPlayer.PlayerID);
                    }
                }
            }
        }


        private void 处理_准备(int playerid)
        {
            if (_players.ContainsKey(playerid))
            {
                _players[playerid].clientState = DDZClientStates.已准备;
            }
        }

        private void 处理_进入(int playerid)
        {
            if (_players.ContainsKey(playerid))
            {
                var tempPlayer = _players[playerid];
                tempPlayer.clientState = DDZClientStates.已进入;
                发出_请准备(playerid);
            }
        }

        private void 处理_能否进入(int playerid)
        {
            if (_currentStateHander.CanIJoinIt(_players.Count))
            {
                var tempPlayer = new DDZCharacter();
                tempPlayer.超时_进入超时 = GameLooper.Counter + 10;
                tempPlayer.PlayerID = playerid;
                tempPlayer.clientState = DDZClientStates.等待进入;
                _players.Add(playerid, tempPlayer);
                发出_能进入(playerid);

            }
            else
            {
                发出_不能进入(playerid);
            }
        }
        #endregion
        #region 发出消息


        /// <summary>
        /// 群发给所有玩家可以叫地主的人.
        /// </summary>
        /// <param name="playerid"></param>
        private void 发出_可以叫地主的玩家ID(int playerid)
        {
            byte[][] sendData;
            foreach (var player in _players)
            {
                sendData = new byte[][] { BitConverter.GetBytes(player.Key),
                    BitConverter.GetBytes((int)DDZActions.S_可以叫地主的玩家ID),
                    BitConverter.GetBytes(playerid)};
                发出消息(sendData);
            }
        }
        /// <summary>
        /// 群发给所有玩家地主牌以及地主ID
        /// </summary>
        /// <param name="LandLordID"></param>
        private void 发出_地主牌(int LandLordID)
        {
            byte[][] sendData;
            foreach (var player in _players)
            {
                sendData = new byte[][] {BitConverter.GetBytes(player.Key),
                    BitConverter.GetBytes((int)DDZActions.S_地主牌),
                    LandLordPoker.GetBuffer(),
                    BitConverter.GetBytes(LandLordID)};
                发出消息(sendData);
            }
        }


        private void 发出_本局结果(int playerID, int WinerID)
        {
            byte[][] sendData = new byte[][] {BitConverter.GetBytes(playerID),
                BitConverter.GetBytes((int)DDZActions.S_结果),
                BitConverter.GetBytes(WinerID)};
            发出消息(sendData);
        }

        private void 发出_请出牌(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_请出牌) };
            发出消息(sendData);
        }

        private void 发出_请准备(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_请准备) };
            发出消息(sendData);
        }

        private void 发出_不能进入(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_不能进入) };
            发出消息(sendData);
        }

        private void 发出_能进入(int playerID)
        {
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(playerID), BitConverter.GetBytes((int)DDZActions.S_能进入) };
            发出消息(sendData);
        }



        private void 发出_服务数据()
        {
            List<int> playerIdsList = new List<int>();
            foreach (var tempPlayer in _players)
            {
                playerIdsList.Add(tempPlayer.Key);
            }
            int[] playerIDs = playerIdsList.ToArray();
            byte[][] sendData = new byte[][] { BitConverter.GetBytes(0),
                BitConverter.GetBytes((int)DDZActions.S_返回服务数据),
                playerIDs.ToBinary() };
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(GameMainID, sendData));
            }
        }
        #endregion
        #region 发出消息公共方法
        /// <summary>
        /// 发送消息给绑定的大厅
        /// </summary>
        /// <param name="sendData">消息</param>
        private void 发出消息(byte[][] sendData)
        {
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(GameMainID, sendData));
            }
        }
        /// <summary>
        /// 发送消息给指定的ID
        /// </summary>
        /// <param name="sendTo">指定的ID</param>
        /// <param name="sendData">消息</param>
        private void 发出消息(int sendTo, byte[][] sendData)
        {
            lock (_sync_sendWhispers)
            {
                _sendWhispers.Enqueue(new KeyValuePair<int, byte[][]>(sendTo, sendData));
            }
        }
        #endregion
        public void SendMessage(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                lock (_sync_sendWhispers)
                {
                    KeyValuePair<int, byte[][]>[] whispers = new KeyValuePair<int, byte[][]>[_sendWhispers.Count];
                    _sendWhispers.CopyTo(whispers, 0);
                    _sendWhispers.Clear();
                    foreach (var whisper in whispers)
                    {
                        this.ContactCenterProxy.Whisper(whisper.Key, whisper.Value);
                    }
                    Thread.Sleep(1);
                }
            }
        }
        public void Exit()
        {
            w.WE();
        }

        #endregion
    }
}
