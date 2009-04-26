using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace FightTheLandLord
{
    public partial class JoinForm : Form
    {
        public JoinForm()
        {
            InitializeComponent();
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            IPAddress ip = IPAddress.Any;
            if (IPAddress.TryParse(this.textBoxIP.Text, out ip))
            {
                Properties.Settings.Default.Host = this.textBoxIP.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入一个正确的IP", "错误");
            }
        }
    }
}
