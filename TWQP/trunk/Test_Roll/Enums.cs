#region usings
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
#endregion

/// <summary>
/// RollGame 的各种行为
/// </summary>
public enum RollActions
{
    /// <summary>
    /// 玩家首先请求服务
    /// </summary>
    C要求进入,
    /// <summary>
    /// 针对 C要求进入，服务肯定回应
    /// </summary>
    S请进入,
    /// <summary>
    /// 针对 C要求进入，服务否定回应
    /// </summary>
    S不能进入,
    /// <summary>
    /// 针对 S请进入，客户端回应已进入
    /// </summary>
    C已进入,
    /// <summary>
    /// 针对 C已进入，服务让客户端作好游戏准备
    /// </summary>
    S请准备,
    /// <summary>
    /// 针对 S请准备 或 S请看成绩，客户端回应已准备好
    /// </summary>
    C已准备好,
    /// <summary>
    /// 针对 C已准备好，服务指示客户端产生游戏行为
    /// </summary>
    S请投掷,
    /// <summary>
    /// 针对 S请投掷，客户端回应玩家已操作
    /// </summary>
    C已投掷,
    /// <summary>
    /// 针对 C已投掷，服务器下发本次比赛成绩报表到客户端（等同于 S请准备）
    /// </summary>
    S请看成绩,

    /// <summary>
    /// 当服务发现客户端存在违规行为（超时，操作异常等）时，将客户端排除在服务对象之外
    /// </summary>
    S请离开,
    /// <summary>
    /// 客户端因某些原因导致数据不准确，需要重新获取自己的状态数据时，向服务发起请求
    /// </summary>
    C请核实,
    /// <summary>
    /// 服务器向客户端发送当前客户端于服务端的所有数据，以帮助客户端同步
    /// </summary>
    S请接受核实
}

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
/// 用来表达一对 Long 值
/// </summary>
public class LongPair
{
    public LongPair(long first, long second)
    {
        this.First = first;
        this.Second = second;
    }
    public long First { get; set; }
    public long Second { get; set; }
}

/// <summary>
/// 用于 RollService 中记录玩家当前状态
/// </summary>
[Serializable]
public class Character : OO.User_Character
{
    public DateTime 进入服务时间 = DateTime.Now;
    public int 总局数 = 0;
    public int 获胜局数 = 0;
    public int 当前投掷点数 = 0;

    public List<RollActions> 当前允许收到的客户端消息列表 = new List<RollActions>();
    public LongPair 超时_C已进入 = new LongPair(10, 0);
    public LongPair 超时_C已准备好 = new LongPair(30, 0);
    public LongPair 超时_C已投掷 = new LongPair(30, 0);
}

public enum 服务状态枚举
{
    /// <summary>
    /// 该过程耗时 10 秒
    /// </summary>
    等进入,
    /// <summary>
    /// 该过程耗时 30 秒
    /// </summary>
    等准备,
    /// <summary>
    /// 该过程耗时 30 秒
    /// </summary>
    游戏中
}


/*
public enum 客户端状态枚举
{
    /// <summary>
    /// 如果玩家进入时服务人数上限未到，且未处于 “等进入” 阶段，则将处于 观战状态
    /// </summary>
    正在观战,
    /// <summary>
    /// 正在联系游戏服务以进入游戏
    /// </summary>
    正在进,
    /// <summary>
    /// 已联系上游戏服务，进入了游戏，等待用户发出 已准备好 指令
    /// </summary>
    已进入未准备,
    /// <summary>
    /// 用户已发出 已准备好 指令，但未进行游戏行为（投掷）
    /// </summary>
    已准备未投掷,
    /// <summary>
    /// 用户已投掷，未收到成绩报表或看完后未重新发出 已准备好 指令
    /// </summary>
    已投掷未准备,
}
*/