using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace MapEditor
{
    [Serializable]
    public class Events
    {
        /// <summary>
        /// 事件触发坐标X
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// 事件触发坐标Y
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// 需要开启的开关集
        /// </summary>
        public List<OnOff> onOffs = new List<OnOff>();

        /// <summary>
        /// 事件集
        /// </summary>
        public List<IEvent> events = new List<IEvent>();

        /// <summary>
        /// 事件显示精灵
        /// </summary>
        public Sprite sprite { get; set; }

        /// <summary>
        /// 执行事件集
        /// </summary>
        public void Execute()
        {
            bool onOffsIsOn = false;
            foreach (var onOff in onOffs)
            {
                if (onOff.Value)
                    onOffsIsOn = true;
                else
                {
                    onOffsIsOn = false;
                    break;
                }
                
            }
            if (onOffsIsOn)
            {
                foreach (var singleEvent in events)
                {
                    singleEvent.ExecuteEvent();
                }
            }
        }
    }
}
