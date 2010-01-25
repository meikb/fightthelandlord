using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace BilliardsGame
{
    public class Ball : Canvas
    {
        public double X
        {
            get
            {
                return CenterOfCircle.X;
            }
            set
            {
                CenterOfCircle.X = value;
            }
        }

        public double Y
        {
            get
            {
                return CenterOfCircle.Y;
            }
            set
            {
                CenterOfCircle.Y = value;
            }
        }

        public const double Radius = 10;

        public Vector2 CenterOfCircle { get; set; }

        public Vector2 Velocity { get; set; }

        public Ball()
        {
            CenterOfCircle = new Vector2(100, 100);
            InitBall();
        }

        private void InitBall()
        {
            this.Children.Add(new Ellipse() { Width = Radius * 2, Height = Radius * 2, Fill = new SolidColorBrush(Colors.Black) });
        }

        public Ball(double x, double y)
        {
            CenterOfCircle = new Vector2(x, y);
        }

        public void Draw()
        {
            Canvas.SetLeft(this, CenterOfCircle.X - Radius);
            Canvas.SetTop(this, CenterOfCircle.Y - Radius);
        }

        public void Update()
        {
            this.Velocity.X *= GlobalVar.friction;
            this.Velocity.Y *= GlobalVar.friction;
            this.CenterOfCircle = CalCulatePosition();
            this.BoardCheck();
        }

        private void BoardCheck()
        {
            if (CenterOfCircle.X - Radius <= 0 || CenterOfCircle.X + Radius >= GlobalVar.Width)
            {
                Velocity.X = -Velocity.X;
            }
            if (CenterOfCircle.Y - Radius <= 0 || CenterOfCircle.Y + Radius >= GlobalVar.Height)
            {
                Velocity.Y = -Velocity.Y;
            }
        }

        private Vector2 CalCulatePosition()
        {
            return this.CenterOfCircle + this.Velocity;
        }
    }
}
