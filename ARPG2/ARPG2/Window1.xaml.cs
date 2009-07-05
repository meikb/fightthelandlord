using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace ARPG2
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        Image Sprite;
        DispatcherTimer dispatcherTimer;
        Point newp;
        int count = 1;
        Storyboard storyboard;
        Direction direction { get; set; }
        public Window1()
        {
            InitializeComponent();
            Sprite = new Image();
            Sprite.Width = 150;
            Sprite.Height = 150;
            Canvas.SetLeft(Sprite, 0);
            Canvas.SetTop(Sprite, 0);
            Carrier.Children.Add(Sprite);
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(150);
            dispatcherTimer.Start();
        }

        void dispatherTimer_Tick(object sender, EventArgs e)
        {
            var Sprite_X = Canvas.GetLeft(Sprite);
            var Sprite_Y = Canvas.GetTop(Sprite);
            txtx.Text = "X: " + (int)Sprite_X;
            txty.Text = "Y: " + (int)Sprite_Y;
            if (newp.X == Canvas.GetLeft(Sprite) && newp.Y == Canvas.GetTop(Sprite))
            {
                switch (direction)
                {
                    case Direction.正北:
                        count = 25;
                        break;
                    case Direction.东北:
                        count = 57;
                        break;
                    case Direction.西北:
                        count = 49;
                        break;
                    case Direction.正南:
                        count = 1;
                        break;
                    case Direction.东南:
                        count = 41;
                        break;
                    case Direction.西南:
                        count = 33;
                        break;
                    case Direction.正西:
                        count = 9;
                        break;
                    case Direction.正东:
                        count = 17;
                        break;
                }
            }
            else
            {
                switch (direction)
                {
                    case Direction.正北:
                        count = count == 32 ? 25 : count + 1;
                        break;
                    case Direction.东北:
                        count = count == 64 ? 57 : count + 1;
                        break;
                    case Direction.西北:
                        count = count == 56 ? 49 : count + 1;
                        break;
                    case Direction.正南:
                        count = count == 8 ? 1 : count + 1;
                        break;
                    case Direction.东南:
                        count = count == 48 ? 41 : count + 1;
                        break;
                    case Direction.西南:
                        count = count == 40 ? 33 : count + 1;
                        break;
                    case Direction.正西:
                        count = count == 16 ? 9 : count + 1;
                        break;
                    case Direction.正东:
                        count = count == 24 ? 17 : count + 1;
                        break;
                }
            }
            Sprite.Source = new BitmapImage((new Uri(@"Data\Player\MM_" + count + ".png", UriKind.Relative)));
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pPosition = e.GetPosition(Carrier);
            newp = new Point(pPosition.X - 75, pPosition.Y - 105);
            DeterMineDirection(newp);
            MoveTo(newp);
        }

        private void DeterMineDirection(Point newp)
        {
            var Sprite_X = Canvas.GetLeft(Sprite);
            var Sprite_Y = Canvas.GetTop(Sprite);
            var x = Math.Abs(Sprite_X - newp.X);
            var y = Math.Abs(Sprite_Y - newp.Y);
            var degree =  Math.Atan2(y, x) * 180 / Math.PI;
            if (newp.X > Sprite_X && newp.Y < Sprite_Y)
            {
                if (degree < 22.5)
                {
                    direction = Direction.正东;
                    count = 17;
                }
                else if (degree > 67.5)
                {
                    direction = Direction.正北;
                    count = 25;
                }
                else
                {
                    direction = Direction.东北;
                    count = 57;
                }
            }
            else if (newp.X < Sprite_X && newp.Y < Sprite_Y)
            {
                if (degree < 22.5)
                {
                    direction = Direction.正西;
                    count = 9;
                }
                else if (degree > 67.5)
                {
                    direction = Direction.正北;
                    count = 25;
                }
                else
                {
                    direction = Direction.西北;
                    count = 49;
                }
            }
            else if (newp.X > Sprite_X && newp.Y > Sprite_Y)
            {
                if (degree < 22.5)
                {
                    direction = Direction.正东;
                    count = 17;
                }
                else if (degree > 67.5)
                {
                    direction = Direction.正南;
                    count = 1;
                }
                else
                {
                    direction = Direction.东南;
                    count = 41;
                }
            }
            else if (newp.X < Sprite_X && newp.Y > Sprite_Y)
            {
                if (degree < 22.5)
                {
                    direction = Direction.正西;
                    count = 9;
                }
                else if (degree > 67.5)
                {
                    direction = Direction.正南;
                    count = 1;
                }
                else
                {
                    direction = Direction.西南;
                    count = 33;
                }
            }
            Sprite.Source = new BitmapImage((new Uri(@"Data\Player\MM_" + count + ".png", UriKind.Relative)));
        }

        private void MoveTo(Point p)
        {
            var Sprite_X = Canvas.GetLeft(Sprite);
            var Sprite_Y = Canvas.GetTop(Sprite);
            //速度
            var timeSpan = TimeSpan.FromMilliseconds(Math.Sqrt((Math.Pow(Math.Abs((Sprite_X - p.X)), 2) + Math.Pow(Math.Abs((Sprite_Y - p.Y)), 2))) / 200 * 1000);
            storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation(
                Canvas.GetLeft(Sprite),
                p.X,
                new Duration(timeSpan)
                );
            Storyboard.SetTarget(doubleAnimation, Sprite);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            doubleAnimation = new DoubleAnimation(
                Canvas.GetTop(Sprite),
                p.Y,
                new Duration(timeSpan)
                );
            Storyboard.SetTarget(doubleAnimation, Sprite);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Top)"));
            storyboard.Children.Add(doubleAnimation);

            if (!Resources.Contains("Move"))
            {
                Resources.Add("Move", storyboard);
            }
            storyboard.Begin();
        }
    }


    public enum Direction
    {
        正北,
        东北,
        西北,
        正南,
        东南,
        西南,
        正西,
        正东,
    }
    
}
