using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapEditor
{
    public static class StaticVar
    {
        /// <summary>
        /// 项目文件所在的文件夹
        /// </summary>
        public static string Directory { get; set; }

        /// <summary>
        /// 当前打开的项目
        /// </summary>
        public static Project SelectedProject { get; set; }

        /// <summary>
        /// 当前选中的被编辑的地图
        /// </summary>
        public static Map SelectedMap { get; set; }

        public static Events GetEventsByXY(int x, int y)
        {
            foreach (var singleEvents in StaticVar.SelectedMap.Events)
            {
                if (singleEvents.X == x && singleEvents.Y == y)
                {
                    return singleEvents;
                }
            }
            return null;
        }



        public static void ConvertSpriteInfoTOSprite(SpriteInfo from, Sprite to)
        {
            if(from != null && to != null)
                to = new Sprite(from.SpriteName, from.ImageName, from.FrameNum, from.Speed, false);
        }

        public static void ConvertSpriteToSpriteInfo(Sprite from, SpriteInfo to)
        {
            if (from != null && to != null)
                to = new SpriteInfo(from.SpriteName, from.ImageName, from.FrameNum, from.Speed);
        }

        public static Map GetMapByMapName(string mapName)
        {
            foreach (var singleMap in SelectedProject.AllMaps)
            {
                if (singleMap.Name == mapName)
                    return singleMap;
            }
            return null;
        }

        public static void SetOnOffValueByOnOffID(int id, bool value)
        {
            foreach (var onOff in SelectedProject.globalOnOff)
            {
                if (onOff.ID == id)
                    onOff.Value = value;
            }
        }

        public static OnOff GetOnOffByOnOffID(int id)
        {
            foreach (var onOff in SelectedProject.globalOnOff)
            {
                if (onOff.ID == id)
                    return onOff;
            }
            return null;
        }
    }
}
