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
    public class Vector2 : BilliardsGame.IVector2
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Vector2 Clone()
        {
            return new Vector2(this.X, this.Y);
        }

        public static Vector2 operator +(Vector2 leftV2, Vector2 rightV2)
        {
            Vector2 newV2 = new Vector2();
            newV2.X = leftV2.X + rightV2.X;
            newV2.Y = leftV2.Y + rightV2.Y;
            return newV2;
        }

        public static Vector2 operator -(Vector2 leftV2, Vector2 rightV2)
        {
            Vector2 newV2 = new Vector2();
            newV2.X = leftV2.X - rightV2.X;
            newV2.Y = leftV2.Y - rightV2.Y;
            return newV2;
        }

        public static double Distance(Vector2 p1, Vector2 p2)
        {
            Vector2 v1 = p1.Clone();
            Vector2 v2 = p1.Clone();
            double distance = Math.Sqrt((double)(v1.X - v2.X) * (v1.X - v2.X) + (v1.Y - v2.Y) * (v1.Y - v2.Y));
            return Math.Abs(distance);
        }
    }
}
