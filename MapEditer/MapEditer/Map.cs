using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Xml.Serialization;

namespace MapEditer
{
    [XmlType("Map")]
    public class Map
    {
        [XmlElement("Matrix")]
        public byte[,] Matrix { get; set; }
        [XmlElement("MapImage")]
        public Image MapImage { get; set; }
        [XmlElement("Width")]
        public double Width { get; set; }
        [XmlElement("Height")]
        public double Height { get; set; }

        public string Path { get; set; }

        public Map(Image mapImage, double width, double height, string path)
        {
            this.MapImage = mapImage;
            this.Width = width;
            this.Height = height;
            this.Path = path;
        }

        public Map()
        {
        }
    }
}
