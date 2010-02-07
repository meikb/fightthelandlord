using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace CrazySpot
{
	public partial class Level2 : UserControl
	{
        bool spot1Find;
        bool spot2Find;
        bool spot3Find;
        bool spot4Find;
        bool spot5Find;
		public Level2()
		{
			// 为初始化变量所必需
			InitializeComponent();
		}

        private void spot1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            spot1Find = true;
            Check();
        }

        private void spot2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            spot2Find = true;
            Check();
        }

        private void spot3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            spot3Find = true;
            Check();
        }

        private void spot4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            spot4Find = true;
            Check();
        }

        private void spot5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            spot5Find = true;
            Check();
        }

        private void Check()
        {
            if (spot1Find && spot2Find && spot3Find && spot4Find && spot5Find)
            {
                MessageBox.Show("成功");
            }
        }
	}
}