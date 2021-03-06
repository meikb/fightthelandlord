﻿using System;
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

        public Diamond this[int Column, int Row]
        {
            get
            {
                return (Diamond)gridGameMain.Children[Row * 10 + Column];
            }
            set
            {
                gridGameMain.Children[Row * 10 + Column] = value;
                //todo 值不在预期的范围内。
            }

        }
        private Diamond _firstDiamond, _secondDiamond;
        private List<Diamond> changedDiamonds;
        private List<Diamond> removedDiamonds;
        private Diamond firstDiamond
        {
            get
            {
                return this._firstDiamond;
            }
            set
            {
                this._firstDiamond = value;
                
            }
        }

        private Diamond secondDiamond
        {
            get
            {
                return this._secondDiamond;
            }
            set
            {
                this._secondDiamond = value;
            }
        }

        public static bool AnimationIsPlaying { get; set; }
		public MainPage()
		{
			// Required to initialize variables
			InitializeComponent();
            AnimationIsPlaying = false;
            InitGame();
            /* 测试动画
            Diamond diamond = new Diamond("Images/6.png", 1, 1, 6);
            gridGameMain.Children.Add(diamond);
            Grid.SetColumn(diamond, 1); Grid.SetRow(diamond, 1);
            Storyboard.SetTarget(daChange1, diamond.RenderTransform);
            Storyboard.SetTargetProperty(daChange1, new PropertyPath("X"));
            daChange1.To = 64; */

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
                    if (movedDiamond.direction != Direction.Nothing && movedDiamond.isMouseLeftButtonDown && !AnimationIsPlaying)
                    {
                        Diamond secondDiamond = GetDiamondByDirection(movedDiamond);
                        if (secondDiamond != null && !AnimationIsPlaying)
                        {
                            firstDiamond = movedDiamond;
                            bool canChange = CheckAround(secondDiamond, false);
                            AnimationIsPlaying = true;
                            ChangeImage(firstDiamond, secondDiamond, !canChange);
                        }
                    }
                }
            }
        }


        private bool CheckAround(Diamond diamond, bool removeNow)
        {
            List<Diamond> removedRowDiamond = new List<Diamond>();
            List<Diamond> removedColumnDiamond = new List<Diamond>();
            removedDiamonds = new List<Diamond>();
            if (firstDiamond.direction != Direction.Up)
            {
                for (int i = diamond.Row + 1; i <= 9; i++)
                {
                    Diamond tempDiamond = this[diamond.Column, i];
                    if (tempDiamond!= null && tempDiamond.Type == firstDiamond.Type)
                    {
                        removedRowDiamond.Add(tempDiamond);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (firstDiamond.direction != Direction.Down)
            {
                for (int i = diamond.Row - 1; i >= 0; i--)
                {
                    Diamond tempDiamond = this[diamond.Column, i];
                    if (tempDiamond != null && tempDiamond.Type == firstDiamond.Type)
                    {
                        removedRowDiamond.Add(tempDiamond);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (firstDiamond.direction != Direction.Left)
            {
                for (int i = diamond.Column + 1; i <= 8; i++)
                {
                    Diamond tempDiamond = this[diamond.Column, i];
                    if (tempDiamond != null && tempDiamond.Type == firstDiamond.Type)
                    {
                        removedColumnDiamond.Add(tempDiamond);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (firstDiamond.direction != Direction.Right)
            {
                for (int i = diamond.Column - 1; i >= 0; i--)
                {
                    Diamond tempDiamond = this[diamond.Column, i];
                    if (tempDiamond != null && tempDiamond.Type == firstDiamond.Type)
                    {
                        removedColumnDiamond.Add(tempDiamond);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Action<Diamond> callBack = new Action<Diamond>(delegate(Diamond removediamond) {
                if (gridGameMain.Children.Contains(removediamond))
                {
                    removediamond = null;
                } });

            if (removedRowDiamond.Count >= 2 || removedColumnDiamond.Count >= 2)
            {
                if (removeNow)
                {
                    if (removedRowDiamond.Count >= 2)
                    {
                        firstDiamond.Disponse(callBack);
                        foreach (var tempDiamond in removedRowDiamond)
                        {
                            tempDiamond.Disponse(callBack);
                            removedDiamonds.Add(tempDiamond);
                        }
                    }
                    if (removedColumnDiamond.Count >= 2)
                    {
                        firstDiamond.Disponse(callBack);
                        foreach (var tempDiamond in removedColumnDiamond)
                        {
                            tempDiamond.Disponse(callBack);
                            removedDiamonds.Add(tempDiamond);
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
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
                        secondDiamond = this[firstDiamond.Column, firstDiamond.Row - 1];
                        if (secondDiamond != null)
                            secondDiamond.direction = Direction.Down;
                    }
                    break;
                case Direction.Down:
                    if (firstDiamond.Row != 9)
                    {
                        secondDiamond = this[firstDiamond.Column, firstDiamond.Row + 1];
                        if (secondDiamond != null)
                            secondDiamond.direction = Direction.Up;
                    }
                    break;
                case Direction.Left:
                    if (firstDiamond.Column != 0)
                    {
                        secondDiamond = this[firstDiamond.Column - 1, firstDiamond.Row];
                        if (secondDiamond != null)
                            secondDiamond.direction = Direction.Right;
                    }
                    break;
                case Direction.Right:
                    if (firstDiamond.Column != 8)
                    {
                        secondDiamond = this[firstDiamond.Column + 1, firstDiamond.Row];
                        if (secondDiamond != null)
                            secondDiamond.direction = Direction.Left;
                    }
                    break;
            }
            return secondDiamond;
        }

        private void ChangeImage(Diamond firstDiamond, Diamond secondDiamond, bool goBack)
        {
            ChangeZIndex(firstDiamond, secondDiamond);
            PlayAnimation(firstDiamond, secondDiamond, goBack);
        }

        private void PlayAnimation(Diamond firstDiamond, Diamond secondDiamond, bool goBack)
        {
            if (firstDiamond != secondDiamond)
            {
                UpdateDoubleAnimationByDiamond(daChange1, firstDiamond, 64);
                UpdateDoubleAnimationByDiamond(daChange2, secondDiamond, 64);
                if (goBack)
                {
                    sbChangeImage.Completed += sbChangeImage_Completed;
                }
                else
                {
                    sbChangeImage.Completed += sbChangeImage_Completed_Success;
                }
                sbChangeImage.Begin();
            }
            else
            {
                AnimationIsPlaying = false;
            }
        }

        private void UpdateDoubleAnimationByDiamond(DoubleAnimation da, Diamond diamond, double To)
        {
            try
            {
                Storyboard.SetTarget(da, diamond.RenderTransform);
                if (diamond.direction == Direction.Up || diamond.direction == Direction.Down)
                {
                    Storyboard.SetTargetProperty(da, new PropertyPath("Y"));
                    if (diamond.direction == Direction.Up)
                    {
                        da.To = -To;
                    }
                    else
                    {
                        da.To = To;
                    }
                }
                if (diamond.direction == Direction.Left || diamond.direction == Direction.Right)
                {
                    Storyboard.SetTargetProperty(da, new PropertyPath("X"));
                    if (diamond.direction == Direction.Left)
                    {
                        da.To = -To;
                    }
                    else
                    {
                        da.To = To;
                    }
                }
            }
            catch
            {
            }
        }

        private void sbChangeImage_Completed(object sender, EventArgs e)
        {
            sbChangeImage.Completed -= sbChangeImage_Completed;
            double firstx = (double)firstDiamond.RenderTransform.GetValue(TranslateTransform.XProperty);
            double firsty = (double)firstDiamond.RenderTransform.GetValue(TranslateTransform.YProperty);
            double secondx = (double)secondDiamond.RenderTransform.GetValue(TranslateTransform.XProperty);
            double secondy = (double)secondDiamond.RenderTransform.GetValue(TranslateTransform.YProperty);
            sbChangeImage.Stop();
            firstDiamond.RenderTransform.SetValue(TranslateTransform.XProperty, firstx);
            firstDiamond.RenderTransform.SetValue(TranslateTransform.YProperty, firsty);
            secondDiamond.RenderTransform.SetValue(TranslateTransform.XProperty, secondx);
            secondDiamond.RenderTransform.SetValue(TranslateTransform.YProperty, secondy);
            sbGoBackImage.Stop();
            UpdateDoubleAnimationByDiamond(daGoBack1, firstDiamond, 0);
            UpdateDoubleAnimationByDiamond(daGoBack2, secondDiamond, 0);
            ChangeZIndex(secondDiamond, firstDiamond);
            sbGoBackImage.Completed += sbGoBackImage_Completed;
            sbGoBackImage.Begin();
            firstDiamond.direction = Direction.Nothing;
            secondDiamond.direction = Direction.Nothing;
            //ShowTranslateTransformXandY();
        }

        private void sbGoBackImage_Completed(object sender, EventArgs e)
        {
            sbGoBackImage.Completed -= sbGoBackImage_Completed;
            sbGoBackImage.Stop();
            AnimationIsPlaying = false;
            firstDiamond.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0);
            firstDiamond.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
            secondDiamond.RenderTransform.SetValue(TranslateTransform.XProperty, 0.0);
            secondDiamond.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
            firstDiamond.direction = Direction.Nothing;
            secondDiamond.direction = Direction.Nothing;
        }

        private void sbChangeImage_Completed_Success(object sender, EventArgs e)
        {
            sbChangeImage.Completed -= sbChangeImage_Completed_Success;
            double firstx = (double)firstDiamond.RenderTransform.GetValue(TranslateTransform.XProperty);
            double firsty = (double)firstDiamond.RenderTransform.GetValue(TranslateTransform.YProperty);
            sbChangeImage.Stop();
            AnimationIsPlaying = false;
            firstDiamond.RenderTransform.SetValue(TranslateTransform.XProperty, firstx);
            firstDiamond.RenderTransform.SetValue(TranslateTransform.YProperty, firsty);
            CheckAround(secondDiamond, true);
            secondDiamond.Row = firstDiamond.Row;
            secondDiamond.Column = firstDiamond.Column;
            this[firstDiamond.Column, firstDiamond.Row] = secondDiamond;
            firstDiamond.direction = Direction.Nothing;
            secondDiamond.direction = Direction.Nothing;
            foreach (var tempdia in removedDiamonds)
            {
                this[tempdia.Column, tempdia.Row] = null;
            }
            FillNull();
        }

        private void InitGame()
        {
            Random r = new Random();
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int randomNum = r.Next(1,6);
                    string imagePath = string.Format("images/{0}.png", randomNum);
                    var tempDiamond = new Diamond(imagePath, i, j, randomNum);
                    tempDiamond.Column = i; tempDiamond.Row = j;
                    gridGameMain.Children.Add(tempDiamond);
                    tempDiamond.OnTestMode(); //测试状态
                }
            }

        }

        private void ChangeZIndex(Diamond firstDiamond, Diamond secondDiamond)
        {
            int secDiaZindex = Canvas.GetZIndex(secondDiamond);
            Canvas.SetZIndex(firstDiamond, secDiaZindex + 1);
        }

        //private void UpdateMatrix()
        //{
        //    foreach (var item in gridGameMain.Children)
        //    {
        //        Diamond dia = (Diamond)item;
        //        diamonds[dia.Column, dia.Row] = dia;
        //    }
        //}

        private void FillNull()
        {
            changedDiamonds = new List<Diamond>();
            for (int i = 0; i <= 8; i++)
            {
                int nullNum = 0;
                int row = 0;
                for (int j = 0; j <= 9; j++)
                {
                    if (this[i, j] == null)
                    {
                        if (j > row) row = j;
                        nullNum++;
                        //todo 填充被消除的图案
                    }
                }
                for (int k = row - nullNum; k >=0 && nullNum != 0 ; k--)
                {
                    DoubleAnimation da = new DoubleAnimation();
                    Diamond tempdia = this[i, k];
                    Storyboard.SetTarget(da, tempdia.RenderTransform);
                    Storyboard.SetTargetProperty(da, new PropertyPath("Y"));
                    tempdia.Row = tempdia.Row + nullNum;
                    tempdia.RenderTransform.SetValue(TranslateTransform.YProperty, (double)-64 * nullNum);
                    da.To = 0;
                    da.Duration = new Duration(TimeSpan.FromMilliseconds(300 * nullNum));
                    sbFill.Children.Add(da);
                    changedDiamonds.Add(tempdia);
                }
                for (int l = nullNum - 1; l >= 0 && nullNum != 0; l--)
                {
                    int randomNum = new Random().Next(0, 16);
                    string imagePath = string.Format("images/{0}.png", randomNum);
                    this[i, l] = new Diamond(imagePath, i, l, randomNum);
                    Diamond tempdia = this[i, l] ;
                    tempdia.RenderTransform.SetValue(TranslateTransform.YProperty, (double)-64 * nullNum);
                    DoubleAnimation da = new DoubleAnimation();
                    da.Duration = new Duration(TimeSpan.FromMilliseconds(300 * nullNum));
                    da.To = 0;
                    Storyboard.SetTarget(da, tempdia.RenderTransform);
                    Storyboard.SetTargetProperty(da, new PropertyPath("Y"));
                    sbFill.Children.Add(da);
                    this.gridGameMain.Children.Add(tempdia);
                    changedDiamonds.Add(tempdia);
                }
            }
            sbFill.Begin();
        }

        private void ShowTranslateTransformXandY()
        {
            MessageBox.Show(firstDiamond.RenderTransform.GetValue(TranslateTransform.XProperty).ToString());
            MessageBox.Show(firstDiamond.RenderTransform.GetValue(TranslateTransform.YProperty).ToString());
            MessageBox.Show(secondDiamond.RenderTransform.GetValue(TranslateTransform.XProperty).ToString());
            MessageBox.Show(secondDiamond.RenderTransform.GetValue(TranslateTransform.YProperty).ToString());
        }

        private void sbFill_Completed(object sender, EventArgs e)
        {
            Storyboard sb = sender as Storyboard;
            sb.Stop();
            sb.Children.Clear();
            foreach (var tempdia in changedDiamonds)
            {
                tempdia.RenderTransform.SetValue(TranslateTransform.YProperty, 0.0);
            }
        }

        private Diamond GetDiamondByMatrix(int Column, int Row)
        {
            return (Diamond)gridGameMain.Children[Column * 10 + Row];
        }

        private void SetDiamondByMatrix(int Column, int Row, Diamond diamondValue)
        {
            gridGameMain.Children[Column * 10 + Row] = diamondValue;
        }
	}
}