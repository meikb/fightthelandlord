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
        public Diamond[,] diamonds { get; set; }
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            InitGame();
		}
        private void gridGameMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void gridGameMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }

        private void gridGameMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource != null)
            {
                if (e.OriginalSource.GetType() == typeof(SilverlightDiamond.Diamond))
                {
                    Diamond movedDiamond = (Diamond)e.OriginalSource;
                    if (movedDiamond.direction != Direction.Nothing)
                    {
                        try
                        {
                            PlayAnimation(movedDiamond);
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void PlayAnimation(Diamond movedDiamond)
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

        private void sbChangeImage_Completed(object sender, EventArgs e)
        {
            Storyboard sb = sender as Storyboard;
            sb.Stop();
            //Storyboard sb = (Storyboard)sender;
            //daChange1.To = 0;
            ////daChange2.To = 0;
            //sb.Begin();
        }

        private void InitGame()
        {
            diamonds = new Diamond[9, 10];
            Random r = new Random();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int randomNum = r.Next(1,16);
                    string imagePath = string.Format("images/{0}.png", randomNum);
                    diamonds[i, j] = new Diamond(imagePath, i, j, randomNum);
                    var tempDiamond = diamonds[i, j];
                    gridGameMain.Children.Add(tempDiamond);
                    Grid.SetColumn(tempDiamond, i); Grid.SetRow(tempDiamond, j);
                    tempDiamond.Column = i; tempDiamond.Row = j;
                }
            }

        }
	}
}