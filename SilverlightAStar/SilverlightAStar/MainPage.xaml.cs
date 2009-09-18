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

namespace SilverlightAStar
{
    public partial class MainPage : UserControl
    {
        public int GridSize = 50;

        private int MaxColumn = 16;

        private int MaxRow = 12;

        public byte[,] Matrix;

        private List<Point> changedNotes = new List<Point>();

        private bool isMouseLeftButtonDown;

        private Point StartPoint;

        private Point EndPoint;

        private byte MouseState;  //0表示障碍物,1表示开始点,2表示结束点

        public MainPage()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            MaxColumn = (int)this.LayoutRoot.Width / GridSize;
            MaxRow = (int)this.LayoutRoot.Height / GridSize;
            Matrix = new byte[MaxColumn, MaxRow];
            for (int i = MaxColumn; i >= 0; i--)
            {
                var line = new Line() { X1 = i * GridSize, Y1 = 0, X2 = i * GridSize, Y2 = MaxRow * GridSize };
                line.Stroke = new SolidColorBrush(Colors.White);
                LayoutRoot.Children.Add(line);
            }
            for (int j = MaxRow; j >= 0; j--)
            {
                var line = new Line() { X1 = 0, Y1 = j * GridSize, X2 = MaxColumn * GridSize, Y2 = j * GridSize };
                line.Stroke = new SolidColorBrush(Colors.White);
                LayoutRoot.Children.Add(line);
            }
        }

        private void AddRectangle(Color color, int column, int row)
        {
            var rect = new Rectangle() { Width = GridSize, Height = GridSize, Fill = new SolidColorBrush(color) };
            Canvas.SetLeft(rect, column * GridSize);
            Canvas.SetTop(rect, row * GridSize);
            this.LayoutRoot.Children.Add(rect);
        }

        private void RemoveRectangleByColor(Color color)
        {
            Rectangle removeRect = null;
            foreach (var startPoint in this.LayoutRoot.Children)
            {
                if (startPoint.GetType() == typeof(Rectangle))
                {
                    var startRect = startPoint as Rectangle;
                    var scb = (SolidColorBrush)startRect.Fill;
                    if (scb.Color.Equals(color))
                    {
                        removeRect = startRect;
                        break;
                    }
                }
            }
            if (removeRect != null)
            {
                var point = GetPointByUIElement(removeRect);
                this.LayoutRoot.Children.Remove(removeRect);
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

        private void LayoutRoot_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == this.LayoutRoot)
            {
                this.LayoutRoot.CaptureMouse();
                this.isMouseLeftButtonDown = true;
                var mousePoint = GetPointByPoint(e.GetPosition(this.LayoutRoot));
                if (MouseState == 1)
                {
                    SetStartPoint((int)mousePoint.X, (int)mousePoint.Y);
                    return;
                }
                if (MouseState == 2)
                {
                    SetEndPoint((int)mousePoint.X, (int)mousePoint.Y);
                    return;
                }
                ChangeNote((int)mousePoint.X, (int)mousePoint.Y);
                changedNotes.Add(mousePoint);
            }
        }

        private void LayoutRoot_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (sender == this.LayoutRoot)
            {
                this.isMouseLeftButtonDown = false;
                this.changedNotes.Clear();
            }
        }

        private void LayoutRoot_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender == this.LayoutRoot)
            {
                var mousePoint = GetPointByPoint(e.GetPosition(this.LayoutRoot));
                if (isMouseLeftButtonDown)
                {
                    if (MouseState == 1)
                    {
                        SetStartPoint((int)mousePoint.X, (int)mousePoint.Y);
                        return;
                    }
                    if (MouseState == 2)
                    {
                        SetEndPoint((int)mousePoint.X, (int)mousePoint.Y);
                        return;
                    }
                    bool isChanged = false;
                    int column = (int)mousePoint.X;
                    int row = (int)mousePoint.Y;
                    foreach (var changedNote in changedNotes)
                    {
                        if (changedNote.X == column && changedNote.Y == row)
                        {
                            isChanged = true;
                        }
                        else
                        {
                            isChanged = false;
                        }
                    }
                    if (!isChanged)
                    {
                        ChangeNote(column, row);
                        changedNotes.Add(new Point(column, row));
                    }
                }
            }
        }

        private void ChangeNote(int column, int row)
        {
            if (Matrix[column, row] == 0)
            {
                Matrix[column, row] = 1;
                AddRectangle(Colors.Green, column, row);
            }
            else
            {
                Matrix[column, row] = 0;
                List<Rectangle> removeRect = new List<Rectangle>();
                foreach (var uielement in this.LayoutRoot.Children)
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
                    this.LayoutRoot.Children.Remove(rect);
                }
            }
        }

        private void btnStartPoint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.MouseState = 1;
        }

        private void btnEndPoint_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.MouseState = 2;
        }

        private void btnImpediment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.MouseState = 0;
        }

        private void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridSize = Convert.ToInt32(tbGridSize.Text);
            var lines = new List<Line>(); 
            foreach (var uie in this.LayoutRoot.Children)
            {
                if (uie.GetType() == typeof(Line))
                {
                    lines.Add((Line)uie);
                }
            }
            foreach (var line in lines)
            {
                this.LayoutRoot.Children.Remove(line);
            }
            Init();
        }

        private void btnStartFindPath_Click(object sender, RoutedEventArgs e)
        {
            var pathFinder = new PathFinder(Matrix, StartPoint, EndPoint);
            var time1 = DateTime.Now;
            var pathPoints = pathFinder.StartFindPath();
            var time2 = DateTime.Now;
            foreach (var p in pathPoints)
            {
                AddRectangle(Colors.Yellow, (int)p.X, (int)p.Y);
            }
            MessageBox.Show((time2 - time1).Milliseconds);
        }

    }
}
