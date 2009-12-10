using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;

namespace SLFightTheLandLord
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            StaticVar.AllPoker = new PokerGroup();
            StaticVar.MyPoker = new PokerGroup();
            StaticVar.LeftPlayerPokerImages = new List<Image>();
            StaticVar.RightPlayerPokerImages = new List<Image>();
            StaticVar.LandLordPokerImages = new List<Image>();
            StaticVar.ShowMessage = this.ShowMessage;
            StaticVar.TimeoutTime = 20;
            StaticVar.PassTime = 20;
            StaticVar.PassLeftPlayerSecond = PassLeftPlayerSecond;
            StaticVar.PassRightPlayerSecond = PassRightPlayerSecond;
            StaticVar.PassMyOneSecond = PassMyOneSecond;
            StaticVar.HideMyTimer = HideMyTimer;
            StaticVar.ShowMyTimer = ShowMyTimer;
            StaticVar.AddUIElement = LayoutRoot.Children.Add;

            Network.Connect();

            //Network.SendStart();
            

            #region 临时测试
            for (int i = 3; i < 18; i++)  //嵌套for循环初始化54张牌
            {
                for (int j = 1; j < 5; j++)
                {
                    if (i <= 15)
                    {
                        StaticVar.AllPoker.Add(new Poker((PokerNum)i, (PokerColor)j));
                    }
                }
                if (i >= 16)
                {
                    StaticVar.AllPoker.Add(new Poker((PokerNum)i, PokerColor.黑桃));
                }
            }

            StaticVar.Sort(StaticVar.AllPoker);

            for (int i = 0; i < 17; i++)
            {
                var tempImage = StaticVar.AllPoker[i].PokerImage;
                StaticVar.MyPoker.Add(StaticVar.AllPoker[i]);
                Canvas.SetTop(tempImage, StaticVar.PokerTop - 200);
                //Canvas.SetLeft(tempImage, i * StaticVar.PokerDistance);
                Canvas.SetLeft(tempImage, 250);
                tempImage.Visibility = Visibility.Collapsed;
                this.canvasMyPokers.Children.Add(tempImage);
            }

            for (int i = 0; i < 17; i++)
            {
                var tempImage1 = new Image() { Source = new BitmapImage(new Uri("PokerImage/back1.png", UriKind.Relative)) };
                var tempImage2 = new Image() { Source = new BitmapImage(new Uri("PokerImage/back1.png", UriKind.Relative)) };
                tempImage1.Visibility = Visibility.Collapsed;
                tempImage2.Visibility = Visibility.Collapsed;
                StaticVar.LeftPlayerPokerImages.Add(tempImage1);
                StaticVar.RightPlayerPokerImages.Add(tempImage2);
                //var top = StaticVar.PokerDistance * i;
                Canvas.SetLeft(tempImage1, 350);
                Canvas.SetTop(tempImage1, 250);
                Canvas.SetLeft(tempImage2, -350);
                Canvas.SetTop(tempImage2, 250);
                canvasLeftPlayerPokers.Children.Add(tempImage1);
                canvasRightPlayerPokers.Children.Add(tempImage2);
            }

            for (int i = 0; i < 3; i++)
            {
                var tempImage = new Image() { Source = new BitmapImage(new Uri("PokerImage/back1.png", UriKind.Relative)) };
                tempImage.Visibility = Visibility.Collapsed;
                Canvas.SetLeft(tempImage, 125);
                Canvas.SetTop(tempImage, 335);
                StaticVar.LandLordPokerImages.Add(tempImage);
                canvasLandLordPokers.Children.Add(tempImage);
            }

            StaticVar.LeftPlayerLeadedPokers = new PokerGroup();
            for (int i = 19; i < 25; i++)
            {
                StaticVar.LeftPlayerLeadedPokers.Add(StaticVar.AllPoker[i]);
            }
            #endregion
        }

        private void canvasMyPokers_MouseLeave(object sender, MouseEventArgs e)
        {
            foreach (var onePoker in StaticVar.MyPoker)
            {
                onePoker.UnSweep();
            }
        }

        private void canvasMyPokers_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            canvasMyPokers.CaptureMouse();
            StaticVar.IsDragSelect = true;
            StaticVar.MyPokerClickPoint = e.GetPosition(canvasMyPokers);
        }


        private void canvasMyPokers_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            StaticVar.IsDragSelect = false;
            foreach (var onePoker in StaticVar.SelectedPokers)
            {
                onePoker.IsSelected = true;
            }
            foreach (var onePoker in StaticVar.UnSelectedPokers)
            {
                onePoker.IsSelected = false;
            }
            StaticVar.SelectedPokers.Clear();
            StaticVar.UnSelectedPokers.Clear();

            #region 舍弃代码，留做备份
            //var mousePoint = e.GetPosition(canvasMyPokers); //在Canvas里面对Image进行点击选中操作,舍弃...
            //foreach (var onePoker in StaticVar.MyPoker)
            //{
            //    var pokerX = Canvas.GetLeft(onePoker.PokerImage);
            //    var pokerY = Canvas.GetTop(onePoker.PokerImage);

            //    if (StaticVar.MyPokerClickPoint.X > pokerX && StaticVar.MyPokerClickPoint.X < pokerX + StaticVar.PokerDistance && mousePoint.X > pokerX && mousePoint.X < pokerX + StaticVar.PokerDistance)
            //    {
            //        if (onePoker.IsSelected)
            //        {
            //            onePoker.UnSelect();
            //        }
            //        else
            //        {
            //            onePoker.Select();
            //        }
            //    }
            //}
            #endregion
        }

        private void canvasMyPokers_MouseMove(object sender, MouseEventArgs e)
        {
            var mousePoint = e.GetPosition(canvasMyPokers);
            canvasMyPokers.CaptureMouse();
            if (StaticVar.IsDragSelect)
            {
                foreach (var onePoker in StaticVar.MyPoker)
                {
                    if (!StaticVar.SelectedPokers.Contains(onePoker) && !StaticVar.UnSelectedPokers.Contains(onePoker)) //防止重复添加
                    {
                        var pokerX = Canvas.GetLeft(onePoker.PokerImage);
                        var pokerY = Canvas.GetTop(onePoker.PokerImage);

                        if (StaticVar.MyPokerClickPoint.X < mousePoint.X) //从左向右拖
                        {
                            if (mousePoint.X > pokerX && pokerX + StaticVar.PokerDistance > StaticVar.MyPokerClickPoint.X)
                            {
                                if (onePoker.IsSelected)
                                {
                                    onePoker.PlayUnSelectAnimation();
                                    StaticVar.UnSelectedPokers.Add(onePoker);
                                }
                                else
                                {
                                    onePoker.PlaySelectAnimation();
                                    StaticVar.SelectedPokers.Add(onePoker);
                                }
                            }
                        }
                        else  //从右向左拖
                        {
                            if (mousePoint.X < pokerX + StaticVar.PokerDistance && pokerX < StaticVar.MyPokerClickPoint.X)
                            {
                                if (onePoker.IsSelected)
                                {
                                    onePoker.PlayUnSelectAnimation();
                                    StaticVar.UnSelectedPokers.Add(onePoker);
                                }
                                else
                                {
                                    onePoker.PlaySelectAnimation();
                                    StaticVar.SelectedPokers.Add(onePoker);
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 显示一个指定的消息(可以从非UI线程调用)
        /// </summary>
        /// <param name="message">消息</param>
        private void ShowMessage(string message)
        {
            textblockMessage.Dispatcher.BeginInvoke(() =>
            {
                textblockMessage.Text = message;
                var x = (LayoutRoot.ActualWidth - textblockMessage.ActualWidth) / 2;
                Canvas.SetLeft(textblockMessage, x);
                EventHandler ev = (object sender1, EventArgs ea1) =>
                {
                    StaticVar.PlayAnimation(0, TimeSpan.FromMilliseconds(1000), textblockMessage, "Opacity");
                };
                StaticVar.PlayAnimation(1, TimeSpan.FromMilliseconds(1000), textblockMessage, "Opacity", ev);
                });
        }

        private void PassMyOneSecond()
        {
            textblockMyTimer.Text = StaticVar.PassTime.ToString();
        }

        private void PassLeftPlayerSecond()
        {
            textblockMyTimer.Text = StaticVar.PassTime.ToString();
        }

        private void PassRightPlayerSecond()
        {
            textblockMyTimer.Text = StaticVar.PassTime.ToString();
        }

        private void HideMyTimer()
        {
            textblockMyTimer.Visibility = Visibility.Collapsed;
        }

        private void ShowMyTimer()
        {
            textblockMyTimer.Visibility = Visibility.Visible;
        }

        private void btnLeadPoker_Click(object sender, RoutedEventArgs e)
        {
            var leadPG = new PokerGroup();
            foreach (var onePoker in StaticVar.MyPoker)
            {
                if (onePoker.IsSelected)
                {
                    leadPG.Add(onePoker);
                }
            }
            if (leadPG.Count != 0 && StaticVar.IsRules(leadPG))
            {
                StaticVar.LeadPoker(leadPG);
            }
            else
            {
                StaticVar.LeadFailed();
            }
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            StaticVar.PlayDealAnimation();
            ShowMyTimer();
            StaticVar.InitTimeoutTimer();
            StaticVar.TimeoutTimer.Start();
        }

        private void btnPass_Click(object sender, RoutedEventArgs e)
        {
            Network.SendStart();
        }

        private void btnLandLord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNoLandLord_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
