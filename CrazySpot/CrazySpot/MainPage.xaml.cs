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

namespace CrazySpot
{
	public partial class MainPage : UserControl
	{
        private static MainPage _instance;

        public static MainPage Instance
        {
            get { return _instance; }
        }

        private DispatcherTimer dtGameLoop;

        private GameState state;

        /// <summary>
        /// 剩余时间
        /// </summary>
        public int remainderMillisecond = 60000;

        public DateTime startTime;

		public MainPage()
		{
			// 为初始化变量所必需
			InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            _instance = this;
            dtGameLoop = new DispatcherTimer();
            dtGameLoop.Tick += new EventHandler(dtGameLoop_Tick);
            dtGameLoop.Interval = new TimeSpan(0, 0, 0, 0);
            imageNextLevel.Visibility = Visibility.Collapsed;
            imageResult.Visibility = Visibility.Collapsed;
		}

        void dtGameLoop_Tick(object sender, EventArgs e)
        {
            var timeSpan = DateTime.Now - startTime;
            var passTime = timeSpan.Minutes * 60 * 1000 + timeSpan.Seconds * 1000 + timeSpan.Milliseconds;
            pbTimer.Value = (remainderMillisecond - passTime) / (double)remainderMillisecond * 100d;

            if (pbTimer.Value <= 0)
            {
                SetGameState(GameState.GameOver);
            }
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            SetGameState(GameState.GameMenu);
        }

        public void SetGameState(GameState state)
        {
            this.state = state;
            switch (state)
            {
                case GameState.GameMenu:
                    this.LayoutRoot.Children.Add(Login.Instance);
                    imageResult.Visibility = Visibility.Collapsed;
                    GameMain.Child = null;
                    break;
                case GameState.GameStart:
                    LayoutRoot.Children.Remove(Login.Instance);
                    SetGameState(GameState.Level1);
                    break;
                case GameState.Level1:
                    GameMain.Child = new Level1();
                    dtGameLoop.Start();
                    startTime = DateTime.Now;
                    break;
                case GameState.Level2:
                    GameMain.Child = new Level2();
                    dtGameLoop.Start();
                    startTime = DateTime.Now;
                    break;
                case GameState.Level3:
                    GameMain.Child = new Level3();
                    dtGameLoop.Start();
                    startTime = DateTime.Now;
                    break;
                case GameState.Level4:
                    GameMain.Child = new Level4();
                    dtGameLoop.Start();
                    startTime = DateTime.Now;
                    break;
                //case GameState.Level5:
                //    dtGameLoop.Start();
                //    startTime = DateTime.Now;
                //    break;
                case GameState.GameOver:
                    MessageBox.Show("GameOver");
                    dtGameLoop.Stop();
                    break;
                case GameState.Result:
                    imageResult.Visibility = Visibility.Visible;
                    break;
                default:
                    break;
            }
        }

        public void ShowNextLevelIcon()
        {
            if ((GameState)(state + 1) == GameState.Result) //如果这一关为最后一关,则直接跳到通关画面
                NextLevel();
            else
            {
                imageNextLevel.Visibility = Visibility.Visible;
                sbNextLevel.Begin();
            }
        }

        private void NextLevel()
        {
            imageNextLevel.Visibility = Visibility.Collapsed;
            SetGameState((GameState)((int)state + 1));
        }

        private void imageNextLevel_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            NextLevel();
        }

        private void imageResult_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetGameState(GameState.GameMenu); //通关,返回主菜单
        }
	}
}