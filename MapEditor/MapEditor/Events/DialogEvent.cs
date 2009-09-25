using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace MapEditor
{
    [Serializable]
    public class DialogEvent : IEvent
    {
        /// <summary>
        /// 对话
        /// </summary>
        public string Dialog { get; set; }

        /// <summary>
        /// 显示对话方法
        /// </summary>
        public Action<string> ShowDialog { get; set; }
            

        /// <summary>
        /// 显示所有对话
        /// </summary>
        private void ShowDialogs()
        {
            ShowDialog(Dialog);
        }

        public override string ToString()
        {
            if (Dialog.Length > 0)
            {
                return "事件ID: " + this.ID.ToString() + "，显示文章: " + Dialog.Substring(0, Dialog.Length > 10 ? 10 : Dialog.Length);
            }
            else
            {
                return "空文章";
            }
        }
        #region IEvent 成员

        public string EventName { get; set; }

        public void ExecuteEvent()
        {
            ShowDialogs();
        }

        public int ID { get; set; }

        #endregion
    }
}
