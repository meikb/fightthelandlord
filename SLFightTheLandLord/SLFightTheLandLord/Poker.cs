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
using System.Windows.Media.Imaging;

namespace SLFightTheLandLord
{
    public class Poker
    {
        /// <summary>
        /// 扑克牌的值
        /// </summary>
        private PokerNum _pokerNum;
        /// <summary>
        /// 扑克牌的花色
        /// </summary>
        private PokerColor _pokerColor;

        /// <summary>
        /// 扑克牌图像
        /// </summary>
        private Image _pokerImage = new Image();

        /// <summary>
        /// 标记
        /// </summary>
        public bool Tag { get; set; }

        /// <summary>
        /// 鼠标左键是否按下
        /// </summary>
        private bool isMouseLeftButtonDown;

        /// <summary>
        /// 是否是已出牌
        /// </summary>
        public bool IsLeaded { get; set; }

        /// <summary>
        /// 扑克牌的值
        /// </summary>
        public PokerNum pokerNum
        {
            get
            {
                return this._pokerNum;
            }
            set
            {
                this._pokerNum = value;
            }
        }

        public Image PokerImage
        {
            get
            {
                return this._pokerImage;
            }
        }

        /// <summary>
        /// 扑克牌的花色
        /// </summary>
        public PokerColor pokerColor
        {
            get
            {
                return this._pokerColor;
            }
            set
            {
                this._pokerColor = value;
            }
        }

        public Poker(PokerNum pokerNum, PokerColor pokerColor)
        {
            this.pokerNum = pokerNum;
            this.pokerColor = pokerColor;
            InitPokerImage();
        }

        private bool _isSelected;

        /// <summary>
        /// 是否被选中
        /// </summary>
        public bool IsSelected
        {
            get
            {
                 return this._isSelected;
            }
            set
            {
                if (StaticVar.DealComplete)
                {
                    this._isSelected = value;
                    this.PokerImage.Tag = value;
                }
            }
        }

        /// <summary>
        /// 初始化扑克显示图像
        /// </summary>
        private void InitPokerImage()
        {
            switch (this.pokerColor)
            {
                case PokerColor.黑桃:
                    if (this.pokerNum == PokerNum.A)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/1.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.P2)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/2.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.大王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterA.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.小王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterB.png", UriKind.Relative));
                    }
                    else
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri(string.Format("PokerImage/{0}.png", (int)this._pokerNum), UriKind.Relative));
                    }
                    break;
                case PokerColor.红心:
                    if (this.pokerNum == PokerNum.A)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/14.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.P2)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/15.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.大王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterA.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.小王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterB.png", UriKind.Relative));
                    }
                    else
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri(string.Format("PokerImage/{0}.png", (int)this._pokerNum + 13), UriKind.Relative));
                    }
                    break;
                case PokerColor.梅花:
                    if (this.pokerNum == PokerNum.A)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/27.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.P2)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/28.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.大王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterA.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.小王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterB.png", UriKind.Relative));
                    }
                    else
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri(string.Format("PokerImage/{0}.png", (int)this._pokerNum + 26), UriKind.Relative));
                    }
                    break;
                case PokerColor.方块:
                    if (this.pokerNum == PokerNum.A)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/40.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.P2)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/41.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.大王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterA.png", UriKind.Relative));
                    }
                    else if (this.pokerNum == PokerNum.小王)
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri("PokerImage/JesterB.png", UriKind.Relative));
                    }
                    else
                    {
                        this._pokerImage.Source = new BitmapImage(new Uri(string.Format("PokerImage/{0}.png", (int)this._pokerNum + 39), UriKind.Relative));
                    }
                    break;
                default:
                    break;
            }
            this.PokerImage.MouseEnter += new MouseEventHandler(PokerImage_MouseEnter);
            this.PokerImage.MouseLeave += new MouseEventHandler(PokerImage_MouseLeave);

            this.PokerImage.MouseLeftButtonDown += new MouseButtonEventHandler(PokerImage_MouseLeftButtonDown);
            this.PokerImage.MouseLeftButtonUp += new MouseButtonEventHandler(PokerImage_MouseLeftButtonUp);
        }

        void PokerImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (isMouseLeftButtonDown)
            {
                Image tempImage = (Image)sender;
                if (IsSelected)
                {
                    UnSelect();
                }
                else
                {
                    Select();
                }
            }
        }

        void PokerImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.PokerImage.CaptureMouse();
            isMouseLeftButtonDown = true;
        }

        void PokerImage_MouseLeave(object sender, MouseEventArgs e)
        {
            if (isMouseLeftButtonDown)
            {
                isMouseLeftButtonDown = false;
            }
            Image tempImage = (Image)sender;
            //if (StaticVar.IsDragSelect)
            //{
            //    if (IsSelected)
            //    {
            //        UnSelect();
            //    }
            //    else
            //    {
            //        Select();
            //    }
            //}
            //else
            //{
            //    var top = Canvas.GetTop(tempImage);
            //    if (top != 60)
            //    {
            //        UnSweep();
            //    }
            //}   
            //var top = Canvas.GetTop(tempImage);
            //if (top != 60)
            //{
            //    UnSweep();
            //}
            //tempImage.ReleaseMouseCapture();
        }

        void PokerImage_MouseEnter(object sender, MouseEventArgs e)
        {
            Image tempImage = (Image)sender;
            var top = Canvas.GetTop(tempImage);
            //tempImage.CaptureMouse();


            //if (StaticVar.IsDragSelect)
            //{
            //    //todo 批量选中
            //    Select();
            //}


            if (top == StaticVar.PokerTop)
            {
                Sweep();
            }
        }

        void PlayAnimation(double to, Duration duration, DependencyObject obj, string targetProperty)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = duration;
            da.To = to;
            Storyboard.SetTarget(da, obj);
            Storyboard.SetTargetProperty(da, new PropertyPath(targetProperty));
            sb.Children.Add(da);
            sb.Begin();
        }

        public void Select()
        {
            if (!StaticVar.DealComplete)
                return;
            var top = Canvas.GetTop(PokerImage);
            PlaySelectAnimation();
            IsSelected = true;
        }

        public void PlaySelectAnimation()
        {
            if (!StaticVar.DealComplete)
                return;
            PlayAnimation(30, TimeSpan.FromMilliseconds(200), this.PokerImage, "(Canvas.Top)");
        }

        public void UnSelect()
        {
            if (!StaticVar.DealComplete)
                return;
            PlayUnSelectAnimation();
            IsSelected = false;
        }

        public void PlayUnSelectAnimation()
        {
            if (!StaticVar.DealComplete)
                return;
            PlayAnimation(60, TimeSpan.FromMilliseconds(200), this.PokerImage, "(Canvas.Top)");
        }

        public void Sweep()
        {
            if (!StaticVar.DealComplete)
                return;
            var top = Canvas.GetTop(PokerImage);
            PlayAnimation(top - 10, TimeSpan.FromMilliseconds(200), this.PokerImage, "(Canvas.Top)");
            foreach (var item in ((Canvas)this.PokerImage.Parent).Children)
            {
                if (item.GetType() == typeof(Image) && (Image)item != this.PokerImage)
                {
                    Image tempImage = (Image)item;
                    if (tempImage.Tag != null && (bool)tempImage.Tag != true)
                    {
                        PlayAnimation(60, TimeSpan.FromMilliseconds(200), tempImage, "(Canvas.Top)");
                    }
                    else if (tempImage.Tag == null)
                    {
                        PlayAnimation(60, TimeSpan.FromMilliseconds(200), tempImage, "(Canvas.Top)");
                    }
                }
            }
        }

        public void UnSweep()
        {
            if (!StaticVar.DealComplete)
                return;
            if (!IsSelected)
            {
                PlayAnimation(60, TimeSpan.FromMilliseconds(200), this.PokerImage, "(Canvas.Top)");
            }
        }

        public static bool operator ==(Poker LP, Poker RP)
        {
            if ((object)LP != null && (object)RP != null)
            {
                if (LP.pokerNum == RP.pokerNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if ((object)LP == null && (object)RP != null)
                {
                    return false;
                }
                else
                {
                    if ((object)LP != null && (object)RP == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
        }
        public static bool operator ==(Poker LP, PokerNum RP)
        {
            if ((object)LP != null)
            {
                if (LP.pokerNum == RP)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(Poker LP, PokerNum RP)
        {
            return !(LP.pokerNum == RP);
        }
        public static bool operator !=(Poker LP, Poker RP)
        {
            return !(LP == RP);
        }
        public static bool operator >(Poker LP, Poker RP)
        {
            if ((object)LP != null && (object)RP != null)
            {
                if (LP.pokerNum > RP.pokerNum)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        public static bool operator <(Poker LP, Poker RP)
        {
            if (RP > LP)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            string Num = this.pokerNum.ToString().Replace("P", "");
            string Color;
            switch (this.pokerColor.ToString())
            {
                case "黑桃":
                    Color = "♠";
                    break;
                case "方块":
                    Color = "♦";
                    break;
                case "红心":
                    Color = "♥";
                    break;
                case "梅花":
                    Color = "♣";
                    break;
                default:
                    Color = "";
                    break;
            }
            if ((int)(this.pokerNum) >= 16)
            {
                return Num;
            }
            else
            {
                return Color + Num;
            }
        }
    }
}
