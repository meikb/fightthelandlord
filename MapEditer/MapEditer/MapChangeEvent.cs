using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Runtime.Serialization.Formatters;

namespace MapEditor
{
    [Serializable]
    public class MapChangeEvent : IEvent
    {
        /// <summary>
        /// 目标地图
        /// </summary>
        public Map TargetMap { get; set; }

        /// <summary>
        /// 出现位置
        /// </summary>
        public Point Location { get; set; }

        public Action<Map, Point> ChangeMap { get; set; }

        public override string ToString()
        {
            return "切换地图到 " + TargetMap.Name + "。 位置： " + Location.ToString();
        }

        #region IEvent 成员

        public bool needOnOff { get; set; }

        public OnOff onOff { get; set; }

        public string EventName { get; set; }

        public void ExecuteEvent()
        {
            ChangeMap(TargetMap, Location);
        }

        #endregion
    }
}
