using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PathFinderSpace;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MapEditer
{
    /// <summary>
    /// MapEditer.xaml 的交互逻辑
    /// </summary>
    public partial class MapEditerForm : Window
    {
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
        /// 是否为删除状态
        /// </summary>
        private bool RemoveImpediment;

        /// <summary>
        /// 是否为区域选中状态
        /// </summary>
        private bool AreaSelect;

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

        public MapEditerForm()
        {
            InitializeComponent();
            Init();
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
            this.GameMain.CaptureMouse();
            var truePoint = e.GetPosition(this.GameMain);
            var mousePoint = GetPointByPoint(truePoint);
            if (truePoint.X <= this.GameMain.Width && truePoint.Y <= this.GameMain.Height)
            {
                this.isMouseLeftButtonDown = true;
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
                if (AreaSelect)
                {
                    this.MouseStartPoint = mousePoint;
                    return;
                }
                ChangeNote((int)mousePoint.X, (int)mousePoint.Y, RemoveImpediment);
            }
        }

        private void GameMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.GameMain.ReleaseMouseCapture();
            var truePoint = e.GetPosition(this.GameMain);
            var mousePoint = GetPointByPoint(truePoint);
            if (truePoint.X <= this.GameMain.Width && truePoint.Y <= this.GameMain.Height)
            {
                this.isMouseLeftButtonDown = false;
                if (AreaSelect)
                {
                    for (int x = (int)MouseStartPoint.X; x < mousePoint.X; x++)
                    {
                        for (int y = (int)MouseStartPoint.Y; y < mousePoint.Y; y++)
                        {
                            ChangeNote(x, y, RemoveImpediment);
                        }
                    }
                    return;
                }
            }
        }

        private void GameMain_MouseMove(object sender, MouseEventArgs e)
        {
            var truePoint = e.GetPosition(this.GameMain);
            var mousePoint = GetPointByPoint(truePoint);
            if (truePoint.X <= this.GameMain.Width && truePoint.Y <= this.GameMain.Height)
            {
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
                    if (MouseState == 0 && !AreaSelect)
                    {
                        ChangeNote((int)mousePoint.X, (int)mousePoint.Y, RemoveImpediment);
                    }
                }
            }
        }

        private void ChangeNote(int column, int row, bool removeImpediment)
        {
            try
            {
                if (removeImpediment)
                {
                    RemoveRectangleByPostion(column, row);
                    Matrix[column, row] = 0;
                }
                else
                {
                    Matrix[column, row] = 1;
                    AddRectangle(Colors.Green, column, row);
                }
            }
            catch (IndexOutOfRangeException iofre)
            {
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
            this.RemoveImpediment = false;
        }

        private void btnUpdate_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tbGridSize.Text.Trim() != "")
            {
                try
                {
                    this.GridSize = int.Parse(tbGridSize.Text.Trim());
                }
                catch
                {
                }
            }
            Clear();
            Init();
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
            tbTim.Text = (time2 - time1).ToString();
        }

        private void btnClear_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clear();
            Init();
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

        private void cbDiagonals_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.diagonals = true;
        }

        private void cbDiagonals_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.diagonals = false;
        }

        private void OpenMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenMap();
            RefreshMatrix();
        }

        private void NewMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Clear();
        }

        private void SaveMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.Map != null)
            {
                SaveMap();
            }
        }

        private void OpenImageMenuItem_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OpenImage();
        }

        private void OpenImage()
        {
            var openFile = new OpenFileDialog();
            openFile.Title = "打开PNG文件";
            openFile.Filter = "PNG文件(*.PNG)|*.PNG"; 
            if ((bool)openFile.ShowDialog())
            {
                var bitmapImage = new BitmapImage(new Uri(openFile.FileName));
                var imageMap = new Image();
                imageMap.Source = bitmapImage;
                this.Map = new Map(imageMap, bitmapImage.Width, bitmapImage.Height, openFile.SafeFileName);
                this.Map.Matrix = this.Matrix;
                RePaintLine();
            }
        }

        private Image GetImageByPath(string imagePath)
        {
            var bitmapImage = new BitmapImage(new Uri(imagePath));
            var image = new Image();
            image.Source = bitmapImage;
            return image;
        }

        private void OpenMap()
        {
            if (CheckMatrixVal())
            {
                var res = MessageBox.Show("地图已被修改,是否保存", "提示", MessageBoxButton.YesNo);
                if (res == MessageBoxResult.Yes)
                {
                    SaveMap();
                }
            }
            var openFile = new OpenFileDialog();
            openFile.Title = "打开地图文件";
            openFile.Filter = "Map文件(*.map)|*.map"; 
            if ((bool)openFile.ShowDialog())
            {
                var fileStream = new FileStream(openFile.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                var readedMap = (Map)bf.Deserialize(fileStream);
                var directoryPath = openFile.FileName.Replace(openFile.SafeFileName, "");
                readedMap.Directory = directoryPath;
                readedMap.MapImage = GetImageByPath(readedMap.Directory + readedMap.ImageFileName);
                this.Map = readedMap;
                fileStream.Close();
                GridSize = 20;
                this.beforeEditMatrix = this.Matrix;
                RePaintLine();
            }
        }

        private void SaveMap()
        {
                var binaryFormatter = new BinaryFormatter();
                var fs = new FileStream(Map.Directory + Map.ImageFileName + ".map", FileMode.Create, FileAccess.Write);
                binaryFormatter.Serialize(fs, this.Map);
                fs.Close();
        }

        /// <summary>
        /// 检测matrix是否已被修改
        /// </summary>
        /// <returns>是否已被修改</returns>
        private bool CheckMatrixVal()
        {
            if (beforeEditMatrix == null)
            {
                return false;
            }
            else
            {
                for (int x = 0; x < MaxColumn; x++)
                {
                    for (int y = 0; y < MaxRow; y++)
                    {
                        if (Matrix[x, y] != beforeEditMatrix[x, y])
                        {
                            return true;
                        }
                    }
                }
            }
            foreach (var i in Matrix)
            {
                if (i != 0)
                {
                    return true;
                }
            }
            return false;
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

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)e.AddedItems[0];
            if ((string)selectedItem.Content == "100%")
            {
                SetScaleTransform(1F);
            }
            if ((string)selectedItem.Content == "75%")
            {
                SetScaleTransform(0.75F);
            }
            if ((string)selectedItem.Content == "50%")
            {
                SetScaleTransform(0.5F);
            }
            if ((string)selectedItem.Content == "25%")
            {
                SetScaleTransform(0.25F);
            }
            RePaintLine();
            RefreshMatrix();
        }

        private void SetScaleTransform(float i)
        {
            if (i <= 1F)
            {
                GridSize = (int)(20.0F * i);
                Map.MapImage.Width = Map.Width * i;
                Map.MapImage.Height = Map.Height * i;
                this.GameMain.Width = Map.Width * i;
                this.GameMain.Height = Map.Height * i;
                UpDateRectangle();
            }
        }

        private void UpDateRectangle()
        {
            RemoveAllRectangle();
            RefreshMatrix();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.svPanel.Width = e.NewSize.Width - 212;
            this.svPanel.Height = e.NewSize.Height - 100;
            Canvas.SetLeft(this.caControls, 798 + e.NewSize.Width - 1010);
        }

        private void btnRemoveImpediment_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.RemoveImpediment = true;
        }

        private void btnSetArea_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AreaSelect = true;
        }

        private void btnSingle_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AreaSelect = false;
        }
    }
}
