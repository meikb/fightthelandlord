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
        private PokerGroup allPoker = new PokerGroup();
        private Player player1 = new Player();
        private Server server;
        private Client client;
        private Thread acceptConn;
        private Thread AcceptClient1Data;
        private Thread AcceptClient2Data;
        private Thread AcceptServerData;
        //private Thread acceptPokers;
        //private Thread acceptOrder;
        //private Thread cacceptLeadPokers;
        //private Thread sacceptLeadPokers;
        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
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
            PokerGroup player2Pokers = new PokerGroup();
            for (int i = 17; i < 34; i++)
            {
                player2Pokers.Add(this.allPoker[i]);
            }
            PokerGroup player3Pokers = new PokerGroup();
            for (int i = 34; i < 51; i++)
            {
                player3Pokers.Add(this.allPoker[i]);
            }
            int LandLordNum = new Random().Next(1, 4);
            for (int i = 51; i < 54; i++)
            {
                switch (LandLordNum)
                {
                    case 1:
                        this.player1.pokers.Add(this.allPoker[i]);
                        break;
                    case 2:
                        player2Pokers.Add(this.allPoker[i]);
                        break;
                    case 3:
                        player3Pokers.Add(this.allPoker[i]);
                        break;
                }
            }
            if (server.SendDataForClient(player2Pokers,1) && server.SendDataForClient(player3Pokers,2))
            {
                DConsole.Write("[系统消息]发牌成功!");
                this.server.SendOrder(2);
            }
            else
            {
                DConsole.Write("[系统消息]发牌失败!");
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            DConsole.tb = this.tbState;
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
                if (this.server != null)
                {
                    server.SendDataForClient(DConsole.orderingPokers, 1);
                    server.SendDataForClient(DConsole.orderingPokers, 2);
                }
                if (this.client != null)
                {
                    client.SendDataForServer(DConsole.orderingPokers);
                }
                player1.g.Clear(this.BackColor);
                player1.Paint();
            }
            else
            {
                DConsole.Write("[系统消息]:您出的牌不符合规则!");
            }
        }

        private void 创建游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.server = new Server();  //创建服务器
            this.server.listener.Start();  //开始监听
            this.acceptConn = new Thread(new ThreadStart(this.server.Connection)); //新建一个线程用于接受请求连接
            this.acceptConn.IsBackground = true;
            this.acceptConn.Name = "检测客户端的连接并接受的线程";
            this.acceptConn.Start(); //开始线程
            DConsole.Write("[系统消息]:创建游戏成功,等待其他人链接");
            this.timerServer.Enabled = true;
            ToolStripMenuItem tsmi =(ToolStripMenuItem)(this.menuStrip1.Items["游戏ToolStripMenuItem"]);
            tsmi.DropDownItems["创建游戏ToolStripMenuItem"].Enabled = false;
            tsmi.DropDownItems["加入游戏ToolStripMenuItem"].Enabled = false;  //禁用相关菜单
        }

        private void 加入游戏ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JoinForm joinForm = new JoinForm();
            joinForm.ShowDialog();
            if (Properties.Settings.Default.Host != "")
            {
                this.client = new Client();
                if (this.client.Connection())
                {
                    MessageBox.Show("连接成功", "消息");
                    btnOK.Enabled = true;
                    btnOK.Visible = true;   //启用"准备"按钮
                    ToolStripMenuItem tsmi = (ToolStripMenuItem)(this.menuStrip1.Items["游戏ToolStripMenuItem"]);
                    tsmi.DropDownItems["创建游戏ToolStripMenuItem"].Enabled = false;
                    tsmi.DropDownItems["加入游戏ToolStripMenuItem"].Enabled = false;  //禁用相关菜单
                }
                else
                {
                    MessageBox.Show("连接失败", "消息");
                }
            }
        }

        private void timerServer_Tick(object sender, EventArgs e)
        {
            if (this.server.client1 != null && this.server.client2 != null)
            {
                if (this.tbState.Text.IndexOf("连接建立成功,等待其他人准备", 0, this.tbState.Text.Length) < 0) //防止向用户重复发送此消息
                {
                    DConsole.Write("[系统消息]:连接建立成功,等待其他人准备");
                }
                if (this.AcceptClient1Data == null)  //如果线程没有初始化则先初始化
                {
                    this.AcceptClient1Data = new Thread(new ThreadStart(server.AccpetClient1Data));
                    this.AcceptClient1Data.IsBackground = true;
                    this.AcceptClient1Data.Name = "服务器检测客户端1是否发送准备消息";
                }
                if (this.AcceptClient1Data.ThreadState == (ThreadState.Background | ThreadState.Unstarted))  //如果线程没有启动则先启动,由于之前把线程的IsBackGround设置为true,所以这里要这样写
                {
                        this.AcceptClient1Data.Start();
                }
                if (this.AcceptClient2Data == null)  //如果线程没有初始化则先初始化
                {
                    this.AcceptClient2Data = new Thread(new ThreadStart(server.AccpetClient2Data));
                    this.AcceptClient2Data.IsBackground = true;
                    this.AcceptClient2Data.Name = "服务器检测客户端2是否发送准备消息";
                }
                if (this.AcceptClient2Data.ThreadState == (ThreadState.Background | ThreadState.Unstarted))  //如果线程没有启动则先启动,由于之前把线程的IsBackGround设置为true,所以这里要这样写
                {
                    this.AcceptClient2Data.Start();
                }
                if (this.server.client1IsOk && this.server.client2IsOk)
                {
                    this.server.client1IsOk = false;
                    this.server.client2IsOk = false;
                    this.server.SendDataForClient("EveryOneIsOk", 1);
                    this.server.SendDataForClient("EveryOneIsOk", 2);
                    this.server.everyOneIsOk = true;
                }
                if (this.server.everyOneIsOk) //启动线程后,服务器循环获取客户端的NetworkStream,然后判断客户端是否发送"OK"信息,如果发送,则把everyOneIsOk设置为True.
                {
                    this.server.everyOneIsOk = false; //为下一局做准备
                    DConsole.Write("[系统消息]:所有人已准备,可以开始游戏");
                    this.btnStart.Enabled = true;
                    this.btnStart.Visible = true;
                }
                this.player1.haveOrder = this.server.haveOrder;
                if (this.player1.haveOrder)
                {
                    this.btnLead.Enabled = true;
                    this.btnLead.Visible = true;
                    this.server.haveOrder = false;
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
                if (this.AcceptServerData == null)
                {
                    this.AcceptServerData = new Thread(new ThreadStart(client.AcceptServerData));
                    this.AcceptServerData.IsBackground = true;
                    this.AcceptServerData.Name = "接受即将开始消息线程";
                }
                if (this.AcceptServerData.ThreadState == (ThreadState.Background | ThreadState.Unstarted))
                {
                    this.AcceptServerData.Start();
                }
                DConsole.Write("[系统消息]:已向服务器发送准备消息,正在等待响应...");
            }
            else
            {
                MessageBox.Show("准备失败,请检查网络连接", "消息");
            }
        }

        private void timerClient_Tick(object sender, EventArgs e)
        {
            if (this.client.everyIsOk)
            {
                if (this.player1.newPokers.Count == 0)
                {
                    if (this.client.Pokers != null)
                    {
                        DConsole.Write("[系统消息]:接收到服务器分配的牌组.");
                        this.player1.pokers = this.client.Pokers;
                        this.player1.sort(); //把牌从大到小排序
                        this.player1.g = this.panelPlayer1.CreateGraphics(); //把panelPlayer1的Graphics传递给player1
                        this.player1.Paint(); //在panelPlayer1中画出player1的牌
                        this.panelPlayer1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelPlayer1_MouseClick); //给panelPlayer1添加一个点击事件
                    }
                }
            }
            this.player1.haveOrder = this.client.haveOrder;
            if (this.player1.haveOrder)
            {
                this.btnLead.Enabled = true;
                this.btnLead.Visible = true;
                this.client.haveOrder = false;
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 关于作者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("作者:李达", "火拼斗地主");
        }
    }
}
