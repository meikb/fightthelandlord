using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;

namespace FightTheLandLord
{
    public class Player
    {
        private List<Poker> _pokers = new List<Poker>();
        private List<Poker> _newPokers = new List<Poker>();
        private Graphics _g;
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
        public List<Poker> newPokers
        {
            get
            {
                return this._newPokers;
            }
            set
            {
                this._newPokers = value;
            }
        }
        public Graphics g
        {
            get
            {
                return this._g;
            }
            set
            {
                this._g = value;
            }
        }


        /// <summary>
        /// 把牌从大到小重新排序
        /// </summary>
        public void sort()  //自写从大到小排序算法
        {
            int pokerAmount = this.pokers.Count;
            for (int j = 0; j < pokerAmount; j++) //循环17次
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
                Console.WriteLine(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
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
        /// 把牌从左至右绘制到容器上
        /// </summary>
        public void Paint()
        {
            for (int i = 0; i < newPokers.Count; i++)
            {
                int x = i * 40;
                Rectangle rt = new Rectangle(x, 0, 50, 95);
                g.FillRectangle(Brushes.White, rt);
                g.DrawRectangle(Pens.Black, rt);
                g.DrawString(this.newPokers[i].pokerNum.ToString(), new Font("宋体", 12), Brushes.Red, x + 5, 5);
            }
        }
    }
}
