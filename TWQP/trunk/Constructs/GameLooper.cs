using System;

public partial interface IGameLoopHandler
{
    /// <summary>
    /// 指向当前游戏循环实例。用来访问游戏循环中相关的属性值
    /// </summary>
    GameLooper GameLooper { get; set; }
    /// <summary>
    /// 进入循环前的初始化
    /// </summary>
    void Init();
    /// <summary>
    /// 每个循环时调用
    /// </summary>
    void Process();
    /// <summary>
    /// 循环退出后
    /// </summary>
    void Exit();
}

/// <summary>
/// 游戏主循环
/// </summary>
public partial class GameLooper
{
    #region Properties

    /// <summary>
    /// 游戏循环中用到的方法实例
    /// </summary>
    protected IGameLoopHandler _handler;

    /// <summary>
    /// 是否正在循环
    /// </summary>
    public bool IsLooping { get; set; }

    /// <summary>
    /// 每次循环所消耗的时间上限（限速模式）
    /// </summary>
    public long LoopDurationLimit { get; set; }

    /// <summary>
    /// 是否为限速模式
    /// </summary>
    public bool IsSpeedLimitMode { get; set; }

    /// <summary>
    /// 每次循环所消耗的时间 0.0001 秒为单位
    /// </summary>
    public long LoopDuration
    {
        get { return this.Stopwatch.ElapsedMilliseconds - this.LastDuration; }
    }

    /// <summary>
    /// 上个循结束时所经历的总时长
    /// </summary>
    public long LastDuration { get; set; }

    /// <summary>
    /// 当前所经历的总时长
    /// </summary>
    public long Duration { get { return this.Stopwatch.ElapsedMilliseconds; } }

    /// <summary>
    /// 游戏循环中用到的计时器
    /// </summary>
    public System.Diagnostics.Stopwatch Stopwatch { get; set; }

    /// <summary>
    /// 游戏循环计数器
    /// </summary>
    public long Counter { get; set; }

    /// <summary>
    /// 随机数发生器
    /// </summary>
    public Random Random { get; set; }

    /// <summary>
    /// 当前循环的 Process 是否已经被调用过
    /// </summary>
    public bool IsCurrentProcessCalled { get; set; }

    #endregion

    #region Constructor

    /// <summary>
    /// GameLoop 的构造函数（初始化，设置 handler）
    /// </summary>
    public GameLooper(IGameLoopHandler handler)
    {
        handler.GameLooper = this;
        this._handler = handler;
        this.Init();
    }

    #endregion

    #region Methods

    public void Init()
    {
        this.IsLooping = true;
        this.LastDuration = 0;
        this.Counter = 0;
        this.Stopwatch = new System.Diagnostics.Stopwatch();
        this.IsSpeedLimitMode = true;
        this.LoopDurationLimit = 100;
        this.IsCurrentProcessCalled = false;
    }

    /// <summary>
    /// 开始循环
    /// </summary>
    public void Loop()
    {
        this._handler.Init();
        this.Stopwatch.Start();
        while (this.IsLooping)
        {
            if (this.IsSpeedLimitMode)
            {
                if (this.IsCurrentProcessCalled)
                {
                    if (this.LoopDuration < this.LoopDurationLimit)
                        System.Threading.Thread.Sleep(1);
                    else this.IsCurrentProcessCalled = false;
                }
                else
                {
                    this.Counter++;
                    this.LastDuration = this.Duration;
                    this._handler.Process();
                    this.IsCurrentProcessCalled = true;
                }
            }
            else
            {
                this.Counter++;
                this._handler.Process();
            }
        }
        this.Stopwatch.Stop();
        _handler.Exit();
    }
    #endregion
}