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

namespace CrazySpot
{
    public partial class Login : UserControl
    {
        private static Login _instance;

        public static Login Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Login();
                return _instance;
            }
        }

        public Login()
        {
            InitializeComponent();
        }

        private void textBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard1.Begin();
        }

        private void textBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard4.Begin();
        }

        private void textBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Instance.SetGameState(GameState.GameStart);
        }

        private void textBlock1_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard2.Begin();
        }

        private void textBlock1_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard5.Begin();
        }

        private void textBlock1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainPage.Instance.SetGameState(GameState.Help);
        }

        private void textBlock2_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard3.Begin();
        }

        private void textBlock2_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard6.Begin();
        }

        private void textBlock2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Page.currentState = GameState.Stop;
        }

        private void stackPanel_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard7.Begin();
        }

        private void stackPanel_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard8.Begin();
        }

        private void textBlock3_MouseEnter(object sender, MouseEventArgs e)
        {
            Storyboard9.Begin();
        }

        private void textBlock3_MouseLeave(object sender, MouseEventArgs e)
        {
            Storyboard10.Begin();
        }
    }
}

