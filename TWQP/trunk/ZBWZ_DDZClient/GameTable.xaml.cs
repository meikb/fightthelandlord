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

namespace ZBWZ_DDZClient
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
        public GameTable(int id,int[] playerID)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var tempButton = (Button)sender;
            switch ((int)tempButton.Tag)
            {
                case 1:
                    MessageHandler.发送_能否进入(ID); //todo以后再写选择座位
                    break;
                case 2:
                    MessageHandler.发送_能否进入(ID);
                    break;
                case 3:
                    MessageHandler.发送_能否进入(ID);
                    break;
                default:
                    break;
            }
        }
    }
}
