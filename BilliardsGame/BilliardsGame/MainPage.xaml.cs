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

namespace BilliardsGame
{
    public partial class MainPage : UserControl
    {
        private DispatcherTimer _gameLoop;
        Ball oneBall;
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
            MouseLeftButtonDown += new MouseButtonEventHandler(MainPage_MouseLeftButtonDown);
        }

        void MainPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Vector2 moment = oneBall.CenterOfCircle - new Vector2(e.GetPosition(null).X, e.GetPosition(null).Y);
            oneBall.Velocity = moment;
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _gameLoop = new DispatcherTimer();
            _gameLoop.Interval = new TimeSpan(0, 0, 0, 0);
            _gameLoop.Tick += new EventHandler(OnGameLoop);
            _gameLoop.Start();
            oneBall = new Ball();
            this.LayoutRoot.Children.Add(oneBall);
            oneBall.Velocity = new Vector2(1, 8);

        }

        void OnGameLoop(object sender, EventArgs e)
        {
            oneBall.Update();
            oneBall.Draw();
        }
    }
}
