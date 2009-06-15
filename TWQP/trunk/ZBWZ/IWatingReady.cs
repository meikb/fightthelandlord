using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ
{
    public interface IWatingReady
    {
        ///// <summary>
        ///// 已准备玩家数量
        ///// </summary>
        //int ReadyPlayerAmount { get; set; }
        /// <summary>
        /// 所有玩家是否已准备
        /// </summary>
        /// <param name="playerAmount">玩家数量</param>
        /// <returns>是否全部准备</returns>
        bool EveryOneIsReady(Dictionary<int, KeyValuePair<int, Character>> players);
        /// <summary>
        /// 得到发送给客户端的游戏开始数据
        /// </summary>
        /// <returns>游戏开始数据</returns>
        byte[][] GetStartData();
        ///// <summary>
        ///// 有玩家准备
        ///// </summary>
        //void PlayerReady(Character player);
        ///// <summary>
        ///// 返回已超时的玩家,没有超时返回null
        ///// </summary>
        ///// <param name="Counter">计时器</param>
        ///// <param name="players">玩家列表</param>
        ///// <returns>已超时玩家或null</returns>
        //Dictionary<int, KeyValuePair<int, Character>> WhoReadyTimeOuted(long Counter, Dictionary<int, KeyValuePair<int, Character>> players);

    }
}
