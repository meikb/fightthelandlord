using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Runtime.Serialization;

namespace MapEditor
{
    [Serializable]
    public class Map
    {
        /// <summary>
        /// 地图名称
        /// </summary>
        private string _name;

        /// <summary>
        /// 设置或获取地图名称
        /// </summary>
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }

        /// <summary>
        /// 二维矩阵
        /// </summary>
        private byte[,] _matrix;

        /// <summary>
        /// 获取或设置二维矩阵
        /// </summary>
        public byte[,] Matrix 
        {
            get
            {
                return this._matrix;
            }
            set
            {
                this._matrix = value;
            }
        }

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
        private List<Events> _events = new List<Events>();

        public List<Events> Events
        {
            get
            {
                return this._events;
            }
            set
            {
                this._events = value;
            }
        }

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
