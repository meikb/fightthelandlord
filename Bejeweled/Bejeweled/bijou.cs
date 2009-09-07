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
        /// <summary>
        /// 宝石的类型
        /// </summary>
        public int Type { get; set; }

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

        public bijou(string imageSource, int type, int column, int row)
        {
            this.ImageSource = imageSource;
            this.Type = type;
            this.Column = column;
            this.Row = row;
            this.MouseLeftButtonDown += new MouseButtonEventHandler(bijou_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(bijou_MouseLeftButtonUp);
            isMouseLeftButtonDown = false;
        }

        void bijou_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = false;
        }

        void bijou_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isMouseLeftButtonDown = true;
        }

    }
}
