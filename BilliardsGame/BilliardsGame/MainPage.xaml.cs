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

        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            _gameLoop = new DispatcherTimer();
            _gameLoop.Interval = TimeSpan.FromMilliseconds(1000 / 60);
            _gameLoop.Tick += new EventHandler(OnGameLoop);
            _gameLoop.Start();
        }

        void OnGameLoop(object sender, EventArgs e)
        {
        }
    }
}
