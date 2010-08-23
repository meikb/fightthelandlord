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
using System.Windows.Threading;
using System.Collections.Generic;

namespace LeeGameEngine
{
    public class GameRoot : Canvas
    {
        private List<BaseObject> _objs;

        public GameRoot()
        {
            _objs = new List<BaseObject>();
            DispatcherTimer loopTimer = new DispatcherTimer();
            loopTimer.Interval = new TimeSpan(0, 0, 0, 0);
            loopTimer.Tick += new EventHandler(loopTimer_Tick);
            loopTimer.Start();
        }


        void loopTimer_Tick(object sender, EventArgs e)
        {
            foreach (var obj in _objs.ToArray())
            {
                obj.OnFrame();
                obj.OnDraw();
            }
        }

        /// <summary>
        /// 添加一个物体,该物体会在主循环中执行自己的逻辑
        /// </summary>
        /// <param name="obj"></param>
        public void AddObj(BaseObject obj)
        {
            _objs.Add(obj);
            this.Children.Add(obj);
        }

        /// <summary>
        /// 删除一个物体
        /// </summary>
        /// <param name="obj"></param>
        public void RemoveObj(BaseObject obj)
        {
            _objs.Remove(obj);
            this.Children.Remove(obj);
        }
    }
}
