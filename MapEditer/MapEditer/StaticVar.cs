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
    }
}
