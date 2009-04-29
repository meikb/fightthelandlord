using System;
using System.Collections.Generic;
using System.Text;

namespace FightTheLandLord
{
    public static class Rules
    {
        public static List<Poker> orderingPokers = new List<Poker>();

        /// <summary>
        /// 已出的牌组的集合
        /// </summary>
        public static List<List<Poker>> leadedPokers = new List<List<Poker>>();
        /// <summary>
        /// 验证所出牌组是否符合游戏规则
        /// </summary>
        public static bool IsRules(List<Poker> leadPokers)
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
            if (isRule)
            {
                if (leadedPokers[leadedPokers.Count] != null)
                {
                    if (leadedPokers[leadedPokers.Count].Count == orderingPokers.Count)
                    {
                        if (leadedPokers[leadedPokers.Count][0].pokerNum < orderingPokers[0].pokerNum)
                        {
                            isRule = true;
                        }
                        else
                        {
                            isRule = false;
                        }
                    }
                    else
                    {
                        isRule = false;
                    }
                }
            }
#if DEBUG
            Console.WriteLine("玩家出的牌:");
            foreach (Poker Poker in orderingPokers)
            {
                Console.WriteLine(Poker.pokerColor.ToString() + Poker.pokerNum.ToString());
            }
#endif
            return isRule;
        }
    }
}
