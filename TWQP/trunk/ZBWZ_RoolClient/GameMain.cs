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
        public Player player;
        public GameMain()
        {
            InitializeComponent();
        }

        private void GameMain_Load(object sender, EventArgs e)
        {
            var inputId = new InputId();
            inputId.ShowDialog();
            player = new Player(inputId.PlayerId);
        }

        private void 输入IDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var inputId = new InputId();
            inputId.ShowDialog();
            player.Id = inputId.PlayerId;
        }

        private void 加入服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
