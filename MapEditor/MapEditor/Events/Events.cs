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
        [NonSerialized]
        public Sprite _sprite;

        /// <summary>
        /// 获取或设置事件显示精灵
        /// </summary>
        public Sprite Sprite
        {
            get
            {
                StaticVar.ConvertSpriteInfoTOSprite(this.spriteInfo, this._sprite);
                return this._sprite;
            }
            set
            {
                this._sprite = value;
                StaticVar.ConvertSpriteToSpriteInfo(this._sprite, this.spriteInfo);
            }
        }

        private SpriteInfo spriteInfo;

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

        public void AddEvent(IEvent singleEvent)
        {
            singleEvent.ID = this.events.Count + 1;
            this.events.Add(singleEvent);
        }

        public void RemoveEventByID(int id)
        {
            IEvent tempEvent = null;
            foreach (var singleEvent in events)
            {
                if (singleEvent.ID == id)
                {
                    tempEvent = singleEvent;
                    break;
                }
            }
            if (tempEvent != null)
                this.events.Remove(tempEvent);
        }

    }
}
