using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;

namespace Bejeweled
{
    public partial class BejeweledGameMain : UserControl
    {
        /// <summary>
        /// 动画是否正在播放
        /// </summary>
        public bool AnimationIsPlaying { get; set; }
        /// <summary>
        /// 鼠标左键单击坐标
        /// </summary>
        private Point mouseUpBeforePoint;
        /// <summary>
        /// 宝石矩阵
        /// </summary>
        private bijou[,] bijous = new bijou[MaxColumn, MaxRow];

        /// <summary>
        /// 更新分数
        /// </summary>
        public Action<int> UpdateScoure;

        /// <summary>
        /// 获取当前分数
        /// </summary>
        public Func<int> GetScore;

        /// <summary>
        /// 最大列,不包含0
        /// </summary>
        const int MaxColumn = 8;
        /// <summary>
        /// 最大行,不包含0
        /// </summary>
        const int MaxRow = 8;

        /// <summary>
        /// 通过列号和行号获取bijou
        /// </summary>
        /// <param name="Column">列号</param>
        /// <param name="Row">行号</param>
        /// <returns>bijou</returns>
        public bijou this[int Column, int Row]
        {
            get
            {
                return bijous[Column, Row];
            }
            set
            {
                if (value != null)
                {
                    value.Column = Column;
                    value.Row = Row;
                    bijous[Column, Row] = value;
                    if (!LayoutRoot.Children.Contains(value))
                    {
                        this.LayoutRoot.Children.Add(value);
                    }
                }
                else
                {
                    bijous[Column, Row] = null;
                }
            }
        }

        public BejeweledGameMain()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 初始化游戏
        /// </summary>
        public void InitGame()
        {
            this.Visibility = Visibility.Collapsed;
            for (int row = 0; row < MaxRow; row++)
            {
                for (int column = 0; column < MaxColumn; column++)
                {
                    int type = GetRandomNum();
                    var tempbijou = new bijou(type, column, row);
                    this[column, row] = tempbijou;
                }
            }
            while (true)
            {
                var earsablebijous = GetErasablebijou();
                if (earsablebijous != null)
                {
                    foreach (var tempBijou in earsablebijous)
                    {
                        var random = new Random();
                        int type = GetRandomNum();
                        this.LayoutRoot.Children.Remove(this[tempBijou.Column, tempBijou.Row]);
                        this[tempBijou.Column, tempBijou.Row] = new bijou(type, tempBijou.Column, tempBijou.Row);
                    }
                }
                else
                {
                    break;
                }
            }
            this.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// 获取一个随机数
        /// </summary>
        /// <returns>随机数</returns>
        public int GetRandomNum()
        {
            Thread.Sleep(10);
            long tick = DateTime.Now.Ticks;
            Random r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            return r.Next(1, 8);
        }
        /// <summary>
        /// 调换两个bijou的位置
        /// </summary>
        /// <param name="bijou1">第一个bijou</param>
        /// <param name="bijou2">第二个bijou</param>
        public void ExchangeLocation(bijou bijou1, bijou bijou2)
        {
            int bijou1Column = bijou1.Column;
            int bijou1Row = bijou1.Row;
            int bijou2Column = bijou2.Column;
            int bijou2Row = bijou2.Row;
            this[bijou1Column, bijou1Row] = bijou2;
            this[bijou2Column, bijou2Row] = bijou1;

            //int bijouColumn = bijou1.Column;
            //int bijouRow = bijou1.Row;
            //bijou1.Column = bijou2.Column;
            //bijou1.Row = bijou2.Row;
            //bijou2.Column = bijouColumn;
            //bijou2.Row = bijouRow;
        }

        /// <summary>
        /// 让第一个bijou的Zindex值比第二个大
        /// </summary>
        /// <param name="addedbijou">被加Zindex值的bijou</param>
        /// <param name="?">参考值</param>
        public void AddingZindexBybijou(bijou addedbijou, bijou referencebijou)
        {
            Canvas.SetZIndex(addedbijou, Canvas.GetZIndex(referencebijou) + 1);
        }

        /// <summary>
        /// 将指定的宝石向上移动一格
        /// </summary>
        /// <param name="bijou">要移动的宝石</param>
        public void Up(bijou bijou, bool isRollBack)
        {
            var near = GetbijouByDirection(bijou, Direction.Up);
            if (near != null)
            {
                this.ExchangeLocation(bijou, near); //调换两个宝石的位置
                AddingZindexBybijou(bijou, near); //让bijou的Zindex比near大
                bijou.RenderTransform = new TranslateTransform();
                bijou.RenderTransform.SetValue(TranslateTransform.YProperty, 64.0); //实际位置已经往上移了一位,所以往下平移64
                near.RenderTransform = new TranslateTransform();
                near.RenderTransform.SetValue(TranslateTransform.YProperty, -64.0); //实际位置已经往下移了一位,所以网上平移64

                EventHandler neareh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
                });

                EventHandler bijoueh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
                    var erasableBjous = GetErasablebijou();
                    if (erasableBjous == null)
                    {
                        Up(near,false);
                    }
                    else
                    {
                        RemoveListBijou(erasableBjous);
                    }
                });
                this.AddAnimationToStoryboard(near.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                if (isRollBack)
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300), bijoueh); //添加动画
                else
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                this.BeginAnimation();
            }
        }
        /// <summary>
        /// 将指定的宝石向下移动一格
        /// </summary>
        /// <param name="bijou">要移动的宝石</param>
        public void Down(bijou bijou, bool isRollBack)
        {
            var near = GetbijouByDirection(bijou, Direction.Down);
            if (near != null)
            {
                this.ExchangeLocation(bijou, near); //调换两个宝石的位置
                AddingZindexBybijou(bijou, near); //让bijou的Zindex比near大
                bijou.RenderTransform = new TranslateTransform();
                bijou.RenderTransform.SetValue(TranslateTransform.YProperty, -64.0); //实际位置已经往上移了一位,所以往下平移64
                near.RenderTransform = new TranslateTransform();
                near.RenderTransform.SetValue(TranslateTransform.YProperty, 64.0); //实际位置已经往下移了一位,所以网上平移64

                EventHandler neareh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
                });

                EventHandler bijoueh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
                    var erasableBjous = GetErasablebijou();
                    if (erasableBjous == null)
                    {
                        Down(near, false);
                    }
                    else
                    {
                        RemoveListBijou(erasableBjous);
                    }
                });
                this.AddAnimationToStoryboard(near.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                if (isRollBack)
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300), bijoueh); //添加动画
                else
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                this.BeginAnimation();
            }
        }
        /// <summary>
        /// 将指定的宝石向左移动一格
        /// </summary>
        /// <param name="bijou">要移动的宝石</param>
        public void Left(bijou bijou, bool isRollBack)
        {
            var near = GetbijouByDirection(bijou, Direction.Left);
            if (near != null)
            {
                this.ExchangeLocation(bijou, near); //调换两个宝石的位置
                AddingZindexBybijou(bijou, near); //让bijou的Zindex比near大
                bijou.RenderTransform = new TranslateTransform();
                bijou.RenderTransform.SetValue(TranslateTransform.XProperty, 64.0); //实际位置已经往上移了一位,所以往下平移64
                near.RenderTransform = new TranslateTransform();
                near.RenderTransform.SetValue(TranslateTransform.XProperty, -64.0); //实际位置已经往下移了一位,所以网上平移64

                EventHandler neareh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0);
                });

                EventHandler bijoueh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0);
                    var erasableBjous = GetErasablebijou();
                    if (erasableBjous == null)
                    {
                        Left(near, false);
                    }
                    else
                    {
                        RemoveListBijou(erasableBjous);
                    }
                });
                this.AddAnimationToStoryboard(near.RenderTransform, "X", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                if (isRollBack)
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "X", 0.0, TimeSpan.FromMilliseconds(300), bijoueh); //添加动画
                else
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "X", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                this.BeginAnimation();
            }
        }
        /// <summary>
        /// 将指定的宝石向右移动一格
        /// </summary>
        /// <param name="bijou">要移动的宝石</param>
        public void Right(bijou bijou, bool isRollBack)
        {
            var near = GetbijouByDirection(bijou, Direction.Right);
            if (near != null)
            {
                this.ExchangeLocation(bijou, near); //调换两个宝石的位置
                AddingZindexBybijou(bijou, near); //让bijou的Zindex比near大
                bijou.RenderTransform = new TranslateTransform();
                bijou.RenderTransform.SetValue(TranslateTransform.XProperty, -64.0); //实际位置已经往上移了一位,所以往下平移64
                near.RenderTransform = new TranslateTransform();
                near.RenderTransform.SetValue(TranslateTransform.XProperty, 64.0); //实际位置已经往下移了一位,所以网上平移64

                EventHandler neareh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0);
                });

                EventHandler bijoueh = new EventHandler((object sender1, EventArgs ea1) =>
                {
                    var da = sender1 as DoubleAnimation;
                    sbAll.Children.Remove(da);
                    bijou.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0); //播放完后还原平移变换
                    near.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0);
                    var erasableBjous = GetErasablebijou();
                    if (erasableBjous == null)
                    {
                        Right(near, false);
                    }
                    else
                    {
                        RemoveListBijou(erasableBjous);
                    }
                });
                this.AddAnimationToStoryboard(near.RenderTransform, "X", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                if (isRollBack)
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "X", 0.0, TimeSpan.FromMilliseconds(300), bijoueh); //添加动画
                else
                    this.AddAnimationToStoryboard(bijou.RenderTransform, "X", 0.0, TimeSpan.FromMilliseconds(300), neareh); //添加动画
                this.BeginAnimation();
            }
        }

        /// <summary>
        /// 获取指定bijou的指定方向的相邻bijou
        /// </summary>
        /// <param name="movedbijou">指定的bijou</param>
        /// <param name="direction">方向</param>
        /// <returns>相邻的bijou</returns>
        public bijou GetbijouByDirection(bijou movedbijou, Direction direction)
        {
            bijou returnbijou = null;
            switch (direction)
            {
                case Direction.Up:
                    if (movedbijou.Row != 0)
                    {
                        returnbijou = this[movedbijou.Column, movedbijou.Row - 1];
                    }
                    break;
                case Direction.Down:
                    if (movedbijou.Row != MaxColumn - 1)
                    {
                        returnbijou = this[movedbijou.Column, movedbijou.Row + 1];
                    }
                    break;
                case Direction.Left:
                    if (movedbijou.Column != 0)
                    {
                        returnbijou = this[movedbijou.Column - 1, movedbijou.Row];
                    }
                    break;
                case Direction.Right:
                    if (movedbijou.Column != MaxColumn - 1)
                    {
                        returnbijou = this[movedbijou.Column + 1, movedbijou.Row];
                    }
                    break;
            }
            return returnbijou;
        }
        
        /// <summary>
        /// 向Storyboard添加动画
        /// </summary>
        /// <param name="dobj">动画目标</param>
        /// <param name="property">被改变的值</param>
        /// <param name="to">动画完毕后的最终值</param>
        /// <param name="Duration">动画持续时间</param>
        /// <param name="eh">动画的完成事件处理程序</param>
        public void AddAnimationToStoryboard(DependencyObject dobj, string property, double to, TimeSpan Duration, EventHandler eh)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard.SetTarget(da, dobj);
            Storyboard.SetTargetProperty(da, new PropertyPath(property));
            da.To = to;
            da.Duration = new Duration(Duration);
            da.Completed += eh;
            sbAll.Children.Add(da);
        }

        /// <summary>
        /// 向Storyboard添加动画
        /// </summary>
        /// <param name="dobj">动画目标</param>
        /// <param name="property">被改变的值</param>
        /// <param name="to">动画完毕后的最终值</param>
        /// <param name="Duration">动画持续时间</param>
        public void AddAnimationToStoryboard(DependencyObject dobj, string property, double to, TimeSpan Duration)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard.SetTarget(da, dobj);
            Storyboard.SetTargetProperty(da, new PropertyPath(property));
            da.To = to;
            da.Duration = new Duration(Duration);
            sbAll.Children.Add(da);
        }

        /// <summary>
        /// 向Storyboard添加动画
        /// </summary>
        /// <param name="sb">目标Storyboard</param>
        /// <param name="dobj">动画目标</param>
        /// <param name="property">被改变的值</param>
        /// <param name="to">动画完毕后的最终值</param>
        /// <param name="Duration">动画持续时间</param>
        /// <param name="eh">Storyboard完成事件处理程序</param>
        public void AddAnimationToStoryboard(Storyboard sb, DependencyObject dobj, string property, double to, TimeSpan Duration)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard.SetTarget(da, dobj);
            Storyboard.SetTargetProperty(da, new PropertyPath(property));
            da.To = to;
            da.Duration = new Duration(Duration);
            sb.Children.Add(da);
        }
        /// <summary>
        /// 开始动画,使用默认的sbAll
        /// </summary>
        public void BeginAnimation()
        {
            AnimationIsPlaying = true;
            sbAll.Begin();
        }

        /// <summary>
        /// 开始指定的Storyboard动画
        /// </summary>
        public void BeginAnimation(Storyboard sb)
        {
            AnimationIsPlaying = true;
            sb.Begin();
        }

        /// <summary>
        /// 从LayoutRoot.Children中移除bijou列表
        /// </summary>
        /// <param name="bijous">要移除的bijou列表</param>
        public void RemoveListBijou(List<bijou> removebijous)
        {
            Storyboard sb = new Storyboard();
            sb.Completed += (object sender1, EventArgs ea1) =>
            {
                var sb2 = sender1 as Storyboard;
                sb.Stop();
                AnimationIsPlaying = false;
                foreach (var tempBijou2 in removebijous)
                {
                    tempBijou2.Opacity = 0.0;
                    this.LayoutRoot.Children.Remove(tempBijou2);
                    this[tempBijou2.Column, tempBijou2.Row] = null;
                }
                Resources.Remove("RemoveBijou");
                FillNull();
                UpdateScoure(45 + (removebijous.Count - 3) * 45);
            };
            Resources.Add("RemoveBijou", sb);
            foreach (var tempBijou in removebijous)
            {
                AddAnimationToStoryboard(sb, tempBijou, "Opacity", 0.0, TimeSpan.FromMilliseconds(200));
            }
            BeginAnimation(sb);
        }

        /// <summary>
        /// 下一关
        /// </summary>
        public void NextLevel()
        {
            this.LayoutRoot.Children.Clear();
            this.InitGame();
        }

        /// <summary>
        /// 创建并播放填充动画
        /// </summary>
        private void FillNull()
        {
            List<bijou> changedBijou = new List<bijou>();
            Storyboard sb = new Storyboard();
            sb.Completed += (object sender1, EventArgs ea1) =>
            {
                var sb2 = sender1 as Storyboard;
                sb2.Stop();
                AnimationIsPlaying = false;
                foreach (var tempBijou in changedBijou)
                {
                    tempBijou.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
                }
                Resources.Remove("sbFill");
                var erasableBijous = GetErasablebijou();
                if (erasableBijous != null)
                {
                    RemoveListBijou(erasableBijous);
                }
            };
            Resources.Add("sbFill", sb);
            for (int i = 0; i < MaxColumn; i++)
            {
                int nullNum = 0;
                int row = 0;
                for (int j = 0; j < MaxRow; j++)
                {
                    if (this[i, j] == null)
                    {
                        if (j > row) row = j;
                        nullNum++;
                    }
                }
                for (int k = row - nullNum; k >= 0 && nullNum != 0; k--) //添加被删除Bijou上面的Bijou下落动画
                {
                    DoubleAnimation da = new DoubleAnimation();
                    bijou tempBijou = this[i, k];
                    tempBijou.RenderTransform = new TranslateTransform();
                    tempBijou.RenderTransform.SetValue(TranslateTransform.YProperty, (double)-64 * nullNum);
                    AddAnimationToStoryboard(sb, tempBijou.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300 * nullNum));
                    this[tempBijou.Column, tempBijou.Row + nullNum] = tempBijou;
                    changedBijou.Add(tempBijou);
                }
                for (int l = nullNum - 1; l >= 0 && nullNum != 0; l--)  //创建新的Bijou填充已消除的
                {
                    int randomNum = GetRandomNum();
                    bijou tempBijou = new bijou(randomNum, i, l);
                    tempBijou.RenderTransform = new TranslateTransform();
                    tempBijou.RenderTransform.SetValue(TranslateTransform.YProperty, (double)-64 * nullNum);
                    AddAnimationToStoryboard(sb, tempBijou.RenderTransform, "Y", 0.0, TimeSpan.FromMilliseconds(300 * nullNum));
                    this[tempBijou.Column, tempBijou.Row] = tempBijou;
                    changedBijou.Add(tempBijou); 
                }
            }
            BeginAnimation(sb);
        }
        /// <summary>
        /// 提示玩家哪一个宝石通过移动后可以消除
        /// </summary>
        public void Hint()
        {
            bool Find = false;
            if (GetScore() > 100) //确认现有分数是否足够提示操作的消耗
            {
                #region 横条检测是否有可消除宝石
                for (int row = 0; row < MaxRow; row++)
                {
                    for (int column = 0; column < MaxColumn - 1; column++) //横条
                    {
                        if (this[column, row].Type == this[column + 1, row].Type) //两个连续相同,六种情况
                        {
                            if (column > 0 && row < MaxRow - 1)
                            {
                                if (this[column - 1, row + 1].Type == this[column, row].Type) //左下相同
                                {
                                    this[column - 1, row + 1].Hint();
                                    Find = true;
                                    break;
                                }
                                if (row > 0)
                                {
                                    if (this[column - 1, row - 1].Type == this[column, row].Type) //左上相同
                                    {
                                        this[column - 1, row - 1].Hint();
                                        Find = true;
                                        break;
                                    }
                                }
                            }
                            if (column < MaxColumn - 2 && row > 0)
                            {
                                if (this[column + 2, row - 1].Type == this[column, row].Type) //右上相同
                                {
                                    this[column + 2, row - 1].Hint();
                                    Find = true;
                                    break;
                                }
                                if (row < MaxRow - 1)
                                {
                                    if (this[column + 2, row + 1].Type == this[column, row].Type) //右下相同
                                    {
                                        this[column + 2, row + 1].Hint();
                                        Find = true;
                                        break;
                                    }
                                }
                            }

                            if (column > 1)
                            {
                                if (this[column - 2, row].Type == this[column, row].Type) // 左边第二个相同
                                {
                                    this[column - 2, row].Hint();
                                    Find = true;
                                    break;
                                }
                            }
                            if (column < MaxColumn - 3)
                            {
                                if (this[column + 3, row].Type == this[column, row].Type) //右边第二个相同
                                {
                                    this[column + 3, row].Hint();
                                    Find = true;
                                    break;
                                }
                            }
                        }
                        if (column < MaxColumn - 2)
                        {
                            if (this[column, row].Type == this[column + 2, row].Type) //中间隔一个的两个相同,两种情况
                            {
                                if (row > 0)
                                {
                                    if (this[column + 1, row - 1].Type == this[column, row].Type) //中间向上
                                    {
                                        this[column + 1, row - 1].Hint();
                                        Find = true;
                                        break;
                                    }
                                }
                                if (row < MaxRow - 1)
                                {
                                    if (this[column + 1, row + 1].Type == this[column, row].Type) //中间向下
                                    {
                                        this[column + 1, row + 1].Hint();
                                        Find = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    if (Find)
                        break;
                }
                #endregion
                if (!Find)
                {
                    #region 竖条检测是否有可消除宝石
                    for (int column = 0; column < MaxColumn; column++)
                    {
                        for (int row = 0; row < MaxRow - 1; row++) //竖条
                        {
                            if (this[column, row].Type == this[column, row + 1].Type) //两个连续相同,六种情况
                            {
                                if (row < MaxRow - 2 && column < MaxColumn - 1)
                                {
                                    if (this[column + 1, row + 2].Type == this[column, row].Type) //右下相同
                                    {
                                        this[column + 1, row + 2].Hint();
                                        Find = true;
                                        break;
                                    }
                                    if (column > 0)
                                    {
                                        if (this[column - 1, row + 2].Type == this[column, row].Type) //左下相同
                                        {
                                            this[column - 1, row + 2].Hint();
                                            Find = true;
                                            break;
                                        }
                                    }
                                }
                                if (row > 0 && column > 0)
                                {
                                    if (this[column - 1, row - 1].Type == this[column, row].Type) //左上相同
                                    {
                                        this[column - 1, row - 1].Hint();
                                        Find = true;
                                        break;
                                    }
                                    if (column < MaxColumn - 1)
                                    {
                                        if (this[column + 1, row - 1].Type == this[column, row].Type) //右上相同
                                        {
                                            this[column + 1, row - 1].Hint();
                                            Find = true;
                                            break;
                                        }
                                    }
                                }

                                if (row > 1)
                                {
                                    if (this[column, row - 2].Type == this[column, row].Type) // 上边第二个相同
                                    {
                                        this[column, row - 2].Hint();
                                        Find = true;
                                        break;
                                    }
                                }
                                if (row < MaxRow - 3)
                                {
                                    if (this[column, row + 3].Type == this[column, row].Type) //下边第二个相同
                                    {
                                        this[column, row + 3].Hint();
                                        Find = true;
                                        break;
                                    }
                                }
                            }
                            if (row < MaxRow - 2)
                            {
                                if (this[column, row].Type == this[column, row + 2].Type) //中间隔一个的两个相同,两种情况
                                {
                                    if (column > 0)
                                    {
                                        if (this[column - 1, row + 1].Type == this[column, row].Type) //中间向右
                                        {
                                            this[column - 1, row + 1].Hint();
                                            Find = true;
                                            break;
                                        }
                                    }
                                    if (column < MaxColumn - 1)
                                    {
                                        if (this[column + 1, row + 1].Type == this[column, row].Type) //中间向左
                                        {
                                            this[column + 1, row + 1].Hint();
                                            Find = true;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (Find)
                            break;
                    }
                    #endregion
                }
                if (Find)
                {
                    UpdateScoure(-100);
                }
            }
            else
            {
                 //todo 提示分数不够
            }
        }

        /// <summary>
        /// 获得可以被消除的宝石列表
        /// </summary>
        /// <returns>可以被消除的宝石列表,返回值为null表示不可消除</returns>
        public List<bijou> GetErasablebijou()
        {
            List<bijou> columnSameBijou = new List<bijou>();
            List<bijou> rowSameBijou = new List<bijou>();
            #region 检测横着排列的是否可消除并保存可消除的宝石到columnSameBijou
            for (int row = 0; row < MaxRow; row++)
            {
                int sameNum = 0;
                bool find = false;
                for (int column = 0; column < MaxColumn; column++)
                {
                    while (true)
                    {
                        if (column < MaxColumn - 1 && this[column, row].Type == this[column + 1, row].Type)
                        {
                            sameNum++;
                            column++;
                        }
                        else
                        {
                            if (sameNum >= 2)
                            {
                                for (; sameNum >= 0; sameNum--)
                                {
                                    columnSameBijou.Add(this[column - sameNum, row]);
                                }
                                find = true;
                                break;
                            }
                            else
                            {
                                sameNum = 0;
                            }
                            break;
                        }
                    }
                    if (find)
                        break;
                }
                if (find)
                    break;
            }
            #endregion

            #region 检测竖着排列的是否可消除并保存可消除的宝石到rowSameBijou
            for (int column = 0; column < MaxColumn; column++)
            {
                int sameNum = 0;
                bool find = false;
                for (int row = 0; row < MaxRow; row++)
                {
                    while (true)
                    {
                        if (row < MaxRow - 1 && this[column, row].Type == this[column, row + 1].Type)
                        {
                            sameNum++;
                            row++;
                        }
                        else
                        {
                            if (sameNum >= 2)
                            {
                                for (; sameNum >= 0; sameNum--)
                                {
                                    rowSameBijou.Add(this[column, row - sameNum]);
                                }
                                find = false;
                                break;
                            }
                            else
                            {
                                sameNum = 0;
                            }
                            break;
                        }
                    }
                    if (find)
                        break;
                }
                if (find)
                    break;
            }


            #endregion

            //if (columnSameBijou.Count >= 3)
            //{
            //    bijou lastBijou = null;
            //    foreach (var tempBijou in columnSameBijou)
            //    {
            //        if (lastBijou == null)
            //        {
            //            lastBijou = tempBijou;
            //        }
            //        if (tempBijou.Row != lastBijou.Row)
            //        {
            //            columnSameBijou.Clear();
            //            break;
            //        }
            //        lastBijou = tempBijou;
            //    }
            //}

            if (rowSameBijou.Count >= 3)
            {
                foreach (var tempBijou in columnSameBijou)
                {
                    if (tempBijou.Column == rowSameBijou[0].Column)
                    {
                        columnSameBijou.Clear();
                        break;
                    }
                }
            }
            #region 合并两个集合并返回
            if (columnSameBijou.Count >= 3 || rowSameBijou.Count >= 3)
            {
                List<bijou> returnBijous = new List<bijou>();
                foreach (var tempBijou in columnSameBijou)
                {
                    returnBijous.Add(tempBijou);
                }
                foreach (var tempBijou in rowSameBijou)
                {
                    if (!columnSameBijou.Contains(tempBijou)) //不允许重复添加
                    {
                        returnBijous.Add(tempBijou);
                    }
                }
                return returnBijous;
            }
            else
            {
                return null;
            }
            #endregion
        }

        #region 事件处理程序
        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(bijou))
            {
                this.mouseUpBeforePoint = e.GetPosition(null);
                bijou tempbijou = (bijou)e.OriginalSource;
                tempbijou.CaptureMouse();
            }
        }

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource != null && e.OriginalSource.GetType() == typeof(bijou) && !AnimationIsPlaying)
            {
                bijou movedbijou = (bijou)e.OriginalSource;
                if (movedbijou.isMouseLeftButtonDown)
                {
                    Point mousePoint = e.GetPosition(null);
                    double XCha = mousePoint.X - mouseUpBeforePoint.X;
                    double YCha = mousePoint.Y - mouseUpBeforePoint.Y;
                    double absXCha = Math.Abs(XCha);
                    double absYCha = Math.Abs(YCha);
                    #region 判断移动方向
                    if (absXCha > 10 || absYCha > 10)
                    {
                        if (XCha > 10 && YCha < 10)
                        {
                            if (absXCha > absYCha)
                            {
                                this.Right(movedbijou, true);
                            }
                            else
                            {
                                this.Up(movedbijou, true);
                            }
                        }
                        else if (XCha > 10 && YCha > 10)
                        {
                            if (absXCha > absYCha)
                            {
                                this.Right(movedbijou, true);
                            }
                            else
                            {
                                this.Down(movedbijou, true);
                            }
                        }
                        else if (XCha < 10 && YCha > 10)
                        {
                            if (absXCha > absYCha)
                            {
                                this.Left(movedbijou, true);
                            }
                            else
                            {
                                this.Down(movedbijou, true);
                            }
                        }
                        else if (XCha < 10 && YCha < 10)
                        {
                            if (absXCha > absYCha)
                            {
                                this.Left(movedbijou, true);
                            }
                            else
                            {
                                this.Up(movedbijou, true);
                            }
                        }
                    }
                    #endregion
                }
            }
        }

        private void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource != null && e.OriginalSource.GetType() == typeof(bijou))
            {
                bijou tempbijou = (bijou)e.OriginalSource;
                tempbijou.ReleaseMouseCapture();
            }
        }
        private void sbAll_Completed(object sender, EventArgs e)
        {
            Storyboard sb = sender as Storyboard;
            sb.Stop();
            AnimationIsPlaying = false;
        }
        #endregion

    }

#region 方向枚举
    public enum Direction
    {
        Up = 1,
        Down = 2,
        Left = 3,
        Right = 4
    }
#endregion
}
