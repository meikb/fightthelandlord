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
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(360, 381);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 573);
            this.Controls.Add(this.lblIsRule);
            this.Controls.Add(this.btnLead);
            this.Controls.Add(this.panelPlayer1);
            this.Controls.Add(this.btnStart);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "火拼斗地主";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panelPlayer1;
        private System.Windows.Forms.Button btnLead;
        private System.Windows.Forms.Label lblIsRule;
    }
}

