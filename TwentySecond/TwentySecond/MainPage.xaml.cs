using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Threading;

namespace TwentySecond
{
    public partial class MainPage : UserControl
    {
        DispatcherTimer _gameLooper = new DispatcherTimer();
        GameOver gameOver = new GameOver();
        DateTime startTime;
        DateTime lastLightningTime;
        Storyboard sb;
        int secondSpan; //多长时间闪电一次
        Player hero;
        List<Bullet> bullets = new List<Bullet>();
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            gameOver.Click += new RoutedEventHandler(gameOver_Click);
        }

        void gameOver_Click(object sender, RoutedEventArgs e)
        {
            InitGame();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            InitGame();
            #region 只执行一次的操作
            _gameLooper.Interval = new TimeSpan(0, 0, 0, 0);
            _gameLooper.Tick += new EventHandler(OnGameLoop);
            this.KeyDown += new KeyEventHandler(MainPage_KeyDown);
            this.KeyUp += new KeyEventHandler(MainPage_KeyUp);
            this.MouseMove += new MouseEventHandler(MainPage_MouseMove);
            Canvas.SetLeft(gameOver, 240);
            Canvas.SetTop(gameOver, 180);
            Canvas.SetZIndex(gameOver, 100);
            GameCanvas.Children.Add(gameOver);
            #endregion
            //InitDot();
        }

        /// <summary>
        /// 鼠标控制
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            hero.nowPosition.X = (int)e.GetPosition(GameCanvas).X - hero.Radius;
            hero.nowPosition.Y = (int)e.GetPosition(GameCanvas).Y - hero.Radius;
        }

        /// <summary>
        /// 初始化游戏
        /// </summary>
        private void InitGame()
        {
            gameOver.Visibility = Visibility.Collapsed;
            foreach (var oneBullet in bullets)
            {
                GameCanvas.Children.Remove(oneBullet);
            }
            if (hero != null)
                GameCanvas.Children.Remove(hero);
            bullets.Clear();
            for (int i = 0; i < 50; i++)
            {
                AddBullet();
            }
            hero = new Player(new Vector2(0, 0), new Vector2(400, 300));
            GameCanvas.Children.Add(hero);
            _gameLooper.Start();
            startTime = DateTime.Now;
            lastLightningTime = DateTime.Now;
        }

        #region 按键处理
        void MainPage_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    hero.UpButtonDown = false;
                    break;
                case Key.S:
                case Key.Down:
                    hero.DownButtonDown = false;
                    break;
                case Key.A:
                case Key.Left:
                    hero.LeftButtonDown = false;
                    break;
                case Key.D:
                case Key.Right:
                    hero.RightButtonDown = false;
                    break;
                default:
                    break;
            }
        }

        void MainPage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.W:
                case Key.Up:
                    hero.UpButtonDown = true;
                    break;
                case Key.S:
                case Key.Down:
                    hero.DownButtonDown = true;
                    break;
                case Key.A:
                case Key.Left:
                    hero.LeftButtonDown = true;
                    break;
                case Key.D:
                case Key.Right:
                    hero.RightButtonDown = true;
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 游戏主循环
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnGameLoop(object sender, EventArgs e)
        {
            var span = DateTime.Now - startTime;
            var costTime = (span.Hours * 60 * 60 * 1000 + span.Minutes * 60 * 1000 + span.Seconds * 1000 + span.Milliseconds) / 1000d;
            tbTimer.Text = string.Format("您已坚持:{0} 秒", costTime);
            hero.Updata();
            hero.Draw();
            foreach (var oneBullet in bullets)
            {
                oneBullet.Update();
                oneBullet.Draw();
                if (hero.CollisionCircle(oneBullet.CenterOfCircle))
                {
                    GameCanvas.Children.Remove(oneBullet);
                    HeroDied(); //被子弹击中
                }
            }

            #region 闪电
            if ((DateTime.Now - lastLightningTime).Seconds >= secondSpan)
            {
                lastLightningTime = DateTime.Now;
                secondSpan = GetRandomNum(3, 7); //3-7秒产生一次闪电
                var posY = GetRandomNum(0, 550);
                var light = new Lightning();
                Canvas.SetLeft(light, 0);
                Canvas.SetTop(light, posY);
                Canvas.SetZIndex(light, -100);
                GameCanvas.Children.Add(light);
                light.Fire += () =>
                    {
                        var lightY = Canvas.GetTop(light) + 50;
                        if (hero.nowPosition.Y < lightY + 25 && hero.nowPosition.Y > lightY - 25)
                        {
                            HeroDied(); //被闪电击中
                        }
                    };
                light.Completed += () =>
                    {
                        GameCanvas.Children.Remove(light); //闪电播放完成后
                    };
                light.Play(); //开始闪电
            }
            #endregion
        }

        /// <summary>
        /// Hero挂掉
        /// </summary>
        private void HeroDied()
        {
            GameCanvas.Children.Add(new Bob(hero.CenterOfCircle));
            GameCanvas.Children.Remove(hero);
            Shake();
            _gameLooper.Stop();
            gameOver.Visibility = Visibility.Visible;
            gameOver.SetTimer(tbTimer.Text);
        }

        /// <summary>
        /// 添加一颗子弹
        /// </summary>
        void AddBullet()
        {
            int dir = GetRandomNum(0, 4);
            int vecx, vecy, posX = 0, posY = 0;
            switch (dir)
            {
                case 0:
                    posX = GetRandomNum(0, 780);
                    posY = GetRandomNum(0, 30);
                    break;
                case 1:
                    posX = GetRandomNum(0, 780);
                    posY = GetRandomNum(550, 580);
                    break;
                case 2:
                    posX = GetRandomNum(0, 30);
                    posY = GetRandomNum(0, 580);
                    break;
                case 3:
                    posX = GetRandomNum(750, 780);
                    posY = GetRandomNum(0, 580);
                    break;
                default:
                    break;
            }
            vecx = GetRandomNum();
            vecy = GetRandomNum();
            var oneBullet = new Bullet(new Vector2(vecx, vecy), new Vector2(posX, posY));
            bullets.Add(oneBullet);
            GameCanvas.Children.Add(oneBullet);
        }

        /// <summary>
        /// 获取一个随机数,本游戏中用于随机生成子弹的速度
        /// </summary>
        /// <returns>随机数</returns>
        public int GetRandomNum()
        {
            Thread.Sleep(1);
            long tick = DateTime.Now.Ticks;
            Random r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            return r.Next(2, 5);
        }

        /// <summary>
        /// 获取一个随机数,可以指定最大值和最小值
        /// </summary>
        /// <returns>随机数</returns>
        public int GetRandomNum(int min, int max)
        {
            Thread.Sleep(1);
            long tick = DateTime.Now.Ticks;
            Random r = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            //return r.Next(min, max);
            return r.Next(min, max);
        }
        #region ====================Dot =========================
        /// <summary>
        /// 初始化星空,暂时没用
        /// </summary>
        void InitDot()
        {
            Random r = new Random();
            sb = new Storyboard();
            sb.Completed += new EventHandler(sb_Completed);
            this.Resources.Add("sb", sb);

            for (int i = 0; i < 100; i++)
            {
                Dot d = new Dot();
                d.X = 300 + r.NextDouble() * 200.0;
                d.Y = 200 + r.NextDouble() * 200.0;
                d.vx = 0;
                d.vy = 0;
                GameCanvas.Children.Add(d);
                Canvas.SetZIndex(d, -1);
            }

            sb.Begin();
        }

        void sb_Completed(object sender, EventArgs e)
        {
            Random r = new Random();
            foreach (var item in GameCanvas.Children)
            {
                if ((item as Dot) != null)
                {
                    Dot d = (Dot)item;
                    double x = GameCanvas.ActualWidth / 2 - Canvas.GetLeft(d);
                    double y = GameCanvas.ActualHeight / 2 - Canvas.GetTop(d);
                    d.vx = x / 100;
                    d.vy = y / 100;

                    if ((d.X > GameCanvas.ActualWidth) || (d.X < 0))
                    {
                        d.X = 300 + r.NextDouble() * 200.0;
                        d.vx = 0;
                        d.Width = 2;
                        d.Height = 2;
                    }
                    else
                    {
                        d.Width *= 1.007;
                        d.X -= d.vx;
                    }
                    if ((d.Y > GameCanvas.ActualHeight) || (d.Y < 0))
                    {
                        d.Y = 200 + r.NextDouble() * 200.0;
                        d.vy = 0;
                        d.Height = 2;
                        d.Width = 2;
                    }
                    else
                    {
                        d.Height *= 1.007;
                        d.Y -= d.vy;
                    }
                }
            }
            sb.Begin();
        }
        #endregion


        /// <summary>
        /// 震动效果
        /// </summary>
        private void Shake()
        {
            EventHandler ev = null;
            int i = 1;
            int j = 0;
            ev = (object sender1, EventArgs ea1) =>
                {
                    if (j < 15)
                    {
                        switch (i)
                        {
                            case 0:
                                Global.PlayAnimation(Canvas.GetTop(GameCanvas) - 2,TimeSpan.FromMilliseconds(10), GameCanvas, "(Canvas.Top)", ev);
                                break;
                            case 1:
                                Global.PlayAnimation(Canvas.GetLeft(GameCanvas) - 2, TimeSpan.FromMilliseconds(10), GameCanvas, "(Canvas.Left)", ev);
                                break;
                            case 2:
                                Global.PlayAnimation(Canvas.GetTop(GameCanvas) + 2,TimeSpan.FromMilliseconds(10), GameCanvas, "(Canvas.Top)", ev);
                                break;
                            case 3: 
                                j++;
                                i = -1;
                                Global.PlayAnimation(Canvas.GetLeft(GameCanvas) + 2,TimeSpan.FromMilliseconds(10), GameCanvas, "(Canvas.Left)", ev);
                                break;
                        }
                        i++;
                    }
                }; 
            Global.PlayAnimation(Canvas.GetTop(GameCanvas) - 2, TimeSpan.FromMilliseconds(10), GameCanvas, "(Canvas.Top)", ev);
        }
    }
}
