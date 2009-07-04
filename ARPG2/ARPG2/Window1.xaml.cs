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
            var textblock = new TextBlock { Text = (Math.Atan2(50, 100)*180/Math.PI).ToString() };
            Canvas.SetTop(textblock, 200);
            Carrier.Children.Add(textblock);
        }

        void dispatherTimer_Tick(object sender, EventArgs e)
        {
            if (newp.X == Canvas.GetLeft(Sprite) && newp.Y == Canvas.GetTop(Sprite))
            {
                count = 4;
            }
            else
            {
                count = count == 8 ? 1 : count + 1;
            }
            Sprite.Source = new BitmapImage((new Uri(@"Data\Player\Player_" + count + ".png", UriKind.Relative)));
        }

        private void Carrier_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Point pPosition = e.GetPosition(Carrier);
            newp = new Point(pPosition.X - 75, pPosition.Y - 105);
            MoveTo(newp);
        }

        private void MoveTo(Point p)
        {
            storyboard = new Storyboard();
            DoubleAnimation doubleAnimation = new DoubleAnimation(
                Canvas.GetLeft(Sprite),
                p.X,
                new Duration(TimeSpan.FromSeconds(1))
                );
            Storyboard.SetTarget(doubleAnimation, Sprite);
            Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("(Canvas.Left)"));
            storyboard.Children.Add(doubleAnimation);

            doubleAnimation = new DoubleAnimation(
                Canvas.GetTop(Sprite),
                p.Y,
                new Duration(TimeSpan.FromSeconds(1))
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

        private 
    }
}
