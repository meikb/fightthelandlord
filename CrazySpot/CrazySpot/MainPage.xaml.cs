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
	public partial class MainPage : UserControl
	{
        private static MainPage _instance;

        public static MainPage Instance
        {
            get { return _instance; }
        }

		public MainPage()
		{
			// 为初始化变量所必需
			InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            _instance = this;
		}

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            this.LayoutRoot.Children.Add(new Level4());
        }

        public void SetGameState(GameState state)
        {
            switch (state)
            {
                case GameState.GameStart:
                    SetGameState(GameState.Level1);
                    break;
                case GameState.Level1:

                    break;
                case GameState.Level2:
                    break;
                case GameState.Level3:
                    break;
                case GameState.Level4:
                    break;
                case GameState.Level5:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }
        }
	}
}