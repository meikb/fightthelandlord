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
            this.panelPlayer1.Location = new System.Drawing.Point(12, 410);
            this.panelPlayer1.Name = "panelPlayer1";
            this.panelPlayer1.Size = new System.Drawing.Size(768, 150);
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
            this.lblIsRule.Location = new System.Drawing.Point(358, 337);
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
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
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
            this.游戏ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.游戏ToolStripMenuItem.Text = "游戏";
            // 
            // 创建游戏ToolStripMenuItem
            // 
            this.创建游戏ToolStripMenuItem.Name = "创建游戏ToolStripMenuItem";
            this.创建游戏ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.创建游戏ToolStripMenuItem.Text = "创建游戏";
            this.创建游戏ToolStripMenuItem.Click += new System.EventHandler(this.创建游戏ToolStripMenuItem_Click);
            // 
            // 加入游戏ToolStripMenuItem
            // 
            this.加入游戏ToolStripMenuItem.Name = "加入游戏ToolStripMenuItem";
            this.加入游戏ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.加入游戏ToolStripMenuItem.Text = "加入游戏";
            this.加入游戏ToolStripMenuItem.Click += new System.EventHandler(this.加入游戏ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于作者ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // 关于作者ToolStripMenuItem
            // 
            this.关于作者ToolStripMenuItem.Name = "关于作者ToolStripMenuItem";
            this.关于作者ToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.关于作者ToolStripMenuItem.Text = "关于作者";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.lblIsRule);
            this.Controls.Add(this.btnLead);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.menuStrip1);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
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
    }
}

