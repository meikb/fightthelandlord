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
    public class Bullet : Sprite
    {
        private Ellipse cricle;
        public Bullet(Vector2 velocity, Vector2 position)
            : base(velocity, position)
        {
            var cricle = new Ellipse() { Fill = new SolidColorBrush(Colors.Yellow), Height = Radius * 2, Width = Radius * 2 };
            Children.Add(cricle);
        }
    }
}
