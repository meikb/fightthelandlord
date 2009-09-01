using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;
using System.Collections.Generic;

namespace SilverlightDiamond
{
	public partial class MainPage : UserControl
	{
        public Transform imageTransform { get; set; }
        public Diamond[,] diamonds { get; set; }
        private Diamond firstDiamond, secondDiamond;
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            InitGame();
		}
        private void gridGameMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.OriginalSource != null && e.OriginalSource.GetType() == typeof(SilverlightDiamond.Diamond))
            //{
            //    lastSelectedDiamond = (Diamond)e.OriginalSource;
            //}
        }
        private void gridGameMain_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //lastSelectedDiamond.direction = Direction.Nothing;
        }

        private void gridGameMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.OriginalSource != null)
            {
                if (e.OriginalSource.GetType() == typeof(SilverlightDiamond.Diamond))
                {
                    Diamond movedDiamond = (Diamond)e.OriginalSource;
                    if (movedDiamond.direction != Direction.Nothing && movedDiamond.isMouseLeftButtonDown)
                    {
                        try
                        {
                            Diamond secondDiamond = GetDiamondByDirection(movedDiamond);
                            if (secondDiamond != null)
                            {
                                CheckAround(secondDiamond);
                                firstDiamond = movedDiamond;
                                ChangeImage(movedDiamond, secondDiamond);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
            }
        }

        private void CheckAround(Diamond diamond)
        {
            List<Diamond> removedRowDiamond = new List<Diamond>();
            List<Diamond> removedColumnDiamond = new List<Diamond>();
            for (int i = diamond.Row; i < 8; i++)
            {
                Diamond tempDiamond = diamonds[i, diamond.Column];
                if (tempDiamond.Type == diamond.Type)
                {
                    removedRowDiamond.Add(tempDiamond);
                }
                else
                {
                    break;
                }
            }
            for (int i = diamond.Row; i > 0; i--)
            {
                Diamond tempDiamond = diamonds[i, diamond.Column];
                if (tempDiamond.Type == diamond.Type)
                {
                    removedRowDiamond.Add(tempDiamond);
                }
                else
                {
                    break;
                }
            }
            for (int i = diamond.Column; i < 9; i++)
            {
                Diamond tempDiamond = diamonds[diamond.Row, i];
                if (tempDiamond.Type == diamond.Type)
                {
                    removedColumnDiamond.Add(tempDiamond);
                }
                else
                {
                    break;
                }
            }
            for (int i = diamond.Column; i > 0; i++)
            {
                Diamond tempDiamond = diamonds[diamond.Row, i];
                if (tempDiamond.Type == diamond.Type)
                {
                    removedColumnDiamond.Add(tempDiamond);
                }
                else
                {
                    break;
                }
            }
            if (removedRowDiamond.Count >= 2)
            {
                foreach (var tempDiamond in removedRowDiamond)
                {
                    //todo 销毁
                }
            }
            if (removedColumnDiamond.Count >= 2)
            {
                foreach (var tempDiamond in removedColumnDiamond)
                {
                    //todo 销毁
                }
            }
        }

        private Diamond GetDiamondByDirection(Diamond firstDiamond)
        {
            switch (firstDiamond.direction)
            {
                case Direction.Nothing:
                    secondDiamond = null;
                    break;
                case Direction.Up:
                    if (firstDiamond.Row != 0)
                    {
                        secondDiamond = diamonds[firstDiamond.Column, firstDiamond.Row - 1];
                        secondDiamond.direction = Direction.Down;
                    }
                    break;
                case Direction.Down:
                    if (firstDiamond.Row != 9)
                    {
                        secondDiamond = diamonds[firstDiamond.Column, firstDiamond.Row + 1];
                        secondDiamond.direction = Direction.Up;
                    }
                    break;
                case Direction.Left:
                    if (firstDiamond.Column != 0)
                    {
                        secondDiamond = diamonds[firstDiamond.Column - 1, firstDiamond.Row];
                        secondDiamond.direction = Direction.Right;
                    }
                    break;
                case Direction.Right:
                    if (firstDiamond.Column != 8)
                    {
                        secondDiamond = diamonds[firstDiamond.Column + 1, firstDiamond.Row];
                        secondDiamond.direction = Direction.Left;
                    }
                    break;
            }
            return secondDiamond;
        }

        private void ChangeImage(Diamond firstDiamond, Diamond secondDiamond)
        {
            ChangeZIndex(firstDiamond, secondDiamond);
            PlayAnimation(firstDiamond, secondDiamond);
        }

        private void PlayAnimation(Diamond firstDiamond, Diamond secondDiamond)
        {
            UpdateDoubleAnimationByDiamond(daChange1, firstDiamond);
            UpdateDoubleAnimationByDiamond(daChange2, secondDiamond);
            sbChangeImage.Begin();
        }

        private void UpdateDoubleAnimationByDiamond(DoubleAnimation da, Diamond diamond)
        {
            Storyboard.SetTarget(da, diamond.RenderTransform);
            if (diamond.direction == Direction.Up || diamond.direction == Direction.Down)
            {
                Storyboard.SetTargetProperty(da, new PropertyPath("Y"));
                if (diamond.direction == Direction.Up)
                {
                    da.To = -64;
                }
                else
                {
                    da.To = 64;
                }
            }
            if (diamond.direction == Direction.Left || diamond.direction == Direction.Right)
            {
                Storyboard.SetTargetProperty(da, new PropertyPath("X"));
                if (diamond.direction == Direction.Left)
                {
                    da.To = -64;
                }
                else
                {
                    da.To = 64;
                }
            }
            diamond.direction = Direction.Nothing;
        }

        private void sbChangeImage_Completed(object sender, EventArgs e)
        {
            Storyboard sb = sender as Storyboard;
            sb.Stop();
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

        private void ChangeZIndex(Diamond firstDiamond, Diamond secondDiamond)
        {
            int secDiaZindex = Canvas.GetZIndex(secondDiamond);
            Canvas.SetZIndex(firstDiamond, secDiaZindex + 1);
        }
	}
}