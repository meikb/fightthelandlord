using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace FightTheLandLord
{
    public class Player
    {
        private PokerGroup _pokers = new PokerGroup();
        private PokerGroup _newPokers = new PokerGroup();
        private PokerGroup _bakPokers = new PokerGroup();
        private List<int> _selectPokers = new List<int>();
        private PokerGroup _leadPokers = new PokerGroup();
        private Color _backColor;
        private Graphics _g;
        private bool _isLandLord;
        private bool _haveOrder;

        public PokerGroup pokers
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
        public PokerGroup newPokers
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
        public List<int> selectPokers
        {
            get
            {
                return this._selectPokers;
            }
            set
            {
                this._selectPokers = value;
            }
        }
        public Color backColor
        {
            get
            {
                return this._backColor;
            }
            set
            {
                this._backColor = value;
            }
        }
        public PokerGroup leadPokers
        {
            get
            {
                return this._leadPokers;
            }
            set
            {
                this._leadPokers = value;
            }
        }
        public PokerGroup bakPokers
        {
            get
            {
                return this._bakPokers;
            }
            set
            {
                this._bakPokers = value;
            }
        }

        public bool haveOrder
        {
            get
            {
                return this._haveOrder;
            }
            set
            {
                this._haveOrder = value;
            }
        }


        /// <summary>
        /// 把牌从大到小重新排序
        /// </summary>
        public void sort()  //排序玩家的牌
        {
            sort(this.pokers, this.newPokers); //调用sort另一个版本
#if DEBUG
            Console.WriteLine("排序后玩家一的牌");
            foreach (Poker onePoker in this.newPokers)
            {
                Console.WriteLine(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
            }
#endif
        }

        public static void sort(PokerGroup oldPokers,PokerGroup newPokers)  //从大到小排序算法
        {
            int pokerAmount = oldPokers.Count;
            for (int j = 0; j < pokerAmount; j++) //循环17次
            {
                Poker bestBigPoker = null; //目前this.pokers里最大的牌
                for (int i = 0; i < oldPokers.Count; i++)  //找出目前this.pokers里最大的牌存在bestBigPoker里面
                {
                    if (bestBigPoker == null)
                    {
                        bestBigPoker = oldPokers[i];
                    }
                    if (oldPokers[i].pokerNum > bestBigPoker.pokerNum)
                    {
                        bestBigPoker = oldPokers[i];
                    }
                }
                oldPokers.Remove(bestBigPoker); //从this.pokers里删除最大的牌
                newPokers.Add(bestBigPoker); //把这张最大的牌添加到一个新集合
            }
        }
        public void BakPoker()
        {
            this.bakPokers.Clear();
            foreach (Poker poker in this.newPokers)  //备份已经洗好的牌
            {
                this.bakPokers.Add(poker);
            }
        }

        /// <summary>
        /// 检测是否符合游戏规则,如果符合则出牌,否则返回flase
        /// </summary>
        public bool lead()
        {
            foreach (int selectPoker in this.selectPokers)  //迭代循环把已选中的牌添加到leadPokers
            {
                this.leadPokers.Add(this.newPokers[selectPoker]);
            }
            if (DConsole.IsRules(this.leadPokers))
            {
                this.BakPoker();  //备份现有newPokers,下次出牌时需要用到
                //this.leadPokers = DConsole.orderingPokers;
                foreach (int selectPoker in this.selectPokers)  //在newPokers里移除已经出过的牌
                {
                    this.newPokers.Remove(this.bakPokers[selectPoker]);
                }
                this.selectPokers.Clear();  //清空已选牌
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 把牌从左至右绘制到容器上
        /// </summary>
        public void Paint()
        {
            for (int i = 0; i < newPokers.Count; i++)  //循环绘制所有的牌
            {
                int x = i * 40;
                if (this.IndexIsHave(i) == false)  //当当前的牌没有被选中时,绘制如下图案
                {
                    Rectangle rt = new Rectangle(x, 50, 50, 95); //没有选中的牌的X比选中的牌的X多50
                    g.FillRectangle(Brushes.White, rt);
                    g.DrawRectangle(Pens.Black, rt);
                    g.DrawString(this.newPokers[i].pokerNum.ToString(), new Font("宋体", 12), Brushes.Red, x + 5, 55);
                }
                else  //当当前的牌已经被选中时,绘制如下图案
                {
                    Rectangle rt = new Rectangle(x, 0, 50, 95);
                    g.FillRectangle(Brushes.White, rt);
                    g.DrawRectangle(Pens.Black, rt);
                    g.DrawString(this.newPokers[i].pokerNum.ToString(), new Font("宋体", 12), Brushes.Red, x + 5, 5);
                }
            }
        }
        /// <summary>
        /// 传入一个整型显示出牌的选中效果
        /// </summary>
        public void Paint(int index)  //牌的位置从左到右依次用0-16表示,对应this.newPokers[0-16]
        {
            this.g.Clear(this.backColor);
            bool IndexIsHave = this.IndexIsHave(index); //返回一个值确定当前点击的牌是否已经被选中
            if (IndexIsHave) 
            {
                this.selectPokers.Remove(index);  //如果已经被选中则删除它
            }
            else
            {
                this.selectPokers.Add(index);  //如果没有被选中则添加它
            }
            this.Paint(); //绘制当前的牌
        }

        public bool IndexIsHave(int index)  //判断选中的牌中是否有传入的值
        {
            bool indexIsHave = false;
            foreach (int selectPoker in this.selectPokers)
            {
                if (selectPoker == index)
                {
                    indexIsHave = true;
                    break;
                }
            }
            return indexIsHave;
        }
    }
}
