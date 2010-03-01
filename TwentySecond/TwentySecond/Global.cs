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

namespace TwentySecond
{
    public class Global
    {
        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="to">目标属性的目标值</param>
        /// <param name="duration">动画持续时间</param>
        /// <param name="obj">动画目标</param>
        /// <param name="targetProperty">动画目标属性</param>
        /// <param name="ev">动画播放完后触发的事件</param>
        public static void PlayAnimation(double to, Duration duration, DependencyObject obj, string targetProperty, EventHandler ev)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = duration;
            da.To = to;
            Storyboard.SetTarget(da, obj);
            Storyboard.SetTargetProperty(da, new PropertyPath(targetProperty));
            sb.Children.Add(da);
            sb.Completed += ev;
            sb.Begin();
        }

        /// <summary>
        /// 播放动画
        /// </summary>
        /// <param name="to">目标属性的目标值</param>
        /// <param name="duration">动画持续时间</param>
        /// <param name="obj">动画目标</param>
        /// <param name="targetProperty">动画目标属性</param>
        public static void PlayAnimation(double to, Duration duration, DependencyObject obj, string targetProperty)
        {
            Storyboard sb = new Storyboard();
            DoubleAnimation da = new DoubleAnimation();
            da.Duration = duration;
            da.To = to;
            Storyboard.SetTarget(da, obj);
            Storyboard.SetTargetProperty(da, new PropertyPath(targetProperty));
            sb.Children.Add(da);
            sb.Begin();
        }
    }
}
