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
    public enum Result
    {
        Win,
        Lose,
        Same,
    }
}
