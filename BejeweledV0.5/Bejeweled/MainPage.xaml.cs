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
using Bejeweled;

namespace Bejeweled
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var tb = sender as TextBlock;
            this.LayoutRoot.Children.Remove(tb);
            GameMain.InitGame();
            GameMain.UpdateScoure = GameScore.UpdateScore;
            GameMain.GetScore = GameScore.GetScore;
            GameScore.hint = GameMain.Hint;
            GameScore.NextLevel = GameMain.NextLevel;
            GameScore.UpdateProgressBar = UpdateProgressBar;
        }
        public void UpdateProgressBar(double value)
        {
            if (value >= 0 && value <= 100)
            {
                AddAnimationToStoryboard(sbProgress, pbGame, "Value", value, TimeSpan.FromMilliseconds(500));
                sbProgress.Begin();
            }
        }

        /// <summary>
        /// 向Storyboard添加动画
        /// </summary>
        /// <param name="sb">目标Storyboard</param>
        /// <param name="dobj">动画目标</param>
        /// <param name="property">被改变的值</param>
        /// <param name="to">动画完毕后的最终值</param>
        /// <param name="Duration">动画持续时间</param>
        /// <param name="eh">Storyboard完成事件处理程序</param>
        public void AddAnimationToStoryboard(Storyboard sb, DependencyObject dobj, string property, double to, TimeSpan Duration)
        {
            DoubleAnimation da = new DoubleAnimation();
            Storyboard.SetTarget(da, dobj);
            Storyboard.SetTargetProperty(da, new PropertyPath(property));
            da.To = to;
            da.Duration = new Duration(Duration);
            sb.Stop();
            sb.Children.Add(da);
        }

        private void sbProgress_Completed(object sender, EventArgs e)
        {
            var sb = sender as Storyboard;
            double value = pbGame.Value;
            sb.Stop();
            sb.Children.Clear();
            pbGame.Value = value;
        }

        private void sbGameSart_Completed(object sender, EventArgs e)
        {
            //var sb = sender as Storyboard;
        }
    }
}
