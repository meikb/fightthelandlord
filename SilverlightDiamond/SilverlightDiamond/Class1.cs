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

namespace SilverlightDiamond
{
    public class Class1
    {
         public static readonly DependencyProperty PositionProperty = DependencyProperty.Register("Position", typeof(double), typeof(MainPage), new PropertyMetadata((obj, e) =>
        {
            System.Windows.Browser.HtmlPage.Document.SetProperty("title", e.NewValue.ToString());
        }));

        public MainPage()
        {
            InitializeComponent();

            var s = new Storyboard();
            var da = new DoubleAnimationUsingKeyFrames();
            da.KeyFrames.Add(new EasingDoubleKeyFrame { KeyTime = new TimeSpan(0, 0, 0, 1), Value = 200 });
            Storyboard.SetTarget(da, this);
            Storyboard.SetTargetProperty(da, new PropertyPath(MainPage.PositionProperty));
            s.Children.Add(da);
            s.Begin();
        }

    }
}
