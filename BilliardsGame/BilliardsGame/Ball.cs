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
    public class Ball : Canvas, IVector2
    {
        public double X
        {
            get
            {
                return Canvas.GetLeft(this);
            }
            set
            {
                _vector2.X = value;
                Canvas.SetLeft(this, value);
            }
        }

        public double Y
        {
            get
            {
                return Canvas.GetTop(this);
            }
            set
            {
                _vector2.Y = value;
                Canvas.SetTop(this, value);
            }
        }

        private Vector2 _vector2;

        public Ball()
        {
            _vector2 = new Vector2(0, 0);
        }

        public Ball(double x, double y)
        {
            _vector2 = new Vector2(x, y);
            X = x;
            Y = y;
        }
    }
}
