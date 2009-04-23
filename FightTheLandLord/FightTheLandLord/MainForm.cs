using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FightTheLandLord
{
    public partial class MainForm : Form
    {
        private List<Poker> allPoker = new List<Poker>();
        private Player player1 = new Player();
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        public void shuffle()
        {
            Poker lastPoker;
            try
            {
                for(int i =0;i < 5000;i++)  //洗牌,六个随机数向下替换.
                {
                    int num1 = new Random().Next(0, 27);
                    int num2 = new Random().Next(28, 54);
                    int num3 = new Random().Next(0, 54);
                    int num4 = new Random().Next(0, 10);
                    int num5 = new Random().Next(34, 54);
                    int num6 = new Random().Next(45, 54);
                    lastPoker = this.allPoker[num1];
                    this.allPoker[num1] = this.allPoker[num2];
                    this.allPoker[num2] = this.allPoker[num3];
                    this.allPoker[num3] = this.allPoker[num4];
                    this.allPoker[num4] = this.allPoker[num5];
                    this.allPoker[num5] = this.allPoker[num6];
                    this.allPoker[num6] = lastPoker;
                }
#if DEBUG
                Console.WriteLine("以下是洗过的牌");
                foreach (Poker onePoker in this.allPoker)
                {
                    Console.WriteLine(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
                }
#endif
            }
            catch
            {
            }
        }

        /// <summary>
        /// 发牌
        /// </summary>
        public void deal()
        {
            for (int i = 0; i < 17; i++)
            {
                player1.pokers.Add(this.allPoker[i]);
            }

#if DEBUG
            Console.WriteLine("以玩家一的牌");
            foreach (Poker onePoker in player1.pokers)
            {
                Console.WriteLine(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
            }
#endif
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            for (int i = 3; i < 18; i++)  //嵌套for循环初始化54张牌
            {
                for (int j = 1; j < 5; j++)
                {
                    if (i <= 15)
                    {
                        this.allPoker.Add(new Poker((PokerNum)i, (PokerColor)j));
                    }
                }
                if (i >= 16)
                {
                    this.allPoker.Add(new Poker((PokerNum)i, PokerColor.spade));
                }
            }                           //嵌套for循环初始化54张牌

#if DEBUG
            Console.WriteLine(allPoker.Count);
            foreach (Poker onePoker in this.allPoker)
            {
                Console.WriteLine(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
            }
#endif
            shuffle(); //洗牌
            deal(); //发牌
            player1.sort(); //把牌从大到小排序
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}
