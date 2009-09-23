using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace MapEditor
{

    /// <summary>
    /// 开关
    /// </summary>
    [Serializable]
    public class OnOff
    {
        /// <summary>
        /// 开关名
        /// </summary>
        public string Name;
        /// <summary>
        /// 开关值
        /// </summary>
        public bool Value;

        /// <summary>
        /// 构造一个新的开关
        /// </summary>
        /// <param name="name">开关名</param>
        /// <param name="onOff">开关值</param>
        public OnOff(string name, bool onOff)
        {
            this.Name = name;
            this.Value = onOff;
        }

        /// <summary>
        /// 构造一个新的开关
        /// </summary>
        public OnOff()
        {

        }
    }
}
