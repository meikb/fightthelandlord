using System;
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
	public partial class MainPage : UserControl
	{
        public Transform imageTransform { get; set; }
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            Diamond dia = new Diamond();
            dia.ImageSource = "images/5.png";
            dia.Name = "dia";
            gridGameMain.Children.Add(dia);
            Grid.SetColumn(dia, 5); Grid.SetRow(dia, 5);
		}
        private void gridGameMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
        }
        private void gridGameMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource.GetType() == typeof(SilverlightDiamond.Diamond))
            {
                Diamond movedDiamond = (Diamond)e.OriginalSource;
                if (movedDiamond.direction != Direction.Nothing)
                {
                    PlayAnimation(movedDiamond);
                }
            }
        }

        private void PlayAnimation(Diamond movedDiamond)
        {
            if (sbChangeImage.GetCurrentState() == ClockState.Stopped)
            {
                if (movedDiamond.direction == Direction.Up || movedDiamond.direction == Direction.Down)
                {
                    Storyboard.SetTarget(daChange1, movedDiamond.RenderTransform);
                    Storyboard.SetTargetProperty(daChange1, new PropertyPath("Y"));
                    if (movedDiamond.direction == Direction.Up)
                    {
                        daChange1.To = -64;
                    }
                    else
                    {
                        daChange1.To = 64;
                    }
                }
                if (movedDiamond.direction == Direction.Left || movedDiamond.direction == Direction.Right)
                {
                    Storyboard.SetTarget(daChange1, movedDiamond.RenderTransform);
                    Storyboard.SetTargetProperty(daChange1, new PropertyPath("X"));
                    if (movedDiamond.direction == Direction.Left)
                    {
                        daChange1.To = -64;
                    }
                    else
                    {
                        daChange1.To = 64;
                    }
                }
                sbChangeImage.Begin();
            }
        }

        private void sbChangeImage_Completed(object sender, EventArgs e)
        {
            Storyboard sb = (Storyboard)sender;
            daChange1.To = 0;
            ////daChange2.To = 0;
            sb.Begin();
        }
	}
}