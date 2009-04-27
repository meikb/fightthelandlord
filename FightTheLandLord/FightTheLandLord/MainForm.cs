using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


// 再写把牌发给客户端以及处理客户端的出牌请求
namespace FightTheLandLord
{
    public partial class MainForm : Form
    {
        private List<Poker> allPoker = new List<Poker>();
        private Player player1 = new Player();
        private Server server;
        private Client client;
        private Thread acceptOk;
        private Thread acceptStart;
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
                this.player1.pokers.Add(this.allPoker[i]);
            }
            List<Poker> player2Pokers = new List<Poker>();
            for (int i = 17; i < 34; i++)
            {
                player2Pokers.Add(this.allPoker[i]);
            }
            List<Poker> player3Pokers = new List<Poker>();
            for (int i = 34; i < 51; i++)
            {
                player3Pokers.Add(this.allPoker[i]);
            }
            int LandLordNum = new Random().Next(0, 3);

            for (int i = 51; i < 54; i++)
            {
                switch (LandLordNum)
                {
                    case 0:
                        this.player1.pokers.Add(this.allPoker[i]);
                        break;
                    case 1:
                        player2Pokers.Add(this.allPoker[i]);
                        break;
                    case 2:
                        player3Pokers.Add(this.allPoker[i]);
                        break;
                }
            }
            if (server.SendPokerForClient(player2Pokers, player3Pokers))
            {
                MessageBox.Show("发牌成功", "火拼斗地主");
            }
            else
            {
                MessageBox.Show("发牌失败", "火拼斗地主");
            }

#if DEBUG //调试时在Console上显示的信息
            Console.WriteLine("玩家一的牌");
            foreach (Poker onePoker in player1.pokers)
            {
                Console.WriteLine(onePoker.pokerColor.ToString() + onePoker.pokerNum.ToString());
            }
#endif
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.server != null)
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
                        this.allPoker.Add(new Poker((PokerNum)i, PokerColor.黑桃));
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
            }
            this.player1.sort(); //把牌从大到小排序
            this.player1.g = this.panelPlayer1.CreateGraphics(); //把panelPlayer1的Graphics传递给player1
            this.player1.Paint(); //在panelPlayer1中画出player1的牌
            this.panelPlayer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPlayer1_MouseClick); //给panelPlayer1添加一个点击事件
            this.btnStart.Enabled = false;
            this.btnStart.Visible = false;
            this.btnLead.Enabled = true;
            this.btnLead.Visible = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        private void panelPlayer1_Paint(object sender, PaintEventArgs e)
        {
            this.player1.Paint();
        }

        private void panelPlayer1_MouseClick(object sender, MouseEventArgs e)  //鼠标点击事件,处理选中牌的效果
        {
            int index;
            this.player1.backColor = this.panelPlayer1.BackColor;
            if ((int)(e.X / 40) < player1.newPokers.Count)
            {
                index = (int)(e.X / 40);
                this.player1.Paint(index);
            }
        }

        private void btnLead_Click(object sender, EventArgs e) //出牌按钮的事件处理程序
        {
            if (player1.lead())
            {
                this.lblIsRule.Text = "";
                player1.g.Clear(this.BackColor);
                player1.Paint();
            }
            else
            {
                this.lblIsRule.ForeColor = Color.Red;
                this.lblIsRule.Text = "您出的牌不符合规则";

            }
        }

        private void 创建游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.server = new Server();  //创建服务器
            this.server.listener.Start();  //开始监听
            Thread th = new Thread(new ThreadStart(this.server.Connection)); //新建一个线程用于接受请求连接
            th.Start(); //开始线程
            this.lblIsRule.Text = "创建游戏成功,等待其他人链接";
            this.timerServer.Enabled = true;
        }

        private void 加入游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JoinForm joinForm = new JoinForm();
            joinForm.ShowDialog();
            this.client = new Client();
            if (this.client.Connection())
            {
                MessageBox.Show("连接成功","消息");
                btnOK.Enabled = true;
                btnOK.Visible = true;   //启用"准备"按钮
            }
            else
            {
                MessageBox.Show("连接失败","消息");
            }
        }

        private void timerCheckConn_Tick(object sender, EventArgs e)
        {
            if (this.server.client1 != null && this.server.client2 != null)
            {
                this.lblIsRule.Text = "连接建立成功,等待其他人准备";
                if (this.acceptOk == null)  //如果线程没有初始化则先初始化
                {
                    this.acceptOk = new Thread(new ThreadStart(server.AccpetOk));
                }
                if (this.acceptOk.ThreadState == ThreadState.Unstarted)  //如果线程没有启动则先启动
                {
                    this.acceptOk.Start();
                }
                if (this.server.everyOneIsOk) //启动线程后,服务器循环获取客户端的NetworkStream,然后判断客户端是否发送"OK"信息,如果发送,则把everyOneIsOk设置为True.
                {
                    this.lblIsRule.Text = "所有人已准备,可以开始游戏";
                    this.btnStart.Enabled = true;
                    this.btnStart.Visible = true;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.client.SendOk())
            {
                btnOK.Enabled = false;
                btnOK.Visible = false;
                this.timerClient.Enabled = true;
            }
            else
            {
                MessageBox.Show("准备失败,请检查网络连接", "消息");
            }
        }

        private void timerClient_Tick(object sender, EventArgs e)
        {
            if (this.acceptStart == null)
            {
                this.acceptStart = new Thread(new ThreadStart(client.AcceptStart));
                this.acceptStart.Name = "接受即将开始消息线程";
            }
            if (this.acceptStart.ThreadState == ThreadState.Unstarted)
            {
                this.acceptStart.Start();
            }
            if (this.client.isStart)
            {
                if (this.player1.newPokers.Count == 0)
                {
                    if (this.client.AcceptPokers() != null)
                    {
                        this.player1.pokers = this.client.Pokers;
                        this.player1.sort(); //把牌从大到小排序
                        this.player1.g = this.panelPlayer1.CreateGraphics(); //把panelPlayer1的Graphics传递给player1
                        this.player1.Paint(); //在panelPlayer1中画出player1的牌
                        this.panelPlayer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPlayer1_MouseClick); //给panelPlayer1添加一个点击事件
                        this.btnLead.Enabled = true;
                        this.btnLead.Visible = true;
                    }
                }
            }
        }
    }
}
