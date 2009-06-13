using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ
{
    interface IWatingJoin
    {
        /// <summary>
        /// 玩家数量
        /// </summary>
        int AmountPlayer { get; set; }
        /// <summary>
        /// 通过现有玩家数量判断是否可以加入
        /// </summary>
        /// <param name="Amount">现有玩家数量</param>
        /// <returns>发送给客户端的数据</returns>
        byte[][] CanIJoinIt(int Amount);
    }
}
