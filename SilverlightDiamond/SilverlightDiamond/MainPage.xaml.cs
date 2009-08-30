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
		public MainPage()
		{
            //
            sbChangeImage.Completed += (object sender1, EventArgs e1) =>
            {
                Storyboard sb = (Storyboard)sender1;
                daChangeImage.To = 0;
                daChangeImage2.To = 0;
                int zindex1 = Canvas.GetZIndex(image1and0);
                Canvas.SetZIndex(image1and1, zindex1 + 1);
                sb.Begin();
            };
			// Required to initialize variables
			InitializeComponent();
            testd.SetImageSource("Images/5.png");
		}

<<<<<<< .mine
        private void gridGameMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //daChange1.SetValue(Storyboard.TargetNameProperty, testd.Name);
            //daChange1.SetValue(Storyboard.TargetPropertyProperty, "Grid.Row");
            //daChange1.To = 3;
            //daChange1.AutoReverse = true;
            sbChangeImage.Begin();
        }

=======
>>>>>>> .r186
        private void gridGameMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //if (e.OriginalSource.GetType() == typeof(System.Windows.Controls.Border))
            //{
            //    Border tempBorder = (Border)e.OriginalSource;
            //    Diamond movedDiamond = (Diamond)tempBorder.Parent;
            //    if (movedDiamond.direction != Direction.Nothing)
            //    {
            //        movedDiamond.direction = Direction.Nothing;
            //        PlayAnimation(movedDiamond);
            //    }
            //}
        }

        private void PlayAnimation(Diamond movedDiamond)
        {
<<<<<<< .mine
            //if (movedDiamond.direction == Direction.Up || movedDiamond.direction == Direction.Down)
            //{
            //    movedDiamond.Margin.
            //    daChange1.SetValue(Storyboard.TargetNameProperty, movedDiamond.Name);
            //    daChange1.SetValue(Storyboard.TargetPropertyProperty,);
            //}
            //if (movedDiamond.direction == Direction.Left || movedDiamond.direction == Direction.Right)
            //{
            //    daChangeImage.SetValue(Storyboard.TargetNameProperty, movedDiamond.Name);
            //    daChangeImage.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("TranslateTransform.XProperty"));
            //}
            //sbChangeImage.Completed += (object sender1, EventArgs e1) =>
            //{
            //    Storyboard sb = (Storyboard)sender1;
            //    daChangeImage.To = 0;
            //    daChangeImage2.To = 0;
            //    int zindex1 = Canvas.GetZIndex(image1and0);
            //    Canvas.SetZIndex(image1and1, zindex1 + 1);
            //    sb.Begin();
            //};
            //daChangeImage.To = 64;
            //daChangeImage2.To = -64;
            //int zindex = Canvas.GetZIndex(image1and1);
            //Canvas.SetZIndex(image1and0, zindex + 1);
            //sbChangeImage.Begin();
=======
            if (movedDiamond.direction == Direction.Up || movedDiamond.direction == Direction.Down)
            {
                daChangeImage.SetValue(Storyboard.TargetNameProperty, movedDiamond.Name);
                daChangeImage.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("TranslateTransform.YProperty"));
            }
            if (movedDiamond.direction == Direction.Left || movedDiamond.direction == Direction.Right)
            {
                daChangeImage.SetValue(Storyboard.TargetNameProperty, movedDiamond.Name);
                daChangeImage.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("TranslateTransform.XProperty"));
            }
            daChangeImage.To = 64;
            daChangeImage2.To = -64;
            int zindex = Canvas.GetZIndex(image1and1);
            Canvas.SetZIndex(image1and0, zindex + 1);
            sbChangeImage.Begin();
>>>>>>> .r186
        }

        private void sbChangeImage_Completed(object sender, EventArgs e)
        {
                //Storyboard sb = (Storyboard)sender;
                //daChange.To = 0;
                //daChange.To = 0;
                //int zindex1 = Canvas.GetZIndex(image1and0);
                //Canvas.SetZIndex(image1and1, zindex1 + 1);
                //sb.Begin();
        }
	}
}