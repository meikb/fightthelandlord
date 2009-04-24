namespace FightTheLandLord
{
    partial class JoinForm
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
            this.lblIP = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnJoin = new System.Windows.Forms.Button();
            this.maskedTextBoxIP = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(12, 50);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(59, 12);
            this.lblIP.TabIndex = 0;
            this.lblIP.Text = "服务器IP:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 77);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(59, 12);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "名    称:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 74);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // btnJoin
            // 
            this.btnJoin.Location = new System.Drawing.Point(59, 121);
            this.btnJoin.Name = "btnJoin";
            this.btnJoin.Size = new System.Drawing.Size(75, 23);
            this.btnJoin.TabIndex = 4;
            this.btnJoin.Text = "加入游戏";
            this.btnJoin.UseVisualStyleBackColor = true;
            this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click);
            // 
            // maskedTextBoxIP
            // 
            this.maskedTextBoxIP.BeepOnError = true;
            this.maskedTextBoxIP.ImeMode = System.Windows.Forms.ImeMode.On;
            this.maskedTextBoxIP.Location = new System.Drawing.Point(70, 47);
            this.maskedTextBoxIP.Mask = "099.099.099.099";
            this.maskedTextBoxIP.Name = "maskedTextBoxIP";
            this.maskedTextBoxIP.Size = new System.Drawing.Size(100, 21);
            this.maskedTextBoxIP.TabIndex = 5;
            // 
            // JoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 173);
            this.Controls.Add(this.maskedTextBoxIP);
            this.Controls.Add(this.btnJoin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblIP);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(200, 200);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 200);
            this.Name = "JoinForm";
            this.Text = "加入游戏";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnJoin;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxIP;
    }
}