using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters;

namespace MapEditor
{
    [Serializable]
    public class SpriteInfo
    {
        /// <summary>
        /// 帧数
        /// </summary>
        public int FrameNum { get; set; }

        /// <summary>
        /// 每秒多少帧
        /// </summary>
        public int Speed { get; set; }

        /// <summary>
        /// 图片前缀
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Sprite名字
        /// </summary>
        public string SpriteName { get; set; }

        /// <summary>
        /// 构造一个动态的Sprite
        /// </summary>
        /// <param name="spriteName">Sprite名称</param>
        /// <param name="imageName">图片文件名,相对于项目文件夹的Animation文件夹,如Sprite_{1-8}.Png 这八帧图片就填"Sprite"</param>
        /// <param name="frameNum">动态Sprite有多少帧</param>
        /// <param name="speed">每秒播放多少帧</param>
        public SpriteInfo(string spriteName, string imageName, int frameNum, int speed)
        {
            this.SpriteName = spriteName;
            this.FrameNum = frameNum;
            this.ImageName = imageName;
            this.Speed = speed;
        }

        /// <summary>
        /// 构造一个静态的Sprite
        /// </summary>
        /// <param name="spriteName">Sprite名称</param>
        /// <param name="imageName">图片名</param>
        public SpriteInfo(string spriteName, string imageName)
        {
            this.SpriteName = spriteName;
            this.ImageName = imageName;
        }
    }
}
