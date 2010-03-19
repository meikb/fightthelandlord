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
	public partial class GameStart : UserControl
	{
        public event Action Click;

		public GameStart()
		{
			// 为初始化变量所必需
			InitializeComponent();
            Loaded += new RoutedEventHandler(GameStart_Loaded);
		}

        void GameStart_Loaded(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Hand;
            sbRock.Begin();
        }

        private void sbRock_Completed(object sender, EventArgs e)
        {
            sbRock.Begin();
        }

        private void tbStart_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Click != null)
                Click();
        }
	}
}