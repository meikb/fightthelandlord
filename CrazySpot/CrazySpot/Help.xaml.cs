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

namespace CrazySpot
{
    public partial class Help : UserControl
    {
        public new double Width
        {
            get
            {
                return LayoutRoot.Width;
            }
        }

        public new double Height
        {
            get
            {
                return LayoutRoot.Height;
            }
        }
        public Help()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Storyboard1.Begin();
        }

        public void PlayAni()
        {
            Visibility = Visibility.Visible;
            Storyboard2.Begin();
        }

        private void Storyboard1_Completed(object sender, EventArgs e)
        {
            //Visibility= Visibility.Collapsed;
        }
    }
}

