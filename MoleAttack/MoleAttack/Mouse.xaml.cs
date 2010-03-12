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

namespace MoleAttack
{
	public partial class Mouse : UserControl
	{
        public event Action EvInjured;

		public Mouse()
		{
			// 为初始化变量所必需
			InitializeComponent();
            imgNormal.MouseLeftButtonDown += new MouseButtonEventHandler(imgNormal_MouseLeftButtonDown);
		}

        void imgNormal_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (EvInjured != null)
                EvInjured();
        }

        public void OutHole()
        {
            if (imgInjured.Visibility == Visibility.Collapsed)
            {
                imgNormal.Visibility = Visibility.Visible;
                DispatcherTimer dis = new DispatcherTimer();
                dis.Interval = TimeSpan.FromMilliseconds(1000);
                dis.Tick += new EventHandler(dis_Tick2);
                dis.Start();
            }
        }

        void dis_Tick2(object sender, EventArgs e)
        {
            var dis = sender as DispatcherTimer;
            imgNormal.Visibility = Visibility.Collapsed;
            dis.Stop();
            dis.Tick -= dis_Tick2;
        }

        public void Injured()
        {
            imgNormal.Visibility = Visibility.Collapsed;
            imgInjured.Visibility = Visibility.Visible;
            DispatcherTimer dis = new DispatcherTimer();
            dis.Tick += new EventHandler(dis_Tick);
            dis.Interval = TimeSpan.FromMilliseconds(500);
            dis.Start();
        }

        void dis_Tick(object sender, EventArgs e)
        {
            var dis = sender as DispatcherTimer;
            dis.Tick -= dis_Tick;
            dis.Stop();
            imgInjured.Visibility = Visibility.Collapsed;
        }
	}
}