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

        public Action<string, bool> SetOnOffByName { get; set; }

        public string OnOffName { get; set; }

        public bool OnOffValue { get; set; }

        #region IEvent 成员

        public bool needOnOff { get; set; }

        public OnOff onOff { get; set; }

        public void ExecuteEvent()
        {
            SetOnOffByName(OnOffName, OnOffValue);
        }

        #endregion
    }
}
