using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FightTheLandLord
{
    public partial class MainForm : Form
    {
        private List<Poker> allPoker = new List<Poker>();
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 洗牌
        /// </summary>
        public void shuffle()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 发牌
        /// </summary>
        public void deal()
        {
            throw new System.NotImplementedException();
        }
    }
}
