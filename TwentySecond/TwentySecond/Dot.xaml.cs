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

namespace TwentySecond
{
    public partial class Dot : UserControl
    {
        public Dot()
        {
            InitializeComponent();
        }
        public double X
        {
            get { return (double)this.GetValue(Canvas.LeftProperty); }
            set { this.SetValue(Canvas.LeftProperty, value); }
        }

        public double Y
        {
            get { return (double)this.GetValue(Canvas.TopProperty); }
            set { this.SetValue(Canvas.TopProperty, value); }
        }

        public double vx { get; set; }
        public double vy { get; set; }

        public new double Width
        {
            get
            {
                return Star.Width;
            }
            set
            {
                Star.Width = value;
                LightH.Width = Star.Width / 3;
                LightH.SetValue(Canvas.LeftProperty, (double)Star.GetValue(Canvas.LeftProperty) + Star.Width / 2 - LightH.Width / 2);
                LightV.Width = Star.Width * 2.5;
                LightV.SetValue(Canvas.LeftProperty, (double)Star.GetValue(Canvas.LeftProperty) + Star.Width / 2 - LightV.Width / 2);
            }
        }

        public new double Height
        {
            get
            {
                return Star.Height;
            }
            set
            {
                Star.Height = value;
                LightH.Height = Star.Height * 2.5;
                LightH.SetValue(Canvas.TopProperty, (double)Star.GetValue(Canvas.TopProperty) + Star.Height / 2 - LightH.Height / 2);
                LightV.Height = Star.Height / 3;
                LightV.SetValue(Canvas.TopProperty, (double)Star.GetValue(Canvas.TopProperty) + Star.Height / 2 - LightV.Height / 2);
            }
        }
    }
}
