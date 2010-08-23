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

namespace LeeGameEngine
{
    public class BaseObject : Canvas
    {
        /// <summary>
        /// 坐标X
        /// </summary>
        public virtual int X
        {
            get { return (int)Canvas.GetLeft(this); }
            set { Canvas.SetLeft(this, value); }
        }

        /// <summary>
        /// 坐标Y
        /// </summary>
        public virtual int Y
        {
            get { return (int)Canvas.GetTop(this); }
            set { Canvas.SetTop(this, value); }
        }



        /// <summary>
        /// 逻辑X,X跟CenterPoint.X计算后的结果
        /// </summary>
        public int LogicX
        {
            get
            {
                return X + (int)CenterPoint.X;
            }
            set
            {
                X = value - (int)CenterPoint.X;
            }
        }


        /// <summary>
        /// 逻辑Y,Y跟CenterPoint.Y计算后的结果
        /// </summary>
        public int LogicY
        {
            get
            {
                return Y + (int)CenterPoint.Y;
            }
            set
            {
                Y = value - (int)CenterPoint.Y;
            }
        }

        /// <summary>
        /// 中心点
        /// </summary>
        public Point CenterPoint { get; set; }

        /// <summary>
        /// 获取用于描述此基础对象的Rect
        /// </summary>
        /// <returns></returns>
        public virtual Rect GetRect()
        {
            return new Rect(this.X, this.Y, this.Width, this.Height);
        }
        /// <summary>
        /// 逻辑循环
        /// </summary>
        public virtual void OnFrame()
        {

        }

        public virtual void OnDraw()
        {
        }
    }
}
