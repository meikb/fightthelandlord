using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ
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
        /// 找出超时玩家
        /// </summary>
        /// <param name="Counter">计时器</param>
        /// <param name="players">玩家列表</param>
        /// <returns>超时玩家</returns>
        //Dictionary<int, KeyValuePair<int, Character>> WhoJoinTimeOuted(long Counter, Dictionary<int, KeyValuePair<int, Character>> players);
        /// <summary>
        /// 所有用户是否已加入
        /// </summary>
        /// <param name="players">用户列表</param>
        /// <returns>是否全部加入</returns>
        bool JoinSuccess(Dictionary<int, KeyValuePair<int, Character>> players);
    }
}
