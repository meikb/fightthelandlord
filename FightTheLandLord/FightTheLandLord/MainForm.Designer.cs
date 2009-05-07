namespace FightTheLandLord
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnStart = new System.Windows.Forms.Button();
            this.panelPlayer1 = new System.Windows.Forms.Panel();
            this.btnLead = new System.Windows.Forms.Button();
            this.lblIsRule = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.创建游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.加入游戏ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于作者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerServer = new System.Windows.Forms.Timer(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.timerClient = new System.Windows.Forms.Timer(this.components);
            this.tbState = new System.Windows.Forms.TextBox();
            this.panelPlayer2 = new System.Windows.Forms.Panel();
            this.panelPlayer3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(360, 381);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panelPlayer1
            // 
            this.panelPlayer1.Location = new System.Drawing.Point(10, 411);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(800, 150);
            this.panelPlayer1.TabIndex = 1;
            this.panelPlayer1.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlayer1_Paint);
            // 
            // btnLead
            // 
            this.btnLead.Enabled = false;
            this.btnLead.Location = new System.Drawing.Point(360, 352);
            this.btnLead.Name = "btnLead";
            this.btnLead.Size = new System.Drawing.Size(75, 23);
            this.btnLead.TabIndex = 2;
            this.btnLead.Text = "出牌";
            this.btnLead.UseVisualStyleBackColor = true;
            this.btnLead.Visible = false;
            this.btnLead.Click += new System.EventHandler(this.btnLead_Click);
            // 
            // lblIsRule
            // 
            this.lblIsRule.AutoSize = true;
            this.lblIsRule.ForeColor = System.Drawing.Color.Red;
            this.lblIsRule.Location = new System.Drawing.Point(10, 392);
            this.lblIsRule.Name = "lblIsRule";
            this.lblIsRule.Size = new System.Drawing.Size(0, 12);
            this.lblIsRule.TabIndex = 3;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.游戏ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(822, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 游戏ToolStripMenuItem
            // 
            this.游戏ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.创建游戏ToolStripMenuItem,
            this.加入游戏ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.游戏ToolStripMenuItem.Name = "游戏ToolStripMenuItem";
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 创建游戏ToolStripMenuItem
            // 
            this.创建游戏ToolStripMenuItem.Name = "创建游戏ToolStripMenuItem";
            this.创建游戏ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.创建游戏ToolStripMenuItem.Text = "创建游戏";
            this.创建游戏ToolStripMenuItem.Click += new System.EventHandler(this.创建游戏ToolStripMenuItem_Click);
            // 
            // 加入游戏ToolStripMenuItem
            // 
            this.加入游戏ToolStripMenuItem.Name = "加入游戏ToolStripMenuItem";
            this.加入游戏ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.加入游戏ToolStripMenuItem.Text = "加入游戏";
            this.加入游戏ToolStripMenuItem.Click += new System.EventHandler(this.加入游戏ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于作者ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 关于作者ToolStripMenuItem
            // 
            this.关于作者ToolStripMenuItem.Name = "关于作者ToolStripMenuItem";
            this.关于作者ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.关于作者ToolStripMenuItem.Text = "关于作者";
            this.关于作者ToolStripMenuItem.Click += new System.EventHandler(this.关于作者ToolStripMenuItem_Click);
            // 
            // timerServer
            // 
            this.timerServer.Interval = 1000;
            this.timerServer.Tick += new System.EventHandler(this.timerServer_Tick);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(279, 381);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "准备";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // timerClient
            // 
            this.timerClient.Interval = 1000;
            this.timerClient.Tick += new System.EventHandler(this.timerClient_Tick);
            // 
            // tbState
            // 
            this.tbState.ForeColor = System.Drawing.Color.Red;
            this.tbState.Location = new System.Drawing.Point(293, 27);
            this.tbState.Multiline = true;
            this.tbState.Name = "tbState";
            this.tbState.ReadOnly = true;
            this.tbState.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbState.Size = new System.Drawing.Size(212, 47);
            this.tbState.TabIndex = 6;
            // 
            // panelPlayer2
            // 
            this.panelPlayer2.Location = new System.Drawing.Point(10, 27);
            this.panelPlayer2.Name = "panelPlayer2";
            this.panelPlayer2.Size = new System.Drawing.Size(100, 378);
            this.panelPlayer2.TabIndex = 7;
            this.panelPlayer2.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlayer2_Paint);
            // 
            // panelPlayer3
            // 
            this.panelPlayer3.Location = new System.Drawing.Point(710, 27);
            this.panelPlayer3.Name = "panelPlayer3";
            this.panelPlayer3.Size = new System.Drawing.Size(100, 378);
            this.panelPlayer3.TabIndex = 8;
            this.panelPlayer3.Paint += new System.Windows.Forms.PaintEventHandler(this.panelPlayer3_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 566);
            this.Controls.Add(this.panelPlayer3);
            this.Controls.Add(this.panelPlayer2);
            this.Controls.Add(this.tbState);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblIsRule);
            this.Controls.Add(this.btnLead);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(830, 600);
            this.MinimumSize = new System.Drawing.Size(830, 600);
            this.Name = "MainForm";
            this.Text = "火拼斗地主";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.Button btnLead;
        private System.Windows.Forms.Label lblIsRule;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 创建游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 加入游戏ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于作者ToolStripMenuItem;
        private System.Windows.Forms.Timer timerServer;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Timer timerClient;
        private System.Windows.Forms.TextBox tbState;
        private System.Windows.Forms.Panel panelPlayer2;
        private System.Windows.Forms.Panel panelPlayer3;
    }
}

