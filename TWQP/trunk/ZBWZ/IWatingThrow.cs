using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ
{
    interface IWatingThrow
    {
        /// <summary>
        /// 已投掷骰子玩家数量
        /// </summary>
        int ThrewPlayerAmount { get; set; }
        /// <summary>
        /// 每局的分数
        /// </summary>
        int RoundScore { get; set; }
        /// <summary>
        /// 所有玩家是否已投掷骰子
        /// </summary>
        /// <param name="PlayerAmount">玩家列表</param>
        /// <returns>所有玩家是否已投掷骰子</returns>
        bool EveryOneIsThrew(List<Player> players);
        /// <summary>
        /// 投掷骰子
        /// </summary>
        /// <param name="player">玩家</param>
        /// <returns>返回发送给玩家的Num数据</returns>
        byte[][] Throw(Player player);
        /// <summary>
        /// 得到本局结果
        /// </summary>
        /// <param name="players">所有玩家集合</param>
        /// <returns>结果</returns>
        byte[][] GetResult(List<Player> players);
        /// <summary>
        /// 获取玩家分数比特流
        /// </summary>
        /// <param name="player">玩家</param>
        /// <returns>分数比特流</returns>
        byte[][] GetScore(Player player);
    }
}
