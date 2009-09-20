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
        public byte[,] Matrix { get; set; }

        [NonSerialized]
        public Image MapImage;

        public double Width { get; set; }

        public double Height { get; set; }

        public string ImageFileName { get; set; }

        [NonSerialized]
        public string Directory;

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
