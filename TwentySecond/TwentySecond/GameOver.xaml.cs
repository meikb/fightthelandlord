using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TwentySecond
{
	public partial class GameOver : UserControl
	{

        public event RoutedEventHandler Click;
		public GameOver()
		{
			// 为初始化变量所必需
			InitializeComponent();
            Loaded += new RoutedEventHandler(GameOver_Loaded);
		}

        void GameOver_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dis = new DispatcherTimer();
            dis.Interval = TimeSpan.FromMilliseconds(500);
            dis.Tick += new EventHandler(dis_Tick);
            dis.Start();
            clickTouch.MouseLeftButtonUp += new MouseButtonEventHandler(clickTouch_MouseLeftButtonUp);
        }

        void clickTouch_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            if (Click != null)
                Click(sender, e);
        }

        public void SetTimer(string costTime)
        {
            tbTimer.Text = costTime;
        }

        void dis_Tick(object sender, EventArgs e) //闪动效果
        {
            if (tbEnterRestart.Visibility == Visibility.Collapsed)
                tbEnterRestart.Visibility = Visibility.Visible;
            else
                tbEnterRestart.Visibility = Visibility.Collapsed;
        }
	}
}