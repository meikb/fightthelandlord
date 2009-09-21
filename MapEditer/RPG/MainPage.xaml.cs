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
using PathFinderSpace;
using System.Windows.Media.Imaging;

namespace RPG
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            Init();
        }
        public int GridSize = 20;

        private int MaxColumn;

        private int MaxRow;

        public byte[,] Matrix;

        private byte[,] beforeEditMatrix;

        /// <summary>
        /// 鼠标是否处于按下状态
        /// </summary>
        private bool isMouseLeftButtonDown;

        /// <summary>
        /// 起点
        /// </summary>
        private Point StartPoint;

        /// <summary>
        /// 终点
        /// </summary>
        private Point EndPoint;

        /// <summary>
        /// 鼠标状态,0表示障碍物,1表示开始点,2表示结束点
        /// </summary>
        private byte MouseState;

        /// <summary>
        /// 区域选中状态下鼠标起始点
        /// </summary>
        private Point MouseStartPoint;

        /// <summary>
        /// 是否可以走斜线
        /// </summary>
        private bool diagonals;

        /// <summary>
        /// 当前编辑地图
        /// </summary>
        private Map _map;

        /// <summary>
        /// 当前编辑地图
        /// </summary>
        private Map Map
        {
            get
            {
                return _map;
            }
            set
            {
                this._map = value;
                this.GameMain.Width = value.Width;
                this.GameMain.Height = value.Height;
                Init();
                Canvas.SetZIndex(value.MapImage, -1);
                this.GameMain.Children.Add(value.MapImage);
                if (value.Matrix != null)
                    this.Matrix = value.Matrix;
            }
        }
        private void Init()
        {
            this.GameMain.Children.Clear();
            MaxColumn = (int)this.GameMain.Width / 20;
            MaxRow = (int)this.GameMain.Height / 20;
            Matrix = new byte[MaxColumn, MaxRow];
        }
        private void RePaintLine()
        {
            RemoveAllLine();
            for (int i = MaxColumn; i >= 0; i--)
            {
                var line = new Line() { X1 = i * GridSize, Y1 = 0, X2 = i * GridSize, Y2 = MaxRow * GridSize };
                line.Stroke = new SolidColorBrush(Colors.Black);
                GameMain.Children.Add(line);
            }
            for (int j = MaxRow; j >= 0; j--)
            {
                var line = new Line() { X1 = 0, Y1 = j * GridSize, X2 = MaxColumn * GridSize, Y2 = j * GridSize };
                line.Stroke = new SolidColorBrush(Colors.Black);
                GameMain.Children.Add(line);
            }
        }

        private void AddRectangle(Color color, int column, int row)
        {
            RemoveRectangleByPostion(column, row);
            var rect = new Rectangle() { Width = GridSize, Height = GridSize, Opacity = 0.5, Fill = new SolidColorBrush(color) };
            Canvas.SetLeft(rect, column * GridSize);
            Canvas.SetTop(rect, row * GridSize);
            this.GameMain.Children.Add(rect);
        }

        private void RemoveAllLine()
        {
            var uies = new List<UIElement>();
            foreach (var uie in this.GameMain.Children)
            {
                if (uie.GetType() == typeof(Line))
                {
                    uies.Add((UIElement)uie);
                }
            }
            foreach (var uie in uies)
            {
                this.GameMain.Children.Remove(uie);
            }
        }

        private void RemoveAllRectangle()
        {
            var uies = new List<UIElement>();
            foreach (var uie in this.GameMain.Children)
            {
                if (uie.GetType() == typeof(Rectangle))
                {
                    uies.Add((UIElement)uie);
                }
            }
            foreach (var uie in uies)
            {
                this.GameMain.Children.Remove(uie);
            }
        }

        private void RemoveRectangleByPostion(int column, int row)
        {
            List<Rectangle> removeRect = new List<Rectangle>();
            foreach (var uielement in this.GameMain.Children)
            {
                if (uielement.GetType() == typeof(System.Windows.Shapes.Rectangle))
                {
                    var rect = uielement as Rectangle;
                    var point = GetPointByUIElement(rect);
                    if (point.X == column && point.Y == row)
                    {
                        removeRect.Add(rect);
                    }
                }
            }
            foreach (var rect in removeRect)
            {
                this.GameMain.Children.Remove(rect);
            }
        }

        private void RemoveRectangleByColor(Color color)
        {
            var rects = new List<Rectangle>();
            foreach (var uie in this.GameMain.Children)
            {
                if (uie.GetType() == typeof(Rectangle))
                {
                    var startRect = uie as Rectangle;
                    var scb = (SolidColorBrush)startRect.Fill;
                    if (scb.Color.Equals(color))
                    {
                        rects.Add(startRect);
                    }
                }
            }
            foreach (var rect in rects)
            {
                this.GameMain.Children.Remove(rect);
            }
        }

        private Point GetPointByUIElement(UIElement uie)
        {
            int column = (int)Canvas.GetLeft(uie) / GridSize;
            int row = (int)Canvas.GetTop(uie) / GridSize;
            return new Point(column, row);
        }

        private Point GetPointByPoint(Point p)
        {
            var newPoint = new Point();
            newPoint.X = (int)p.X / GridSize;
            newPoint.Y = (int)p.Y / GridSize;
            return newPoint;
        }

        private void SetStartPoint(int column, int row)
        {
            RemoveRectangleByColor(Colors.Blue);
            AddRectangle(Colors.Blue, column, row);
            this.StartPoint = new Point(column, row);
        }

        private void SetEndPoint(int column, int row)
        {
            RemoveRectangleByColor(Colors.Red);
            AddRectangle(Colors.Red, column, row);
            this.EndPoint = new Point(column, row);
        }

        private void GameMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void GameMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void GameMain_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void btnStartFindPath_Click(object sender, RoutedEventArgs e)
        {
            RemoveRectangleByColor(Colors.Yellow);
            var pathFinder = new PathFinder(Matrix, StartPoint, EndPoint, diagonals);
            var time1 = DateTime.Now;
            var pathPoints = pathFinder.StartFindPath();
            var time2 = DateTime.Now;
            if (pathPoints == null)
            {
                MessageBox.Show("找不到路径");
                return;
            }
            foreach (var p in pathPoints)
            {
                AddRectangle(Colors.Yellow, (int)p.X, (int)p.Y);
            }
        }

        private void Clear()
        {
            var uies = new List<UIElement>();
            foreach (var uie in this.GameMain.Children)
            {
                if (uie.GetType() == typeof(Line) || uie.GetType() == typeof(Rectangle))
                {
                    uies.Add((UIElement)uie);
                }
            }
            foreach (var uie in uies)
            {
                this.GameMain.Children.Remove(uie);
            }
        }

        private Image GetImageByPath(string imagePath)
        {
            var bitmapImage = new BitmapImage(new Uri(imagePath));
            var image = new Image();
            image.Source = bitmapImage;
            return image;
        }

        private void RefreshMatrix()
        {
            for (int x = 0; x < MaxColumn; x++)
            {
                for (int y = 0; y < MaxRow; y++)
                {
                    if (this.Matrix[x, y] == 1)
                    {
                        AddRectangle(Colors.Green, x, y);
                    }
                }
            }
        }

        private void UpDateRectangle()
        {
            RemoveAllRectangle();
            RefreshMatrix();
        }
    }
}
