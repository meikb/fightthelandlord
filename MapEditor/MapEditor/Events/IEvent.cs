using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public interface IEvent
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        int ID { get; set; }

        /// <summary>
        /// 事件名称
        /// </summary>
        string EventName { get; set; }

        /// <summary>
        /// 执行事件
        /// </summary>
        void ExecuteEvent();
    }
}
