using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZBWZ_RoolClient
{
    public partial class InputId : Form
    {
        public int PlayerId;
        public InputId()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayerId = int.Parse(textBox1.Text);
            Close();
        }
    }
}
