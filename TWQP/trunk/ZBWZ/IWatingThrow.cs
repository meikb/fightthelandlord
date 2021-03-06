﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ
{
    public interface IWatingThrow
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
        bool EveryOneIsThrew(Dictionary<int, KeyValuePair<int, Character>> players);
        /// <summary>
        /// 投掷骰子
        /// </summary>
        /// <param name="player">玩家</param>
        /// <returns>返回发送给玩家的Num数据</returns>
        byte[][] Throw(Character player);
        ///// <summary>
        ///// 得到本局结果
        ///// </summary>
        ///// <param name="players">所有玩家集合</param>
        ///// <returns>结果</returns>
        //byte[][] GetResult(Dictionary<int, KeyValuePair<int, Character>> players);
        /// <summary>
        /// 获取玩家分数比特流
        /// </summary>
        /// <param name="player">玩家</param>
        /// <returns>分数比特流</returns>
        byte[][] GetScore(Character player);
        ///// <summary>
        ///// 谁投掷骰子超时了
        ///// </summary>
        ///// <param name="Counter">计时器</param>
        ///// <param name="players">玩家列表</param>
        ///// <returns>超时的玩家</returns>
        //Dictionary<int, KeyValuePair<int, Character>> WhoThrowTimeOuted(long Counter, Dictionary<int, KeyValuePair<int, Character>> players);
    }
}
