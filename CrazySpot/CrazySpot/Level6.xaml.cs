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
	public partial class Level6 : UserControl
	{
        bool spot1Find;
        bool spot2Find;
        bool spot3Find;
        bool spot4Find;
        bool spot5Find;
		public Level6()
		{
			// 为初始化变量所必需
			InitializeComponent();
		}

        private void spot1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            ShowRightIcon(rect);
            spot1Find = true;
            Check();
        }

        private void spot2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            ShowRightIcon(rect);
            spot2Find = true;
            Check();
        }

        private void spot3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            ShowRightIcon(rect);
            spot3Find = true;
            Check();
        }

        private void spot4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            ShowRightIcon(rect);
            spot4Find = true;
            Check();
        }

        private void spot5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rect = sender as Rectangle;
            ShowRightIcon(rect);
            spot5Find = true;
            Check();
        }


        private void ShowRightIcon(Rectangle rect)
        {
            Right rightIcon = new Right();
            if (rect.Width > rightIcon.Width || rect.Height > rightIcon.Height)
            {
                rightIcon.Width = rect.Width;
                rightIcon.Height = rect.Height;
            }
            Canvas.SetLeft(rightIcon, Canvas.GetLeft(rect));
            Canvas.SetTop(rightIcon, Canvas.GetTop(rect));
            LayoutRoot.Children.Add(rightIcon);
        }

        private void Check()
        {
            if (spot1Find && spot2Find && spot3Find && spot4Find && spot5Find)
            {
                MainPage.Instance.ShowNextLevelIcon();
            }
        }
	}
}