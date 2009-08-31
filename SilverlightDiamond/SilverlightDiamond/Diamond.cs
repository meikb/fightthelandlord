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

namespace SilverlightDiamond
{
    public class Diamond : Canvas
    {
        public string ImageSource
        {
            set
            {
                ImageSourceConverter ISC = new ImageSourceConverter();
                if (ISC.CanConvertFrom(value.GetType()))
                {
                    ImageBrush IB = new ImageBrush();
                    IB.ImageSource = (ImageSource)ISC.ConvertFromString(value);
                    this.Background = IB;
                }
            }
        }

        public int Column { get; set; }

        public int Row { get; set; }

        private bool isMouseLeftButtonDown;

        private Point mouseUpBeforePoint;

        public Direction direction { get; set; }

        public Diamond()
        {
            // Required to initialize variables
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Diamond_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(Diamond_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(Diamond_MouseMove);
            this.RenderTransform = new TranslateTransform();
        }

        void Diamond_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown)
            {
                Point mousePoint = e.GetPosition(null);
                double XCha = mousePoint.X - mouseUpBeforePoint.X;
                double YCha = mousePoint.Y - mouseUpBeforePoint.Y;
                #region 判断移动方向
                if (XCha > 20 && YCha < 20)
                {
                    if (Math.Abs(XCha) > Math.Abs(YCha))
                    {
                        this.direction = Direction.Right;
                    }
                    else
                    {
                        this.direction = Direction.Left;
                    }
                }
                else if (XCha > 20 && YCha > 20)
                {
                    if (Math.Abs(XCha) > Math.Abs(YCha))
                    {
                        this.direction = Direction.Right;
                    }
                    else
                    {
                        this.direction = Direction.Down;
                    }
                }
                else if (XCha < 20 && YCha > 20)
                {
                    if (Math.Abs(XCha) > Math.Abs(YCha))
                    {
                        this.direction = Direction.Left;
                    }
                    else
                    {
                        this.direction = Direction.Down;
                    }
                }
                else if (XCha < 20 && YCha < 20)
                {
                    if (Math.Abs(XCha) > Math.Abs(YCha))
                    {
                        this.direction = Direction.Left;
                    }
                    else
                    {
                        this.direction = Direction.Up;
                    }
                }
                #endregion


            }

        }

        void Diamond_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Diamond dia = sender as Diamond;
            dia.ReleaseMouseCapture();
            isMouseLeftButtonDown = false;
        }

        void Diamond_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Diamond dia = sender as Diamond;
            dia.CaptureMouse();
            isMouseLeftButtonDown = true;
            mouseUpBeforePoint = e.GetPosition(null);
        }

    }
    public enum Direction
    {
        Nothing = 1,
        Up = 2,
        Down = 3,
        Left = 4,
        Right = 5
    }
}
