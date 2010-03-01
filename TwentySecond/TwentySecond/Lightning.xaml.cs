using System;
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
	public partial class Lightning : UserControl
	{
		public Lightning()
		{
			// 为初始化变量所必需
			InitializeComponent();
		}

        public event Action Completed;

        public event Action Fire;

        public void Play()
        {
            sbLightningFire.Completed += new EventHandler(sbLightningFire_Completed);
            //LightningReady.Position = TimeSpan.FromSeconds(0);
            sbLightningReady.Completed += new EventHandler(Storyboard2_Completed);
            LightningFire.MediaEnded += new RoutedEventHandler(LightningFire_MediaEnded);
            LightningFire.MediaFailed += LightningFire_MediaEnded;
            sbLightningReady.Begin();
            
        }

        void Storyboard2_Completed(object sender, EventArgs e)
        {
            Fire();
            sbLightningFire.Begin();
            LightningReady.Stop();
            LightningFire.Play();
        }

        void LightningFire_MediaEnded(object sender, RoutedEventArgs e)
        {
            (Parent as Canvas).Children.Remove(this);
            Completed();
        }

        void sbLightningFire_Completed(object sender, EventArgs e)
        {
        }
	}
}