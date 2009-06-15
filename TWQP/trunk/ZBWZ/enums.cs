using System;
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
    public enum GameStates
    {
        WatingJoin,
        WatingReady,
        WatingThrow,
    }
    public enum 服务状态枚举
    {
        正在游戏, 等待客户端准备好, 等待客户端进入
    }
    public enum 客户端状态枚举
    {
        已发_能进否,
        已发_要求进入,
        已回_已准备好,
        已回_已掷骰子,
        已回_已看成绩单
    }

    public enum ServiceActions
    {
        // Client Action : 发_能进否
        回_能进,
        回_不能进,

        // Client Action : 发_要求进入
        回_请进入,
        回_不能进入,

        发_请准备,

        发_请掷骰子,

        发_请看成绩单     // 带数据报表
    }

    public enum ClientActions
    {
        发_能进否,

        发_要求进入,

        // Service Action : 发_请准备
        回_已准备好,

        // Service Action : 发_请掷骰子
        回_已掷骰子,

        // Service Action : 发_请看成绩单
        回_已看成绩单
    }
}
