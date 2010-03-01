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

namespace TwentySecond
{
    public class Vector2
    {
        private int x = 0, y = 0;

        public Vector2(int ValX, int ValY)
        {
            x = ValX;
            y = ValY;
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        //重载加法运算
        public static Vector2 operator +(Vector2 c1, Vector2 c2)
        {
            Vector2 tem = new Vector2(0, 0);
            tem.X = c1.X + c2.X;
            tem.Y = c1.Y + c2.Y;
            return tem;
        }
        //重载减法运算
        public static Vector2 operator -(Vector2 c1, Vector2 c2)
        {
            Vector2 tem = new Vector2(0, 0);
            tem.X = c1.X - c2.X;
            tem.Y = c1.Y - c2.Y;
            return tem;
        }

        //计算二维平面2个点的距离
        public static double Distance(Vector2 P1, Vector2 P2)
        {
            Vector2 tP1, tP2;
            tP1 = new Vector2();
            tP2 = new Vector2();
            tP1 = P1;
            tP2 = P2;
            double x;
            x = Math.Sqrt((double)((tP1.x - tP2.x) * (tP1.x - tP2.x) + (tP1.y - tP2.y) * (tP1.y - tP2.y)));
            return Math.Abs(x);
        }
    }
}
