using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Threading;

namespace MoleAttack
{
	public partial class GameMain : UserControl
	{
        List<Hole> holes = new List<Hole>();
        TimeSpan passedTime;
        DateTime startTime;
        DispatcherTimer gameLoop = new DispatcherTimer();
        MouseSound msInjured;

        int currentSpeed = 2500;
        int CurrentSpeed
        {
            get
            {
                return currentSpeed;
            }
            set
            {
                currentSpeed = value;
                gameLoop.Interval = TimeSpan.FromMilliseconds(currentSpeed);
            }
        }
        int hitMouseCount = 0;

        int HitMouseCount
        {
            get { return hitMouseCount; }
            set
            {
                hitMouseCount = value;
                infomation.tbScore.Text = hitMouseCount.ToString();
            }
        }

		public GameMain()
		{
			// 为初始化变量所必需
			InitializeComponent();
            Loaded += new RoutedEventHandler(GameMain_Loaded);
            gameOver.Visibility = Visibility.Collapsed;
            gameOver.Click += new RoutedEventHandler(gameOver_Click);
            gameStart.Click += new Action(gameStart_Click);
		}

        void gameOver_Click(object sender, RoutedEventArgs e)
        {
            gameOver.Visibility = Visibility.Collapsed;
            startTime = DateTime.Now;
            HitMouseCount = 0;
            CurrentSpeed = 2500;
            infomation.tbLevel.Text = "1";
            gameLoop.Start();
        }

        void GameMain_Loaded(object sender, RoutedEventArgs e)
        {
            gameLoop.Tick += new EventHandler(gameLoop_Tick);
            gameLoop.Interval = TimeSpan.FromMilliseconds(currentSpeed);
            //gameLoop.Start();
            foreach (var uie in gridHoles.Children)
            {
                if (uie is Hole)
                {
                    var oneHole = uie as Hole;
                    holes.Add(oneHole);
                    oneHole.mouse.EvInjured += new Action(mouse_EvInjured);
                }
            }
            msInjured = new MouseSound("Sound/injured.mp3");
        }

        void gameLoop_Tick(object sender, EventArgs e)
        {
            passedTime = DateTime.Now - startTime;
            var passSeconds = passedTime.Minutes * 60 + passedTime.Seconds;
            if (passSeconds > 15 && passSeconds < 30)
            {
                infomation.tbLevel.Text = "2";
                CurrentSpeed = 2000;
            }
            if (passSeconds > 30 && passSeconds < 60)
            {
                infomation.tbLevel.Text = "3";
                CurrentSpeed = 1500;
            }
            if (passSeconds > 60 && passSeconds < 120)
            {
                infomation.tbLevel.Text = "4";
                CurrentSpeed = 1000;
            }
            if (passSeconds > 120 && passSeconds < 240)
            {
                infomation.tbLevel.Text = "5";
                CurrentSpeed = 500;
            }
            if (passSeconds > 240)
            {
                GameOver();
                gameLoop.Stop();
            }
            holes[GetRandomNum()].mouse.OutHole();
        }

        public void GameOver()
        {
            gameOver.Show();
        }



        void mouse_EvInjured()
        {
            HitMouseCount++;
            msInjured.Play();
        }
        /// <summary>
        /// 获取一个随机数
        /// </summary>
        /// <returns>随机数</returns>
        public int GetRandomNum()
        {
            //Thread.Sleep(10);
            long tick = DateTime.Now.Ticks;
            Random r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            return r.Next(0, holes.Count);
        }

        private void gameStart_Click()
        {
            gameLoop.Start();
            startTime = DateTime.Now;
            gridHoles.Children.Remove(gameStart);
        }
	}
}