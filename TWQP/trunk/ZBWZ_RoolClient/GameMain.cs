using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZBWZ;

namespace ZBWZ_RoolClient
{
    public partial class GameMain : Form
    {

        /// <summary>
        /// 处理程序
        /// </summary>
        public static Handler h;
        public GameMain()
        {
            InitializeComponent();
        }

        private void GameMain_Load(object sender, EventArgs e)
        {
            var inputId = new InputId();
            inputId.ShowDialog();
            h = new Handler(inputId.PlayerId);
            lblID.Text = inputId.PlayerId.ToString();
            h.player = new Character();
            new ContactCenterCallback(h);
            timer1.Enabled = true;
            inputId.Dispose();
        }

        private void 加入服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectServerHost ssh = new SelectServerHost();
            ssh.ShowDialog();
            if (ssh.selectServiceId != 0)
            {
                h.ServerID = ssh.selectServiceId;
                h.发出_能进否();
                h.clientState = ClientStates.已发_能进否;
            }
        }

        private void btnReady_Click(object sender, EventArgs e)
        {
            h.发出_准备();
            h.clientState = ClientStates.已发_已准备好;
            btnReady.Visible = false;
        }

        private void btnThrow_Click(object sender, EventArgs e)
        {
            h.发出_投掷();
            h.clientState = ClientStates.已发_已掷骰子;
            btnThrow.Visible = false;
            pictureBox1.Visible = true;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //发送程序
        {
            h.发出_所有消息();
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            base.WndProc(ref m);
            if (h != null)
            {
                h.发出_所有消息();
                switch (h.clientState)
                {
                    case ClientStates.收到_断开:
                        //MessageBox.Show("与服务器断开连接");
                        btnReady.Visible = false;
                        btnThrow.Visible = false;
                        break;
                    case ClientStates.收到_请投掷:
                        btnThrow.Visible = true;
                        break;
                    case ClientStates.收到_请准备:
                        btnReady.Visible = true;
                        break;
                }
            }
        }
        /// <summary>
        /// 游戏循环检测
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Process(object sender, EventArgs e)  
        {
            h.Counter++;
            KeyValuePair<int,byte[][]>[] receiveWhispers;
            lock (h._syncWhispers)
            {
                receiveWhispers = new KeyValuePair<int, byte[][]>[h._receiveWhispers.Count];
                h._receiveWhispers.CopyTo(receiveWhispers, 0);
                h._receiveWhispers.Clear();
            }
            foreach (var receiveWhisper in receiveWhispers)
            {
                var ServiceId = receiveWhisper.Key;
                var receiveData = (RollActions)BitConverter.ToInt32(receiveWhisper.Value[0], 0);
                switch (receiveData)
                {
                    case RollActions.S_能进入:
                        h.处理_能够进入();
                        break;
                    case RollActions.S_不能进入:
                        h.处理_不能进入();
                        break;
                    case RollActions.S_请准备:
                        h.处理_请准备();
                        break;
                    case RollActions.S_请投掷:
                        h.处理_请投掷();
                        break;
                    case RollActions.S_点数:
                        h.处理_点数(BitConverter.ToInt32(receiveWhisper.Value[1], 0));
                        h.clientState = ClientStates.已发_已掷骰子;
                        lblNum.Text = h.player.Num.ToString();
                        pictureBox1.Visible = false;
                        btnThrow.Visible = false;
                        break;
                    case RollActions.S_结果:
                        var WinerIds = receiveWhisper.Value[1].ToObject<int[]>();
                        if (WinerIds[0] == 0)
                        {
                            MessageBox.Show("打平了");
                        }
                        else
                        {
                            var isWiner = h.处理_结果(WinerIds);
                            if (isWiner)
                            {
                                MessageBox.Show("你赢了");
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder("你输了,赢家是: ");
                                foreach (var WinerId in WinerIds)
                                {
                                    sb.Append(WinerId.ToString() + " ");
                                }
                                MessageBox.Show(sb.ToString());
                            }
                        }
                        break;
                    case RollActions.S_踢出:
                        h.处理_踢出();
                        break;

                }
            }
        }
    }
}
