using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constructs
{
    public enum ActionType
    {
        Join = 1,
        Ready = 2,
        Start = 3,
        Out = 4,
        Throw = 5,
    }
    public enum DataType
    {
        Action = 1,
        UserMessage = 2,
        SystemMessage = 3,
        TimeOut = 4,
        Num = 5,
        OtherNum,
    }
    public enum Result
    {
        Win = 1,
        Lose = 2,
        Same = 3,
    }
}
