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
using System.Windows.Media.Imaging;

namespace TwentySecond
{
    public class Bob:Canvas
    {
        private Image _image = new Image();
        private MediaElement _sound = new MediaElement();
        private Ellipse _glow = new Ellipse();
        private DispatcherTimer disLoop;
        private int _count = 1;
        private const int Width = 60;
        public Bob()
        {
            InitBob();
        }
        public Bob(Vector2 position)
        {
            Canvas.SetLeft(this, position.X - Width / 2);
            Canvas.SetTop(this, position.Y - Width / 2);
            InitBob();
        }

        void InitBob()
        {
            this.Children.Add(_image);
            this.Children.Add(_sound);
            this.Children.Add(_glow);
            disLoop = new DispatcherTimer();
            disLoop.Interval = TimeSpan.FromMilliseconds(1000 / 24);
            disLoop.Tick += new EventHandler(dis_Tick);
            disLoop.Start();
            _glow.Width = Width;
            _glow.Height = Width;
            var radial = new RadialGradientBrush(Colors.Transparent, Color.FromArgb(0x7F, 0xff, 0xff, 0xff));
            radial.GradientStops[0] = new GradientStop() { Offset = 0.7, Color = Colors.Transparent };
            _glow.Fill = radial;
            _glow.RenderTransform = new ScaleTransform() { CenterX = Width / 2, CenterY = Width / 2, ScaleX = 1, ScaleY = 1 };
            Global.PlayAnimation(10, TimeSpan.FromSeconds(1), _glow.RenderTransform, "ScaleX");
            Global.PlayAnimation(10, TimeSpan.FromSeconds(1), _glow.RenderTransform, "ScaleY");
            Global.PlayAnimation(0, TimeSpan.FromSeconds(1), _glow, "Opacity");
            _sound.Source = new Uri("Resource/Sound/BobSound.mp3", UriKind.Relative);
            _sound.Play();

        }
        void dis_Tick(object sender, EventArgs e)
        {
            _image.Source = new BitmapImage(new Uri(string.Format("Resource/Image/Bob1/{0}.png", _count), UriKind.Relative));
            _count++;
            if (_count == 27)
            {
                disLoop.Stop();
                _image.Source = null;
            }
        }
    }
}
