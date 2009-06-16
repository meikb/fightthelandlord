namespace ZBWZ_RoolClient
{
    partial class SelectServerHost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxServerHosts = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxServerHosts
            // 
            this.listBoxServerHosts.FormattingEnabled = true;
            this.listBoxServerHosts.ItemHeight = 12;
            this.listBoxServerHosts.Location = new System.Drawing.Point(12, 12);
            this.listBoxServerHosts.Name = "listBoxServerHosts";
            this.listBoxServerHosts.Size = new System.Drawing.Size(260, 244);
            this.listBoxServerHosts.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 262);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "进入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectServerHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 285);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxServerHosts);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectServerHost";
            this.Text = "选择服务器";
            this.Load += new System.EventHandler(this.SelectServerHost_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxServerHosts;
        private System.Windows.Forms.Button button1;
    }
}