using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;


/// <summary>
/// 收发 Roll 相关消息所用到的结构
/// </summary>
public class RollMessage
{
    public int ID;
    public RollActions RollAction;
    public byte[] Data;
}

/// <summary>
/// 计数器，用一对 Long 值来表达 计数目标，当前计数
/// </summary>
public class Counter
{
    public Counter(long max, long current)
    {
        this.Max = max;
        this.Current = current;
    }
    public long Max;
    public long Current;
    /// <summary>
    /// 如果 Current >= Max , 返回 True
    /// </summary>
    public bool IsOvertimed
    {
        get { return this.Current >= this.Max; }
    }
    /// <summary>
    /// 令 Current ++
    /// </summary>
    public void Increase()
    {
        this.Current++;
    }
    /// <summary>
    /// 复位计数
    /// </summary>
    public void Clear()
    {
        this.Current = 0;
    }
}

/// <summary>
/// 用于存放 Roll 游戏中的各种状态数据
/// </summary>
public class RollGameState
{
    public 服务阶段枚举 当前阶段 = 服务阶段枚举.等所有玩家进入;
    public Counter 超时_等所有玩家进入 = new Counter(10, 0);
    public Counter 超时_等所有玩家准备 = new Counter(30, 0);
    public Counter 超时_等掷骰子 = new Counter(30, 0);
}

/// <summary>
/// 用于 RollService 中记录玩家当前状态
/// </summary>
[Serializable]
public class Character : OO.User_Character
{
    public 客户端阶段枚举 当前阶段 = 客户端阶段枚举.正在进;
    public DateTime 进入服务时间 = DateTime.Now;
    public int 总局数 = 0;
    public int 获胜局数 = 0;
    public int 当前投掷点数 = 0;

    public List<RollActions> 当前允许收到的客户端消息列表 = new List<RollActions>();
    public Counter 超时_C已进入 = new Counter(10, 0);
    public Counter 超时_C已准备好 = new Counter(30, 0);
    public Counter 超时_C已投掷 = new Counter(30, 0);
}
