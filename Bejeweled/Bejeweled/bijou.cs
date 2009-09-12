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
using System.Windows.Threading;

namespace Bejeweled
{
    public class bijou : Canvas
    {
        /// <summary>
        /// 图片路径
        /// </summary>
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

        private int _type;

        /// <summary>
        /// 宝石的类型
        /// </summary>
        public int Type 
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
                this.ImageSource = string.Format("Images/{0}/{0}_{1}.png", value, 1);
            }
        }
        /// <summary>
        /// 动画要用到的计时器
        /// </summary>
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        /// <summary>
        /// 当前播放的帧数,每秒20帧
        /// </summary>
        int count = 1;

        private int _column;
        /// <summary>
        /// 宝石所在的列
        /// </summary>
        public int Column
        {
            get
            {
                return this._column;
            }
            set
            {
                Grid.SetColumn(this, value);
                this._column = value;
            }
        }

        private int _row;
        /// <summary>
        /// 宝石所在的行
        /// </summary>
        public int Row
        {
            get
            {
                return this._row;
            }
            set
            {
                Grid.SetRow(this, value);
                this._row = value;
            }
        }
        /// <summary>
        /// 鼠标左键是否按下
        /// </summary>
        public bool isMouseLeftButtonDown { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="imageSource">图片路径</param>
        /// <param name="type">类型</param>
        /// <param name="column">列</param>
        /// <param name="row">行</param>
        public bijou(int type, int column, int row)
        {
            this.Type = type;
            this.Column = column;
            this.Row = row;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(bijou_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(bijou_MouseLeftButtonUp);
            this.MouseEnter += new MouseEventHandler(bijou_MouseEnter);
            this.MouseLeave += new MouseEventHandler(bijou_MouseLeave);
            isMouseLeftButtonDown = false;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(25);
        }

        /// <summary>
        /// 播放动画代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            var ISC = new ImageSourceConverter();
            ImageBrush IB = new ImageBrush();
            IB.ImageSource = (ImageSource)ISC.ConvertFromString(string.Format("Images/{0}/{0}_{1}.png", Type, count));
            this.Background = IB;
            count = count == 20 ? 1 : count + 1;
        }
        /// <summary>
        /// 构造一个空Bijou
        /// </summary>
        /// <param name="column">bijou所在的行</param>
        /// <param name="row">bijou所在的列</param>
        public bijou(int column, int row)
        {
            this.Column = column;
            this.Row = row;
            this.Type = 0;
        }

        /// <summary>
        /// 开始滚动动画
        /// </summary>
        void Roll()
        {
            dispatcherTimer.Start();
        }
        /// <summary>
        /// 停止滚动动画
        /// </summary>
        void RollStop()
        {
            dispatcherTimer.Stop();
            count = 1;
            this.Type = this.Type;
        }

        public void Hint()
        {
            Roll();
        }

        void bijou_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = false;
            this.ReleaseMouseCapture();
        }

        void bijou_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = true;
        }

        void bijou_MouseLeave(object sender, MouseEventArgs e)
        {
            RollStop();
        }

        void bijou_MouseEnter(object sender, MouseEventArgs e)
        {
            Roll();
        }

    }
}
