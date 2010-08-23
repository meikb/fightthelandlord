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
using System.Collections.Generic;

namespace LeeGameEngine
{
    public class SceneManager : BaseObject
    {
        public int GameWidth;
        public int GameHeight;
        /// <summary>
        /// 获取或设置游戏盒子,当场景内的物体坐标离开这个盒子的范围时会删除该物体
        /// </summary>
        public Rect GameBox { get; set; }
        protected List<BaseObject> _baseObjects;

        public SceneManager()
        {
            GameWidth = 800;
            GameHeight = 600;
            GameBox = new Rect(0, 0, GameWidth, GameHeight);
            _baseObjects = new List<BaseObject>();
        }

        /// <summary>
        /// 添加一个物体到场景
        /// </summary>
        /// <param name="obj"></param>
        public virtual void AddObj(BaseObject obj)
        {
            _baseObjects.Add(obj);
            this.Children.Add(obj);
        }


        /// <summary>
        /// 从场景移除一个物体
        /// </summary>
        /// <param name="obj"></param>
        public virtual void RemoveObj(BaseObject obj)
        {
            _baseObjects.Remove(obj);
            this.Children.Remove(obj);
        }

        public override void OnFrame()
        {
            foreach (var item in _baseObjects.ToArray())
            {
                item.OnFrame();
                if (item.X < GameBox.X || item.X > GameBox.Width|| item.Y < GameBox.Y || item.Y > GameBox.Height)
                {
                    RemoveObj(item);
                }
            }
            base.OnFrame();
        }

        public override void OnDraw()
        {
            foreach (var obj in _baseObjects.ToArray())
            {
                obj.OnDraw();
            }
            base.OnDraw();
        }
    }
}