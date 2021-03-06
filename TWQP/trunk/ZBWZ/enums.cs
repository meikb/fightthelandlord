﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZBWZ
{
    public enum ActionType
    {
        CanIJoinIt,
        YouCanJoinIt,
        YouCanNotJoinIt,
        Join,
        JoinedSuccess,
        YouCanReady,
        Ready,
        Start,
        Out,
        Throw,
    }
    public enum DataType
    {
        Action,
        UserMessage,
        SystemMessage,
        TimeOutTime,
        Num,
        Result,
        Score,
    }
    public enum ServiceStates
    {
        正在游戏, 等待客户端准备好, 等待客户端进入
    }
    public enum ClientStates
    {
        收到_断开,
        已发_能进否,
        已发_要求进入,
        已发_已准备好,
        已发_已掷骰子,
        已发_已看成绩单,
        收到_请准备,
        收到_请投掷
    }

    public enum RollActions
    {
        C_能否进入,
        C_进入,
        C_准备,
        C_投掷,
        S_能进入,
        S_不能进入,
        S_请准备,
        S_请投掷,
        S_点数,
        S_结果,
        S_踢出
    }
    #region 斗地主

    public enum DDZClientStates
    {
        等待进入,
        已进入,
        等待准备,
        已准备,
        等待出牌,
        已出牌,
        Pass,
        断开
    }

    public enum DDZActions
    {
        C_能否进入,
        C_进入,
        C_选择桌子,
        C_准备,
        C_叫地主,
        C_出牌,
        C_Pass,
        C_断开,
        C_请求桌子数据,
        S_能进入,
        S_不能进入,
        S_坐下,
        S_请准备,
        S_请叫地主,
        S_请出牌,
        S_点数,
        S_结果,
        S_踢出,
        S_返回服务数据,
        GM_请求服务数据,
        GM_桌子数据
    }
    #endregion
}
