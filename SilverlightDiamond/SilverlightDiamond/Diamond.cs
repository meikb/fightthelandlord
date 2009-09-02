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

        public bool isMouseLeftButtonDown
        {
            get
            {
                return _isMouseLeftButtonDown;
            }
            set
            {
                _isMouseLeftButtonDown = value;
            }
        }

        private bool _isMouseLeftButtonDown;

        private Point mouseUpBeforePoint;

        private Action<Diamond> callBack;

        public int Type { get; set; }

        public int Column { get; set; }

        public int Row { get; set; }

        public Direction direction { get; set; }

        public Diamond(string ImagePath, int Column, int Row, int Type)
        {
            // Required to initialize variables
            this.MouseLeftButtonDown += new MouseButtonEventHandler(Diamond_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(Diamond_MouseLeftButtonUp);
            this.MouseMove += new MouseEventHandler(Diamond_MouseMove);
            this.RenderTransform = new TranslateTransform();
            this.direction = Direction.Nothing;

            this.ImageSource = ImagePath;
            this.Column = Column;
            this.Row = Row;
            this.Type = Type;

            Storyboard sb = new Storyboard();
            sb.Children.Add(new DoubleAnimation());
            Resources.Add("sb", sb);
        }

        void Diamond_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown)
            {
                Point mousePoint = e.GetPosition(null);
                double XCha = mousePoint.X - mouseUpBeforePoint.X;
                double YCha = mousePoint.Y - mouseUpBeforePoint.Y;
                double absXCha = Math.Abs(XCha);
                double absYCha = Math.Abs(YCha);
                #region 判断移动方向
                if (absXCha > 20 || absYCha > 20)
                {
                    if (XCha > 20 && YCha < 20)
                    {
                        if (absXCha > absYCha)
                        {
                            this.direction = Direction.Right;
                        }
                        else
                        {
                            this.direction = Direction.Up;
                        }
                    }
                    else if (XCha > 20 && YCha > 20)
                    {
                        if (absXCha > absYCha)
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
                        if (absXCha > absYCha)
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
                        if (absXCha > absYCha)
                        {
                            this.direction = Direction.Left;
                        }
                        else
                        {
                            this.direction = Direction.Up;
                        }
                    }
                }
                else
                {
                    this.direction = Direction.Nothing;
                }
                #endregion
            }

        }

        void Diamond_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Diamond dia = sender as Diamond;
            dia.ReleaseMouseCapture();
            isMouseLeftButtonDown = false;
            //this.direction = Direction.Nothing;
        }

        void Diamond_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Diamond dia = sender as Diamond;
            dia.CaptureMouse();
            isMouseLeftButtonDown = true;
            mouseUpBeforePoint = e.GetPosition(null);
        }

        public void Disponse(Action<Diamond> callback)
        {
            PlayAnimation();
            this.callBack = callback;
        }

        void PlayAnimation()
        {
            Storyboard sb = (Storyboard)Resources["sb"];
            DoubleAnimation da = (DoubleAnimation)sb.Children[0];
            try
            {
                Storyboard.SetTarget(da, this);
                Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            }
            catch
            {
            }
            da.To = 0;
            da.Duration = new Duration(TimeSpan.FromMilliseconds(300.0));
            sb.Completed += sb_Completed;
            sb.Begin();
        }

        void sb_Completed(object sender, EventArgs e)
        {
            var sb = sender as Storyboard;
            sb.Completed -= sb_Completed;
            sb.Stop();
            this.callBack(this);
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
