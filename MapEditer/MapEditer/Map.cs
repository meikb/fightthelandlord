using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Runtime.Serialization;

namespace MapEditer
{
    [Serializable]
    public class Map
    {
        /// <summary>
        /// 矩阵
        /// </summary>
        public byte[,] Matrix { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [NonSerialized]
        public Image MapImage;

        /// <summary>
        /// 所在目录
        /// </summary>
        [NonSerialized]
        public string Directory;

        /// <summary>
        /// 地图宽
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 地图高
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 图片文件名
        /// </summary>
        public string ImageFileName { get; set; }

        /// <summary>
        /// 事件集
        /// </summary>
        public List<Event> Events = new List<Event>();

        public Map(Image mapImage, double width, double height, string imageFileName)
        {
            this.MapImage = mapImage;
            this.Width = width;
            this.Height = height;
            this.ImageFileName = imageFileName;
        }

        public Map()
        {
        }
    }
}
