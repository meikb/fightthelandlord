using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ_DDZ
{
    public interface IWatingJoin
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
        bool CanIJoinIt(int Amount);
        /// <summary>
        /// 所有用户是否已加入
        /// </summary>
        /// <param name="players">用户列表</param>
        /// <returns>是否全部加入</returns>
        bool JoinSuccess(PlayerCollection players);
    }
}
