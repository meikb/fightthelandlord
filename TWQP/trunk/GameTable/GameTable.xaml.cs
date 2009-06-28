using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameTable
{
    /// <summary>
    /// GameTable.xaml 的交互逻辑
    /// </summary>
    public partial class GameTable : UserControl
    {
        /// <summary>
        /// 桌子ID
        /// </summary>
        public int ID { get; set; }
        public GameTable(int id)
        {
            InitializeComponent();
            this.ID = id;
        }
    }
}
