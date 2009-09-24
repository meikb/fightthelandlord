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
        /// 对话集
        /// </summary>
        public List<string> Dialogs = new List<string>();

        /// <summary>
        /// 显示对话方法
        /// </summary>
        public Action<string> ShowDialog { get; set; }

        /// <summary>
        /// 添加一段对话
        /// </summary>
        /// <param name="dialog"></param>
        public void AddDialog(string dialog)
        {
            this.Dialogs.Add(dialog);
        }
            

        /// <summary>
        /// 显示所有对话
        /// </summary>
        private void ShowDialogs()
        {
            foreach (var dialog in Dialogs)
            {
                ShowDialog(dialog);
            }
        }

        public override string ToString()
        {
            if (Dialogs.Count > 0)
            {
                return "显示文章: " + Dialogs[0].Substring(0, 10);
            }
            else
            {
                return "空文章";
            }
        }
        #region IEvent 成员

        public bool needOnOff { get; set; }

        public OnOff onOff { get; set; }

        public string EventName { get; set; }

        public void ExecuteEvent()
        {
            if (needOnOff)
            {
                if (onOff.Value)
                    ShowDialogs();
            }
            else
            {
                ShowDialogs();
            }
        }
        #endregion
    }
}
