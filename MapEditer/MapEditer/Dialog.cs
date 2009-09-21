using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace MapEditer
{
    [Serializable]
    public class Dialog : Event
    {
        /// <summary>
        /// 对话集
        /// </summary>
        public List<KeyValuePair<int, string>> Dialogs = new List<KeyValuePair<int, string>>();
    }
}
