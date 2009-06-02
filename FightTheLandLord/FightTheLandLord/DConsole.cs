using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightTheLandLord
{
    public static class DConsole
    {
        /// <summary>
        /// 记录自己最后一次出的牌组(已从大到小排序)
        /// </summary>
        public static PokerGroup leadPokers = new PokerGroup();
        public static PokerGroup LeftTempLeadedPoker;
        public static PokerGroup RightTempLeadedPoker;
        public static System.Windows.Forms.TextBox tb;
        public static System.Windows.Forms.Label lblClient1Name;
        public static System.Windows.Forms.Label lblClient2Name;
        public static Color backColor;
        public static Graphics g1, g2, gPlayer1LeadPoker, gPlayer2LeadPoker, gPlayer3LeadPoker;
        public static int leftCount;
        public static int rightCount;
        public static Server server;
        public static Client client;
        /// <summary>
        /// 自己是否有出牌权限
        /// </summary>
        public static bool haveOrder;
        /// <summary>
        /// 上轮出牌是否自己最大
        /// </summary>
        private static bool _isBiggest;
        public static string OtherClientName
        {
            get
            {
                return lblClient2Name.Text;
            }
            set
            {
                lblClient2Name.Text = value;
            }
        }
        public static string ServerName
        {
            get
            {
                return lblClient1Name.Text;
            }
            set
            {
                lblClient1Name.Text = value;
            }
        }
        //当自己的IsBiggest为true时,发送消息使其他玩家的IsBiggest为false,因为逻辑上IsBiggest只能有一个
        public static bool IsBiggest
        {
            get
            {
                return _isBiggest;
            }
            set
            {
                if (value)
                {
                    if (client != null)
                    {
                        client.SendDataForServer("IamIsBiggest");
                        _isBiggest = value;
                    }
                    if (server != null)
                    {
                        server.SendDataForClient("NoBiggest", 1);
                        server.SendDataForClient("NoBiggest", 2);
                        _isBiggest = value;
                    }
                }
                else
                {
                    _isBiggest = value;
                }
            }
        }

        /// <summary>
        /// 记录其他玩家出的牌组
        /// </summary>
        public static PokerGroups leadedPokerGroups = new PokerGroups();
        /// <summary>
        /// 验证所出牌组是否符合游戏规则
        /// </summary>
        public static bool IsRules(PokerGroup leadPokers) //判断所出牌组类型以及其是否符合规则
        {
            bool isRule = false;
            Player.sort(leadPokers);
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
                    if (IsSame(leadPokers,2))
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
                    if (IsSame(leadPokers,3))
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
                        if (IsSame(leadPokers, 3))
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
                                    leadPokers.type = PokerGroupType.三张相同;
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
            }
#if DEBUG
            Console.WriteLine("玩家出的牌:");
            foreach (Poker Poker in leadPokers)
            {
                Write(Poker.pokerColor.ToString() + Poker.pokerNum.ToString());
            }
#endif
            return isRule;
        }

        public static void Write(string str)
        {
            tb.Text += str + "\r\n";
            tb.SelectionStart = tb.Text.Length;
            tb.ScrollToCaret();
        }
        public static void PaintServer(int PokerCount)
        {
            g1.Clear(backColor);
            int x = 0;
            leftCount = PokerCount;
            for (int y = 0; y < PokerCount * 18; y += 18)
            {
                g1.FillRectangle(Brushes.Gray, x, y, 100, 18);
                g1.DrawRectangle(Pens.Black, x, y, 100, 18);
            }
        }
        /// <summary>
        /// 客户端显示服务器玩家剩余牌数
        /// </summary>
        public static void PaintServer()
        {
            PaintServer(leftCount);
        }
        /// <summary>
        /// 客户端用,显示其他客户端玩家剩余牌数
        /// </summary>
        public static void PaintClient()
        {
            PaintClient(rightCount);
        }
        /// <summary>
        /// 服务器玩家显示两个客户端的剩余牌数
        /// </summary>
        /// <param name="temp">该参数仅为与另外一个重载区别开来,无实际意义,请随便传送一个bool值</param>
        public static void PaintClient(bool temp)
        {
            PaintClient(leftCount, 1);
            PaintClient(rightCount, 2);
        }
        /// <summary>
        /// 客户端用,用于显示另外一个客户端的剩余牌数
        /// </summary>
        /// <param name="PokerCount">剩余牌数</param>
        public static void PaintClient(int PokerCount)
        {
            System.Threading.Thread.Sleep(100);
            g2.Clear(backColor);
            int x = 0;
            rightCount = PokerCount;
            for (int y = 0; y < PokerCount * 18; y += 18)
            {
                g2.FillRectangle(Brushes.Gray, x, y, 100, 18);
                g2.DrawRectangle(Pens.Black, x, y, 100, 18);
            }
        }
        /// <summary>
        /// 服务器玩家显示两个客户端剩余牌数
        /// </summary>
        /// <param name="PokerCount">剩余牌的张数</param>
        /// <param name="ClientNum">客户端的代号,只能填1和2</param>
        public static void PaintClient(int PokerCount,int ClientNum)
        {
            int x = 0;
                if (ClientNum == 1)
                {
                    g1.Clear(backColor);
                    leftCount = PokerCount;
                    for (int y = 0; y < leftCount * 18; y += 18)
                    {
                        g1.FillRectangle(Brushes.Gray, x, y, 100, 18);
                        g1.DrawRectangle(Pens.Black, x, y, 100, 18);
                    }
                }
                if (ClientNum == 2)
                {
                    g2.Clear(backColor);
                    rightCount = PokerCount;
                    for (int y = 0; y < rightCount * 18; y += 18)
                    {
                        g2.FillRectangle(Brushes.Gray, x, y, 100, 18);
                        g2.DrawRectangle(Pens.Black, x, y, 100, 18);
                    }
                }
        }

        public static void PaintPlayer1LeadPoker()
        {
            gPlayer1LeadPoker.Clear(backColor);
            for (int i = 0; i < leadPokers.Count; i++)
            {
                int x = i * 20;
                Rectangle rt = new Rectangle(x, 0, 50, 95);
                gPlayer1LeadPoker.FillRectangle(Brushes.White, rt);
                gPlayer1LeadPoker.DrawRectangle(Pens.Black, rt);
                gPlayer1LeadPoker.DrawString(leadPokers[i].pokerNum.ToString(), new Font("宋体", 12), Brushes.Red, x + 5, 5);
            }
        }
        public static void PaintPlayer2LeadPoker()
        {
            if (LeftTempLeadedPoker != null)
            {
                PaintPlayer2LeadPoker(LeftTempLeadedPoker);
            }
        }
        public static void PaintPlayer3LeadPoker()
        {
            if (RightTempLeadedPoker != null)
            {
                PaintPlayer3LeadPoker(RightTempLeadedPoker);
            }
        }

        public static void PaintPlayer2LeadPoker(PokerGroup pg)
        {
            LeftTempLeadedPoker = pg;
            gPlayer2LeadPoker.Clear(backColor);
            for (int i = 0; i < pg.Count; i++)
            {
                int y = i * 20;
                Rectangle rt = new Rectangle(0, y, 95, 50);
                gPlayer2LeadPoker.FillRectangle(Brushes.White, rt);
                gPlayer2LeadPoker.DrawRectangle(Pens.Black, rt);
                gPlayer2LeadPoker.DrawString(pg[i].pokerNum.ToString(), new Font("宋体", 12), Brushes.Red, 40, y + 5);
            }
        }
        public static void PaintPlayer3LeadPoker(PokerGroup pg)
        {
            RightTempLeadedPoker = pg;
            gPlayer3LeadPoker.Clear(backColor);
            for (int i = 0; i < pg.Count; i++)
            {
                int y = i * 20;
                Rectangle rt = new Rectangle(0, y, 95, 50);
                gPlayer3LeadPoker.FillRectangle(Brushes.White, rt);
                gPlayer3LeadPoker.DrawRectangle(Pens.Black, rt);
                gPlayer3LeadPoker.DrawString(pg[i].pokerNum.ToString(), new Font("宋体", 12), Brushes.Red, 40, y + 5);
            }
        }

        public static void WriteLeadedPokers()
        {
            foreach (Poker poker in leadedPokerGroups[leadedPokerGroups.Count - 1])
            {
                Write(poker.pokerColor.ToString() + poker.pokerNum.ToString());
            }
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
                if (PG[i] == PG[i+1])
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
        /// 判断牌组是否为连续三张牌
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连续三张牌</returns>
        public static bool IsThreeLinkPokers(PokerGroup PG) //判断三张牌方法为判断两两相邻的牌,如果两两相邻的牌相同,则count自加1.最后根据count的值判断牌的类型为多少个连续三张
        {
            if (IsLinkPair(PG))  //由于这种特性和连对相同,但是如果牌组为连对的话就不可能为连续三张牌,所以这里判断一下
            {
                return false;
            }
            bool IsThreeLinkPokers = false;
            int count = 0;
            foreach (Poker poker in PG)//不能包含2、小王、大王
            {
                if (poker == PokerNum.P2 || poker == PokerNum.小王 || poker == PokerNum.大王)
                {
                    IsThreeLinkPokers = false;
                    return IsThreeLinkPokers;
                }
            }
            for (int i = 0; i < PG.Count - 1; i++)
            {
                if (PG[i] == PG[i + 1])
                {
                    count++;
                }

                //if (PG[i] == PG[i + 1] && PG[i + 1] == PG[i + 2] && PG[i + 2].pokerNum - 1 == PG[i + 3].pokerNum && PG[i + 3] == PG[i + 4] && PG[i + 4] == PG[i + 5])
                //{
                //    IsThreeLinkPokers = true;
                //}
                //else
                //{
                //    IsThreeLinkPokers = false;
                //    break;
                //}
            }
            if (count >= 4 && count <= 11)
            {
                IsThreeLinkPokers = true;
            }
            return IsThreeLinkPokers;

        }
        /// <summary>
        /// 对飞机和飞机带翅膀进行排序,把飞机放在前面,翅膀放在后面.
        /// </summary>
        /// <param name="PG">牌组</param>
        /// <returns>是否为连续三张牌</returns>
        public static PokerGroup SameSort(PokerGroup PG)  //还要写排除把炸弹当飞机出的情况.
        {
            Poker tempPoker1 = PG[0];
            Poker tempPoker2 = PG[1];
            bool FindedThree = false;
            PokerGroup tempPokerGroup = new PokerGroup();
            int count = 0;
            for (int i = 2; i < PG.Count; i++)
            {
                if (PG[i] == tempPoker1 && PG[i] == tempPoker2)
                {
                    tempPokerGroup.Add(PG[i]);
                    FindedThree = true;
                }
                else
                {
                    if (!FindedThree)
                    {
                        count = i - 1;
                    }
                }
                tempPoker1 = PG[i - 1];
                tempPoker2 = PG[i];
            }
            foreach (Poker tempPoker in tempPokerGroup)
            {
                Poker changePoker;
                for (int j = 0; j < count; j++)
                {
                    for (int i = 0; i < PG.Count; i++)
                    {
                        if (PG[i] == tempPoker)
                        {
                            changePoker = PG[i - count];
                            PG[i - count] = PG[i];
                            PG[i] = changePoker;
                        }
                    }
                }
            }
            return PG;
        }
    }
}
