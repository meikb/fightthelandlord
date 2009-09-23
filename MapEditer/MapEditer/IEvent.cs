using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public interface IEvent
    {
        /// <summary>
        /// 是否需要开关
        /// </summary>
        bool needOnOff { get; set; }
        /// <summary>
        /// 开关
        /// </summary>
        OnOff onOff { get; set; }

        /// <summary>
        /// 执行事件
        /// </summary>
        void ExecuteEvent();
    }
}
