using System;
using System.Collections.Generic;
using System.Text;

namespace FightTheLandLord
{
    public static class DConsole
    {
        public static PokerGroup orderingPokers = new PokerGroup();
        public static System.Windows.Forms.TextBox tb;

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

        public static void WriteLeadedPokers()
        {
            foreach (PokerGroup onePokers in leadedPokers)
            {
                Write("已接收到的牌组:");
                foreach (Poker onePoker in onePokers)
                {
                    Write(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
                }
            }
        }
    }
}
