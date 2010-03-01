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
    public class Sprite : Canvas
    {
        public Vector2 nowVelocity, nowPosition;
        public Vector2 CenterOfCircle=new Vector2();//圆心
        public int Radius = 5;//半径

        public Sprite(Vector2 velocity, Vector2 position)
        {
            this.nowPosition = new Vector2();
            this.nowVelocity = new Vector2();
            this.nowVelocity = velocity;
            this.nowPosition = position;

            this.CalculateCofC();

        }

        //场景绘制
        public void Draw()
        {
            Canvas.SetLeft(this, nowPosition.X);
            Canvas.SetTop(this, nowPosition.Y);            
        }
        //更新数据
        public void Update()
        {
            this.nowPosition = CalculatePosition(this.nowPosition, this.nowVelocity);
            this.BoardCheck();
            this.CalculateCofC();
        }

        //计算小球目前的位置
        protected Vector2 CalculatePosition(Vector2 nowPosition, Vector2 nowVelocity)
        {
            return nowPosition + nowVelocity;
        }

        //检测精灵是否到达场景边境，如果到达场景边界，修改速度
        protected void BoardCheck()
        {
            if (this.Parent == null)
                return;
            if ((this.nowPosition.X < 0) || (this.nowPosition.X > (this.Parent as Canvas).Width - Radius * 2))
                this.nowVelocity.X = -this.nowVelocity.X;
            if ((this.nowPosition.Y < 0) || (this.nowPosition.Y > (this.Parent as Canvas).Height - Radius * 2))
                this.nowVelocity.Y = -this.nowVelocity.Y;
        }

        //计算当前圆心坐标
        protected void CalculateCofC()
        {
            CenterOfCircle.X = nowPosition.X + Radius;
            CenterOfCircle.Y = nowPosition.Y + Radius;
        }

        //通过判断2个圆是否相交进行碰撞检测，具体方法为：计算2个圆的圆心之间的长度，如果
        //该长度小于2个圆的半径和，则可判定2个圆相交，即发生了碰撞。
        //代码未考虑效率
        public bool CollisionCircle(Vector2 otherCoC)
        {
            if ( Vector2.Distance(this.CenterOfCircle,otherCoC) < Radius * 2)
                return true;
            else
                return false;
        }
    }
}
