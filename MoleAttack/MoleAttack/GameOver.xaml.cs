using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MoleAttack
{
	public partial class GameOver : UserControl
	{
        public event RoutedEventHandler Click;
        MouseSound ms;

		public GameOver()
		{
			// 为初始化变量所必需
			InitializeComponent();
            Loaded += new RoutedEventHandler(GameOver_Loaded);
		}

        void GameOver_Loaded(object sender, RoutedEventArgs e)
        {
            sbRock.Completed += new EventHandler(sbRock_Completed);
            tbAgain.MouseLeftButtonDown += new MouseButtonEventHandler(tbAgain_MouseLeftButtonDown);
            tbAgain.MouseEnter += new MouseEventHandler(tbAgain_MouseEnter);
            ms = new MouseSound("Sound/click.mp3");
        }

        void tbAgain_MouseEnter(object sender, MouseEventArgs e)
        {
            ms.Play();
        }

        public void Show()
        {
            this.Visibility = Visibility.Visible;
            sbGameOver.Begin();
            sbGameOver.Completed += new EventHandler(sbGameOver_Completed);
        }

        void sbGameOver_Completed(object sender, EventArgs e)
        {
            sbRock.Begin();
        }

        void tbAgain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Click != null)
                Click(sender, e);
        }

        void sbRock_Completed(object sender, EventArgs e)
        {
            sbRock.Begin();
        }
	}
}