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
using System.IO;

namespace MoleAttack
{
    public partial class MainPage : UserControl
    {
        public static MainPage Instance;
        MouseSound msAttack;

        public MainPage()
        {
            InitializeComponent();
            MouseMove += new MouseEventHandler(MainPage_MouseMove);
            MouseLeftButtonDown += new MouseButtonEventHandler(MainPage_MouseLeftButtonDown);
            MouseLeftButtonUp += new MouseButtonEventHandler(MainPage_MouseLeftButtonUp);
            Cursor = Cursors.None;
            Instance = this;
            msAttack = new MouseSound("Sound/attack.mp3");
        }


        void MainPage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            monseCursor.sbMouseUp.Begin();
        }

        void MainPage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            monseCursor.sbClick.Begin();
            msAttack.Play();
        }

        void MainPage_MouseMove(object sender, MouseEventArgs e)
        {
            Point nowPoint = e.GetPosition(this);
            Canvas.SetLeft(monseCursor, nowPoint.X - 100);
            Canvas.SetTop(monseCursor, nowPoint.Y - 70);
        }
    }
}
