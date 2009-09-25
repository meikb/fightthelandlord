using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace MapEditor
{
    [Serializable]
    public class OnOffEvent : IEvent
    {
        public int OnOffID { get; set; }

        public bool OnOffValue { get; set; }

        public override string ToString()
        {
            return "事件ID: " + this.ID.ToString() + "，更改开关 \"" + OnOffID + "\" 为" + (OnOffValue ? "开" : "关");
        }

        #region IEvent 成员

        public string EventName { get; set; }

        public void ExecuteEvent()
        {
            StaticVar.SetOnOffValueByOnOffID(OnOffID, OnOffValue);
        }
        public int ID { get; set; }

        #endregion
    }
}
