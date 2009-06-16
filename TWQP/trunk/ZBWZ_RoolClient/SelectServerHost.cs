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
    public partial class SelectServerHost : Form
    {

        public int selectServiceId { get; set; }
        public SelectServerHost()
        {
            InitializeComponent();
        }

        private void SelectServerHost_Load(object sender, EventArgs e)
        {
            foreach (var serviceId in GameMain.h._rollServiceIdList)
            {
                this.listBoxServerHosts.Items.Add(serviceId);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectServiceId = (int)listBoxServerHosts.SelectedItem;
            Close();
        }
    }
}
