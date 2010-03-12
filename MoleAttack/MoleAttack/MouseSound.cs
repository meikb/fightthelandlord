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

namespace MoleAttack
{
    public class MouseSound
    {
        public MediaElement media;
        public MouseSound(string uri)
        {
            media = new MediaElement();
            media.AutoPlay = false;
            media.Source = new Uri(uri, UriKind.Relative);
            MainPage.Instance.LayoutRoot.Children.Add(media);
        }

        public void Play()
        {
            media.Stop();
            media.Play();
        }
    }
}
