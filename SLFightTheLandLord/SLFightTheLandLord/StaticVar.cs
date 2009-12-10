using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Threading;

namespace SLFightTheLandLord
{
    public class StaticVar
    {
        /// <summary>
        /// 是否正在拖动(批量选牌)
        /// </summary>
        public static bool IsDragSelect { get; set; }

        /// <summary>
        /// 自己的牌
        /// </summary>
        public static PokerGroup MyPoker { get; set; }
        
        /// <summary>
        /// 所有的牌
        /// </summary>
        public static PokerGroup AllPoker { get; set; }
        
        /// <summary>
        /// 自己上次出的牌
        /// </summary>
        public static PokerGroup LastLeadedPG = new PokerGroup();

        /// <summary>
        /// 批量选中牌时鼠标的起始点
        /// </summary>
        public static Point MyPokerClickPoint { get; set; }

        /// <summary>
        /// 选中的牌
        /// </summary>
        public static PokerGroup SelectedPokers = new PokerGroup();

        /// <summary>
        /// 被取消选中的牌
        /// </summary>
        public static PokerGroup UnSelectedPokers = new PokerGroup();

        /// <summary>
        /// 牌与牌之间的距离
        /// </summary>
        public static int PokerDistance = 25;

        /// <summary>
        /// 牌的Canvas.Top的值
        /// </summary>
        public static int PokerTop = 60;

        /// <summary>
        /// 发牌是否完成
        /// </summary>
        public static bool DealComplete { get; set; }

        /// <summary>
        /// 左边玩家牌图像集合
        /// </summary>
        public static List<Image> LeftPlayerPokerImages { get; set; }

        /// <summary>
        /// 右边玩家牌图像集合
        /// </summary>
        public static List<Image> RightPlayerPokerImages { get; set; }

        /// <summary>
        /// 三张地主牌图像集合
        /// </summary>
        public static List<Image> LandLordPokerImages { get; set; }

        /// <summary>
        /// 左边玩家出的牌组
        /// </summary>
        public static PokerGroup LeftPlayerLeadedPokers { get; set; }

        /// <summary>
        /// 右边玩家出的牌组
        /// </summary>
        public static PokerGroup RightPlayerLeadedPokers { get; set; }

        /// <summary>
        /// 地主牌
        /// </summary>
        public static PokerGroup TheLandLordPokers { get; set; }

        /// <summary>
        /// 显示消息
        /// </summary>
        public static Action<string> ShowMessage { get; set; }

        public static Action PassMyOneSecond { get; set; }
        public static Action PassLeftPlayerSecond { get; set; }
        public static Action PassRightPlayerSecond { get; set; }

        public static Action<UIElement> AddUIElement { get; set; }

        /// <summary>
        /// 超时计时器
        /// </summary>
        public static DispatcherTimer TimeoutTimer { get; set; }

        /// <summary>
        /// 超时时间
        /// </summary>
        public static int TimeoutTime { get; set; }

        /// <summary>
        /// 倒计时时间
        /// </summary>
        public static int PassTime { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public static int MyID { get; set; }

        /// <summary>
        /// 左边玩家ID
        /// </summary>
        public static int LeftPlayerID { get; set; }

        /// <summary>
        /// 右边玩家ID
        /// </summary>
        public static int RightPlayerID { get; set; }

        /// <summary>
        /// 当前出牌玩家编号
        /// </summary>
        public static int CurrentPlayer { get; set; }

        /// <summary>
        /// 隐藏自己的计时器
        /// </summary>
        public static Action HideMyTimer { get; set; }

        /// <summary>
        /// 显示自己的计时器
        /// </summary>
        public static Action ShowMyTimer { get; set; }

        /// <summary>
        /// 出牌
        /// </summary>
        /// <param name="leadPG">出出去的牌组</param>
        public static void LeadPoker(PokerGroup leadPG)
        {
            #region 出牌的UI部分
            foreach (var onePoker in LastLeadedPG)  // 消除上次出牌在界面上的显示
            {
                Canvas canvasMyPoker = (Canvas)onePoker.PokerImage.Parent;
                canvasMyPoker.Children.Remove(onePoker.PokerImage);
            }
            LastLeadedPG.Clear();
            int i = 0;
            var distance = PokerDistance - 10;
            var xTo = (400 - (leadPG.Count - 1) * distance + leadPG[0].PokerImage.ActualWidth) / 2; //保持出出去的牌组在中间
            int zindex = 10;
            foreach (var onePoker in leadPG)
            {
                zindex++;
                Canvas.SetZIndex(onePoker.PokerImage, zindex);
                MyPoker.Remove(onePoker); //从自己牌组中移除
                LastLeadedPG.Add(onePoker); //添加到上次出牌列表中
                PlayAnimation(xTo + i * (distance), -110, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), onePoker.PokerImage, onePoker.PokerImage, "(Canvas.Left)", "(Canvas.Top)");
                i++;
            }

            var myPokerXTo = (400 - (MyPoker.Count - 1) * PokerDistance + leadPG[0].PokerImage.ActualWidth) / 2; //保持自己的牌组在中间
            int j = 0;
            foreach (var onePoker in MyPoker) 
            {
                PlayAnimation(myPokerXTo + j * PokerDistance, TimeSpan.FromMilliseconds(150), onePoker.PokerImage, "(Canvas.Left)");
                j++;
            }
            #endregion
        }
        /// <summary>
        /// 出牌失败
        /// </summary>
        public static void LeadFailed()
        {
            //todo 出牌失败信息
            ShowMessage("您出的牌不符合规则喔！");
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="to">目标属性的目标值</param>
        /// <param name="duration">动画持续时间</param>
        /// <param name="obj">动画目标</param>
        /// <param name="targetProperty">动画目标属性</param>
        public static void PlayAnimation(double to, Duration duration, DependencyObject obj, string targetProperty)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = duration;
            da.To = to;
            Storyboard.SetTarget(da, obj);
            Storyboard.SetTargetProperty(da, new PropertyPath(targetProperty));
            sb.Children.Add(da);
            sb.Begin();
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="to">目标属性的目标值</param>
        /// <param name="duration">动画持续时间</param>
        /// <param name="obj">动画目标</param>
        /// <param name="targetProperty">动画目标属性</param>
        /// <param name="ev">动画播放完后触发的事件</param>
        public static void PlayAnimation(double to, Duration duration, DependencyObject obj, string targetProperty, EventHandler ev)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = duration;
            da.To = to;
            Storyboard.SetTarget(da, obj);
            Storyboard.SetTargetProperty(da, new PropertyPath(targetProperty));
            sb.Children.Add(da);
            sb.Completed += ev;
            sb.Begin();
        }

        /// <summary>
        /// 播放含两个DoubleAnimation的动画
        /// </summary>
        /// <param name="to1">第一个目标属性的目标值</param>
        /// <param name="to2">第二个目标属性的目标值</param>
        /// <param name="duration1">第一个动画的持续时间</param>
        /// <param name="duration2">第二个动画的持续时间</param>
        /// <param name="obj1">第一个动画目标</param>
        /// <param name="obj2">第二个动画目标</param>
        /// <param name="targetProperty1">第一个动画的目标属性</param>
        /// <param name="targetProperty2">第二个动画的目标属性</param>
        public static void PlayAnimation(double to1, double to2, Duration duration1, Duration duration2, DependencyObject obj1, DependencyObject obj2, string targetProperty1, string targetProperty2)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da1 = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();
            Storyboard.SetTarget(da1, obj1);
            Storyboard.SetTargetProperty(da1, new PropertyPath(targetProperty1));
            Storyboard.SetTarget(da2, obj2);
            Storyboard.SetTargetProperty(da2, new PropertyPath(targetProperty2));
            da1.Duration = duration1;
            da2.Duration = duration2;
            da1.To = to1;
            da2.To = to2;
            sb.Children.Add(da1);
            sb.Children.Add(da2);
            sb.Begin();
        }

        /// <summary>
        /// 播放含两个DoubleAnimation的动画
        /// </summary>
        /// <param name="to1">第一个目标属性的目标值</param>
        /// <param name="to2">第二个目标属性的目标值</param>
        /// <param name="duration1">第一个动画的持续时间</param>
        /// <param name="duration2">第二个动画的持续时间</param>
        /// <param name="obj1">第一个动画目标</param>
        /// <param name="obj2">第二个动画目标</param>
        /// <param name="targetProperty1">第一个动画的目标属性</param>
        /// <param name="targetProperty2">第二个动画的目标属性</param>
        /// <param name="ev">Storyboard播放完成后的动作</param>
        public static void PlayAnimation(double to1, double to2, Duration duration1, Duration duration2, DependencyObject obj1, DependencyObject obj2, string targetProperty1, string targetProperty2, EventHandler ev)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da1 = new DoubleAnimation();
            DoubleAnimation da2 = new DoubleAnimation();
            Storyboard.SetTarget(da1, obj1);
            Storyboard.SetTargetProperty(da1, new PropertyPath(targetProperty1));
            Storyboard.SetTarget(da2, obj2);
            Storyboard.SetTargetProperty(da2, new PropertyPath(targetProperty2));
            da1.Duration = duration1;
            da2.Duration = duration2;
            da1.To = to1;
            da2.To = to2;
            sb.Children.Add(da1);
            sb.Children.Add(da2);
            sb.Completed += ev;
            sb.Begin();
        }

        /// <summary>
        /// 播放发牌动画
        /// </summary>
        public static void PlayDealAnimation()
        {
            #region 发自己牌的动画
            int i = 0;
            MyPoker[i].PokerImage.Visibility = Visibility.Visible;
            EventHandler ev = null;

            ev = (object sender1, EventArgs ea1) =>
            {
                i++;
                if (i < MyPoker.Count)
                {
                    MyPoker[i].PokerImage.Visibility = Visibility.Visible;
                    var to = i * StaticVar.PokerDistance;
                    PlayAnimation(to, PokerTop, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), MyPoker[i].PokerImage, MyPoker[i].PokerImage,
                        "(Canvas.Left)", "(Canvas.Top)", ev);
                }
                else
                {
                    DealComplete = true;
                }
             };
            PlayAnimation(0, PokerTop, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), MyPoker[i].PokerImage, MyPoker[i].PokerImage, 
                "(Canvas.Left)", "(Canvas.Top)", ev);
            #endregion

            #region 发左边玩家牌的动画
            int lefti = 0;
            LeftPlayerPokerImages[lefti].Visibility = Visibility.Visible;
            EventHandler leftPlayerEV = null;
            leftPlayerEV = (object sender1, EventArgs ea1) =>
                {
                    lefti++;
                    if (lefti < LeftPlayerPokerImages.Count)
                    {
                        LeftPlayerPokerImages[lefti].Visibility = Visibility.Visible;
                        var to = lefti * (StaticVar.PokerDistance);
                        PlayAnimation(0, to, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), LeftPlayerPokerImages[lefti], LeftPlayerPokerImages[lefti],
                            "(Canvas.Left)", "(Canvas.Top)", leftPlayerEV);
                    }
                };

            PlayAnimation(0, 0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), LeftPlayerPokerImages[lefti], LeftPlayerPokerImages[lefti],
                "(Canvas.Left)", "(Canvas.Top)", leftPlayerEV);
            #endregion

            #region 发右边玩家牌的动画
            int righti = 0;
            RightPlayerPokerImages[righti].Visibility = Visibility.Visible;
            EventHandler rightPlayerEV = null;
            rightPlayerEV = (object sender1, EventArgs ea1) =>
            {
                righti++;
                if (righti < RightPlayerPokerImages.Count)
                {
                    RightPlayerPokerImages[righti].Visibility = Visibility.Visible;
                    var a = RightPlayerPokerImages[righti].ActualWidth;
                    var to = righti * (StaticVar.PokerDistance);
                    PlayAnimation(0, to, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), RightPlayerPokerImages[righti], RightPlayerPokerImages[righti],
                        "(Canvas.Left)", "(Canvas.Top)", rightPlayerEV);
                }
            };

            PlayAnimation(0, 0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), RightPlayerPokerImages[righti], RightPlayerPokerImages[righti],
                "(Canvas.Left)", "(Canvas.Top)", rightPlayerEV);
            #endregion

            #region 发地主牌的动画
            int landLord = 0;
            LandLordPokerImages[landLord].Visibility = Visibility.Visible;
            EventHandler landLordEV = null;
            landLordEV = (object sender1, EventArgs ea1) =>
                {
                    landLord++;
                    if (landLord < LandLordPokerImages.Count)
                    {
                        LandLordPokerImages[landLord].Visibility = Visibility.Visible;
                        var to = landLord * LandLordPokerImages[landLord].ActualWidth;
                        PlayAnimation(to, 0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), LandLordPokerImages[landLord], LandLordPokerImages[landLord],
                            "(Canvas.Left)", "(Canvas.Top)", landLordEV);
                    }
                };
            PlayAnimation(0, 0, TimeSpan.FromMilliseconds(100), TimeSpan.FromMilliseconds(100), LandLordPokerImages[landLord], LandLordPokerImages[landLord],
                "(Canvas.Left)", "(Canvas.Top)", landLordEV);
            #endregion
        }

        /// <summary>
        /// 验证所出牌组是否符合游戏规则
        /// </summary>
        public static bool IsRules(PokerGroup leadPokers) //判断所出牌组类型以及其是否符合规则
        {
            bool isRule = false;
            Sort(leadPokers);
            switch (leadPokers.Count)
            {
                case 0:
                    isRule = false;
                    break;
                case 1:
                    isRule = true;
                    leadPokers.type = PokerGroupType.单张;
                    break;
                case 2:
                    if (IsSame(leadPokers, 2))
                    {
                        isRule = true;
                        leadPokers.type = PokerGroupType.对子;
                    }
                    else
                    {
                        if (leadPokers[0] == PokerNum.大王 && leadPokers[1] == PokerNum.小王)
                        {
                            leadPokers.type = PokerGroupType.双王;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 3:
                    if (IsSame(leadPokers, 3))
                    {
                        leadPokers.type = PokerGroupType.三张相同;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 4:
                    if (IsSame(leadPokers, 4))
                    {
                        leadPokers.type = PokerGroupType.炸弹;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.三带一;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 5:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.五张顺子;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 6:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.六张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.三连对;
                            isRule = true;
                        }
                        else
                        {
                            if (IsSame(leadPokers, 4))
                            {
                                leadPokers.type = PokerGroupType.四带二;
                                isRule = true;
                            }
                            else
                            {
                                if (IsThreeLinkPokers(leadPokers))
                                {
                                    leadPokers.type = PokerGroupType.二连飞机;
                                    isRule = true;
                                }
                                else
                                {
                                    isRule = false;
                                }
                            }
                        }
                    }
                    break;
                case 7:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.七张顺子;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 8:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.八张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.四连对;
                            isRule = true;
                        }
                        else
                        {
                            if (IsThreeLinkPokers(leadPokers))
                            {
                                leadPokers.type = PokerGroupType.飞机带翅膀;
                                isRule = true;
                            }
                            else
                            {
                                isRule = false;
                            }
                        }
                    }
                    break;
                case 9:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.九张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.三连飞机;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 10:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.五连对;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 11:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十一张顺子;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 12:
                    if (IsStraight(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十二张顺子;
                        isRule = true;
                    }
                    else
                    {
                        if (IsLinkPair(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.六连对;
                            isRule = true;
                        }
                        else
                        {
                            if (IsThreeLinkPokers(leadPokers))
                            {
                                //12有三连飞机带翅膀和四连飞机两种情况,所以在IsThreeLinkPokers中做了特殊处理,此处不用给type赋值.
                                isRule = true;
                            }
                            else
                            {
                                isRule = false;
                            }
                        }
                    }
                    break;
                case 13:
                    isRule = false;
                    break;
                case 14:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.七连对;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 15:
                    if (IsThreeLinkPokers(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.五连飞机;
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 16:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.八连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.四连飞机带翅膀;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 17:
                    isRule = false;
                    break;
                case 18:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.六连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.六连飞机;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
                case 19:
                    isRule = false;
                    break;
                case 20:
                    if (IsLinkPair(leadPokers))
                    {
                        leadPokers.type = PokerGroupType.十连对;
                        isRule = true;
                    }
                    else
                    {
                        if (IsThreeLinkPokers(leadPokers))
                        {
                            leadPokers.type = PokerGroupType.五连飞机带翅膀;
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    break;
            }
            return isRule;
        }

        /// <summary>
        /// 判断一个牌组指定数量相邻的牌是否两两相同
        /// </summary>
        /// <param name="PG">牌组对象</param>
        /// <param name="amount">指定数量的相邻牌组</param>
        /// <returns>指定数量的相邻牌是否两两相同</returns>
        public static bool IsSame(PokerGroup PG, int amount)
        {
            bool IsSame1 = false;
            bool IsSame2 = false;
            for (int i = 0; i < amount - 1; i++) //从大到小比较相邻牌是否相同
            {
                if (PG[i] == PG[i + 1])
                {
                    IsSame1 = true;
                }
                else
                {
                    IsSame1 = false;
                    break;
                }
            }
            for (int i = PG.Count - 1; i > PG.Count - amount; i--)  //从小到大比较相邻牌是否相同
            {
                if (PG[i] == PG[i - 1])
                {
                    IsSame2 = true;
                }
                else
                {
                    IsSame2 = false;
                    break;
                }
            }
            if (IsSame1 || IsSame2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 判断牌组是否为顺子
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为顺子</returns>
        public static bool IsStraight(PokerGroup PG)
        {
            bool IsStraight = false;
            foreach (Poker poker in PG)//不能包含2、小王、大王
            {
                if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
                {
                    IsStraight = false;
                    return IsStraight;
                }
            }
            for (int i = 0; i < PG.Count - 1; i++)
            {
                if (PG[i].pokerNum - 1 == PG[i + 1].pokerNum)
                {
                    IsStraight = true;
                }
                else
                {
                    IsStraight = false;
                    break;
                }
            }
            return IsStraight;
        }
        /// <summary>
        /// 判断牌组是否为连对
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连对</returns>
        public static bool IsLinkPair(PokerGroup PG)
        {
            bool IsLinkPair = false;
            foreach (Poker poker in PG) //不能包含2、小王、大王
            {
                if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
                {
                    IsLinkPair = false;
                    return IsLinkPair;
                }
            }
            for (int i = 0; i < PG.Count - 2; i += 2)  //首先比较是否都为对子，再比较第一个对子的点数-1是否等于第二个对子，最后检察最小的两个是否为对子（这里的for循环无法检测到最小的两个，所以需要拿出来单独检查）
            {
                if (PG[i] == PG[i + 1] && PG[i].pokerNum - 1 == PG[i + 2].pokerNum && PG[i + 2] == PG[i + 3])
                {
                    IsLinkPair = true;
                }
                else
                {
                    IsLinkPair = false;
                    break;
                }
            }
            return IsLinkPair;
        }
        /// <summary>
        /// 判断牌组是否为连续三张牌,飞机,飞机带翅膀
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连续三张牌</returns>
        public static bool IsThreeLinkPokers(PokerGroup PG) //判断三张牌方法为判断两两相邻的牌,如果两两相邻的牌相同,则count自加1.最后根据count的值判断牌的类型为多少个连续三张
        {
            bool IsThreeLinkPokers = false;
            int HowMuchLinkThree = 0;  //飞机的数量
            PG = SameThreeSort(PG); //排序,把飞机放在前面
            for (int i = 2; i < PG.Count; i++)  //得到牌组中有几个飞机
            {
                if (PG[i] == PG[i - 1] && PG[i] == PG[i - 2])
                {
                    HowMuchLinkThree++;
                }
            }
            if (HowMuchLinkThree > 0)  //当牌组里面有三个时
            {
                if (HowMuchLinkThree > 1)  //当牌组为飞机时
                {
                    for (int i = 0; i < HowMuchLinkThree * 3 - 3; i += 3) //判断飞机之间的点数是否相差1
                    {
                        if (PG[i] != PokerNum.P2 && PG[i].pokerNum - 1 == PG[i + 3].pokerNum) //2点不能当飞机出
                        {
                            IsThreeLinkPokers = true;
                        }
                        else
                        {
                            IsThreeLinkPokers = false;
                            break;
                        }
                    }
                }
                else
                {
                    IsThreeLinkPokers = true; //牌组为普通三个,直接返回true
                }
            }
            else
            {
                IsThreeLinkPokers = false;
            }
            if (HowMuchLinkThree == 4)
            {
                PG.type = PokerGroupType.四连飞机;
            }
            if (HowMuchLinkThree == 3 && PG.Count == 12)
            {
                PG.type = PokerGroupType.三连飞机带翅膀;
            }
            return IsThreeLinkPokers;

        }
        /// <summary>
        /// 对飞机和飞机带翅膀进行排序,把飞机放在前面,翅膀放在后面.
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连续三张牌</returns>
        public static PokerGroup SameThreeSort(PokerGroup PG)
        {
            Poker FourPoker = null;  //如果把4张当三张出并且带4张的另外一张,就需要特殊处理,这里记录出现这种情况的牌的点数.
            bool FindedThree = false;  //已找到三张相同的牌
            PokerGroup tempPokerGroup = new PokerGroup();  //记录三张相同的牌
            int count = 0; //记录在连续三张牌前面的翅膀的张数
            int Four = 0; // 记录是否连续出现三三相同,如果出现这种情况则表明出现把4张牌(炸弹)当中的三张和其他牌配成飞机带翅膀,并且翅膀中有炸弹牌的点数.
            // 比如有如下牌组: 998887777666 玩家要出的牌实际上应该为 888777666带997,但是经过从大到小的排序后变成了998887777666 一不美观,二不容易比较.
            for (int i = 2; i < PG.Count; i++)  //直接从2开始循环,因为PG[0],PG[1]的引用已经存储在其他变量中,直接比较即可
            {
                if (PG[i] == PG[i - 2] && PG[i] == PG[i - 1])// 比较PG[i]与PG[i-1],PG[i]与PG[i-2]是否同时相等,如果相等则说明这是三张相同牌
                {
                    if (Four >= 1) //默认的Four为0,所以第一次运行时这里为false,直接执行else
                    //一旦连续出现两个三三相等,就会执行这里的if
                    {
                        FourPoker = PG[i]; //当找到四张牌时,记录下4张牌的点数
                        Poker changePoker;
                        for (int k = i; k > 0; k--) //把四张牌中的一张移动到最前面.
                        {
                            changePoker = PG[k];
                            PG[k] = PG[k - 1];
                            PG[k - 1] = changePoker;
                        }
                        count++; //由于此时已经找到三张牌,下面为count赋值的程序不会执行,所以这里要手动+1
                    }
                    else
                    {
                        Four++; //记录本次循环,因为本次循环找到了三三相等的牌,如果连续两次找到三三相等的牌则说明找到四张牌(炸弹)
                        tempPokerGroup.Add(PG[i]); //把本次循环的PG[i]记录下来,即记录下三张牌的点数
                    }
                    FindedThree = true; //标记已找到三张牌
                }
                else
                {
                    Four = 0; //没有找到时,连续找到三张牌的标志Four归零
                    if (!FindedThree) //只有没有找到三张牌时才让count增加.如果已经找到三张牌,则不再为count赋值.
                    {
                        count = i - 1;
                    }
                }
            }
            foreach (Poker tempPoker in tempPokerGroup)  //迭代所有的三张牌点数
            {
                Poker changePoker;  //临时交换Poker
                for (int i = 0; i < PG.Count; i++)  //把所有的三张牌往前移动
                {
                    if (PG[i] == tempPoker)  //当PG[i]等于三张牌的点数时
                    {
                        if (PG[i] == FourPoker) //由于上面已经把4张牌中的一张放到的最前面,这张牌也会与tempPoker相匹配所以这里进行处理
                        // 当第一次遇到四张牌的点数时,把记录四张牌的FourPoker赋值为null,并中断本次循环.由于FourPoker已经为Null,所以下次再次遇到四张牌的点数时会按照正常情况执行.
                        {
                            FourPoker = null;
                            continue;
                        }
                        changePoker = PG[i - count]; //todo 出连炸此处会报错
                        PG[i - count] = PG[i];
                        PG[i] = changePoker;
                    }
                }
            }
            return PG;
        }

        /// <summary>
        /// 给牌组排序
        /// </summary>
        /// <param name="PG">要排序的牌组</param>
        public static void Sort(PokerGroup PG)
        {
            PG.Sort(Compare);
        }

        private static int Compare(Poker p1, Poker p2)
        {
            if (p1.pokerNum > p2.pokerNum)
                return -1;
            else if (p1.pokerNum < p2.pokerNum)
                return 1;
            return 0;
        }

        public static void PlayReadyAnimation(int ID)
        {
            int X = 0, Y = 0;
            if (ID == MyID)
            {
                X = 345;
                Y = 390;
            }
            else if (ID == LeftPlayerID)
            {
                X = 155;
                Y = 270;
            }
            else if (ID == RightPlayerID)
            {
                X = 545;
                Y = 270;
            }
            var readyContorl = new Ready();
            Canvas.SetLeft(readyContorl, X);
            Canvas.SetTop(readyContorl, Y);
            AddUIElement(readyContorl);
            readyContorl.StartAnimation();
        }

        public static void InitTimeoutTimer()
        {
            TimeoutTimer = new DispatcherTimer();
            TimeoutTimer.Interval = TimeSpan.FromSeconds(1);
            TimeoutTimer.Tick += new EventHandler(TimeoutTimer_Tick);
        }

        static void TimeoutTimer_Tick(object sender, EventArgs e)
        {
            if (--PassTime == 0)
            {
                TimeoutTimer.Stop();
                HideMyTimer();

                //todo 超时后
            }
            else
            {
                PassMyOneSecond();
            }
            #region 废弃
            //if (--PassTime == 0)
            //{
            //    PassTime = TimeoutTime;
            //    if (Number == CurrentPlayer)
            //    {
            //        //todo 自己超时 不要
            //    }
            //    else
            //    {

            //    }
            //}
            //else
            //{
            //    if (Number == CurrentPlayer)
            //    {

            //    }
            //    else
            //    {
            //        switch (Number)
            //        {
            //            case 1:
            //                if (CurrentPlayer == 3)
            //                    PassLeftPlayerSecond();
            //                else
            //                    PassRightPlayerSecond();
            //                break;
            //            case 2:
            //                if (CurrentPlayer == 1)
            //                    PassLeftPlayerSecond();
            //                else
            //                    PassRightPlayerSecond();
            //                break;
            //            case 3:
            //                if (CurrentPlayer == 2)
            //                    PassLeftPlayerSecond();
            //                else
            //                    PassRightPlayerSecond(); //todo 计时器逻辑
            //                break;
            //            default:
            //                break;
            //        }
            //    }

            //}
            #endregion
        }
    }
}
