using System;
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
	public partial class Diamond : UserControl
	{
        public int Column { get; set; }

        public int Row { get; set; }

        private bool isMouseLeftButtonDown;

        private Point mouseUpBeforePoint;

        public Direction direction { get; set; }

        public Diamond()
        {
            // Required to initialize variables
            InitializeComponent();
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
            isMouseLeftButtonDown = false;
        }

        void Diamond_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = true;
            mouseUpBeforePoint = e.GetPosition(null);
        }

        public bool SetImageSource(string ImagePath)
        {
            ImageSourceConverter ISC = new ImageSourceConverter();
            if (ISC.CanConvertFrom(ImagePath.GetType()))
            {
                Image.ImageSource = (ImageSource)ISC.ConvertFrom(ImagePath);
                return true;
            }
            else
            {
                return false;
            }
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