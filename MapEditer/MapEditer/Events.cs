﻿using System;
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
        /// 事件集
        /// </summary>
        public List<IEvent> events = new List<IEvent>();

        /// <summary>
        /// 执行事件集
        /// </summary>
        public void Execute()
        {
            foreach (var singleEvent in events)
            {
                singleEvent.ExecuteEvent();
            }
        }
    }
}
