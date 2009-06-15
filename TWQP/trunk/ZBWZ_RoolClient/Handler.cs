using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Timers;
using ConsoleHelper;
using ZBWZ;

namespace ZBWZ_RoolClient
{
    public class Handler : IDataCenterCallbackHandler, IGameLoopHandler
    {
        private Writer w = Writer.Instance;
        private object _syncObj = new object();
        private List<int> _rollServiceIdList = new List<int>();
        private Dictionary<int, KeyValuePair<int, Character>> I = new Dictionary<int, KeyValuePair<int, Character>>();
        public ConsoleKeyInfo kb { get; set; }
        public int ServerId { get; set; }

        public Handler(int serviceId)
        {
            this.ServiceID = serviceId;
        }

        #region IDataCenterCallbackHandler Members

        public int ServiceID { get; set; }
        public DataCenterProxy DataCenterProxy { get; set; }

        public void Receive(int id, byte[][] data)
        {
            w.WL(id + ": " + data + Environment.NewLine);
        }

        public void ReceiveWhisper(int id, byte[][] data)
        {
            DataType dataType = data[0].ToObject<DataType>();
            switch (dataType)
            {
                case DataType.Action:
                    ActionType actionType = data[1].ToObject<ActionType>();
                    if (actionType == ActionType.YouCanJoinIt)
                    {

                    }
                    if (actionType == ActionType.YouCanNotJoinIt)
                    {

                    }
                    if (actionType == ActionType.JoinedSuccess)
                    {

                    }
                    if (actionType == ActionType.Out)
                    {

                    }
                    if (actionType == ActionType.Start)
                    {

                    }
                    break;
                case DataType.Num:
                    break;
                case DataType.TimeOutTime:

                    break;
                case DataType.Score:

                    break;
                case DataType.Result:
                    break;
            }
            //w.WL(id + " whisper: " + data + Environment.NewLine);
        }

        public void ServiceEnter(int id)
        {
            if (id > 100)
            {
                lock (_syncObj)
                {
                    if (!_rollServiceIdList.Contains(id)) _rollServiceIdList.Add(id);
                    // todo
                }
            }
            w.WL("Service " + id + " enter at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void ServiceLeave(int id)
        {
            if (id > 100)
            {
                lock (_syncObj)
                {
                    if (_rollServiceIdList.Contains(id)) _rollServiceIdList.Remove(id);
                    // todo
                }
            }
            w.WL("Service " + id + " leave at " + DateTime.Now.ToString() + Environment.NewLine);
        }

        public void JoinSuccessed(int[] serviceIdList)
        {
            foreach (var id in serviceIdList)
                if (id > 100) _rollServiceIdList.Add(id);

            w.WL("已于" + DateTime.Now.ToString() + " 连入数据中心");
            if (_rollServiceIdList.Count > 0)
            {
                w.W("发现 Roll 游戏服务器：");
                w.W("请输入服务器ID加入相应服务器" + Environment.NewLine);
                w.W<int>(_rollServiceIdList);
                w.WL();
            }
            else
            {
                w.W("未发现任何 Roll 游戏服务器！");
            }
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
游戏开始运行.
类型：RollGame Client
编号：{0}
时间：{1}
", this.ServiceID, DateTime.Now);
        }

        public void Process()
        {
        }

        public void Exit()
        {
            w.WE();
        }

        #endregion

    }
}
