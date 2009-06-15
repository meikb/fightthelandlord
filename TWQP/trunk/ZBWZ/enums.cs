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
    public enum ServiceStates
    {
        正在游戏, 等待客户端准备好, 等待客户端进入
    }
    public enum ClientStates
    {
        已发_能进否,
        已发_要求进入,
        已发_已准备好,
        已发_已掷骰子,
        已发_已看成绩单
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
        S_结果
    }
}
