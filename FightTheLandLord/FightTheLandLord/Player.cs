using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace FightTheLandLord
{
    public class Player
    {
        private List<Poker> _pokers = new List<Poker>();
        public List<Poker> newPokers = new List<Poker>();
        private bool _isLandLord;

        public List<Poker> pokers
        {
            get
            {
                return this._pokers;
            }
            set
            {
                this._pokers = value;
            }
        }
        public bool isLandLord
        {
            get
            {
                return _isLandLord;
            }
            set
            {
                this._isLandLord = value;
            }
        }


        /// <summary>
        /// 把牌从大到小重新排序
        /// </summary>
        public void sort()  //自写从大到小排序算法
        {
            for (int j = 0; j < 17; j++) //循环17次
            {
                Poker bestBigPoker = null; //目前this.pokers里最大的牌
                for (int i = 0; i < this.pokers.Count; i++)  //找出目前this.pokers里最大的牌存在bestBigPoker里面
                {
                    if (bestBigPoker == null)
                    {
                        bestBigPoker = this.pokers[i];
                    }
                    if (this.pokers[i].pokerNum > bestBigPoker.pokerNum)
                    {
                        bestBigPoker = this.pokers[i];
                    }
                }
                this.pokers.Remove(bestBigPoker); //从this.pokers里删除最大的牌
                this.newPokers.Add(bestBigPoker); //把这张最大的牌添加到一个新集合
            }
#if DEBUG
            Console.WriteLine("排序后玩家一的牌");
            foreach (Poker onePoker in this.newPokers)
            {
                Console.WriteLine(onePoker.pokerNum.ToString()+onePoker.pokerColor.ToString());
            }
#endif
        }

        /// <summary>
        /// 获取扑克牌下标,检测是否符合游戏规则,如果符合则出牌,否则返回flase
        /// </summary>
        public bool lead(int[] inargs)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 把牌从大到小从左至右绘制到容器上
        /// </summary>
        public void Paint()
        {
            throw new System.NotImplementedException();
        }
    }
}
