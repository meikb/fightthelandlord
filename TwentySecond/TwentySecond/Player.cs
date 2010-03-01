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

namespace TwentySecond
{
    public class Player : Sprite
    {
        public bool UpButtonDown { get; set; }
        public bool DownButtonDown { get; set; }
        public bool LeftButtonDown { get; set; }
        public bool RightButtonDown { get; set; }

        private BitmapImage left = new BitmapImage(new Uri("Resource/Image/Hero/HeroLeft.png", UriKind.Relative));
        private BitmapImage right = new BitmapImage(new Uri("Resource/Image/Hero/HeroRight.png", UriKind.Relative));
        private BitmapImage normal = new BitmapImage(new Uri("Resource/Image/Hero/Hero.png", UriKind.Relative));

        private Image _image;
        public Player(Vector2 velocity, Vector2 position)
            : base(velocity, position)
        {
            _image = new Image() { Source = normal };
            Children.Add(_image);
        }

        public void Updata()
        {
            if (UpButtonDown)
                nowPosition.Y-=4;
            if (DownButtonDown)
                nowPosition.Y+=4;
            if (LeftButtonDown)
            {
                nowPosition.X -= 4;
                _image.Source = left;
            }
            else
            {
                _image.Source = normal;
            }
            if (RightButtonDown)
            {
                nowPosition.X += 4;
                _image.Source = right;
            }
            else
            {
                _image.Source = normal;
            }

            if (nowPosition.X < 0)
                nowPosition.X = 0;
            if (nowPosition.X > 800 - Radius * 2)
                nowPosition.X = 800 - Radius * 2;
            if (nowPosition.Y < 0)
                nowPosition.Y = 0;
            if (nowPosition.Y > 600 - Radius * 2)
                nowPosition.Y = 600 - Radius * 2; //不允许player出主窗口

            base.Update();
        }
    }
}
