using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightTheLandLord
{
    public static class DConsole
    {
        public static PokerGroup orderingPokers = new PokerGroup();
        public static System.Windows.Forms.TextBox tb;
        public static Color backColor;
        public static Graphics g1;
        public static Graphics g2;
        public static int leftCount;
        public static int rightCount;

        /// <summary>
        /// 已出的牌组的集合
        /// </summary>
        public static List<PokerGroup> leadedPokers = new List<PokerGroup>();
        /// <summary>
        /// 验证所出牌组是否符合游戏规则
        /// </summary>
        public static bool IsRules(PokerGroup leadPokers)
        {
            bool isRule = false;
            orderingPokers.Clear();
            Player.sort(leadPokers, orderingPokers);
            switch (orderingPokers.Count)
            {
                case 0:
                    isRule = false;
                    break;
                case 1:
                    isRule = true;
                    break;
                case 2:
                    if (orderingPokers[0].pokerNum == orderingPokers[1].pokerNum)
                    {
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
                case 3:
                    if (orderingPokers[0].pokerNum == orderingPokers[1].pokerNum && orderingPokers[1].pokerNum == orderingPokers[2].pokerNum)
                    {
                        isRule = true;
                    }
                    else
                    {
                        isRule = false;
                    }
                    break;
            }
            //if (isRule)
            //{
            //    if (leadedPokers.Count != 0)
            //    {
            //        if (leadedPokers[leadedPokers.Count] != null)
            //        {
            //            if (leadedPokers[leadedPokers.Count].Count == orderingPokers.Count)
            //            {
            //                if (leadedPokers[leadedPokers.Count][0].pokerNum < orderingPokers[0].pokerNum)
            //                {
            //                    isRule = true;
            //                }
            //                else
            //                {
            //                    isRule = false;
            //                }
            //            }
            //            else
            //            {
            //                isRule = false;
            //            }
            //        }
            //    }
            //    else
            //    {
            //        return true;
            //    }
            //}
#if DEBUG
            Console.WriteLine("玩家出的牌:");
            foreach (Poker Poker in orderingPokers)
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

        public static void WriteLeadedPokers()
        {
            foreach (Poker poker in leadedPokers[leadedPokers.Count - 1])
            {
                Write("对方出的牌");
                Write(poker.pokerColor.ToString() + poker.pokerNum.ToString());
            }
        }
    }
}
