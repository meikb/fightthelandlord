using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media;
using System.Runtime.Serialization.Formatters;
using System.Windows.Media.Imaging;

namespace MapEditor
{
    public class Sprite : Canvas
    {
        private Image image = new Image();

        /// <summary>
        /// 动画要用到的计时器
        /// </summary>
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        /// <summary>
        /// 当前播放的帧数,每秒20帧
        /// </summary>
        int count = 1;

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
        /// 图片路径
        /// </summary>
        public string ImageSource
        {
            set
            {
                ImageSourceConverter ISC = new ImageSourceConverter();
                if (ISC.CanConvertFrom(value.GetType()))
                {
                    this.image.Source = (ImageSource)ISC.ConvertFromString(value);
                }
            }
        }

        /// <summary>
        /// 构造一个动态的Sprite
        /// </summary>
        /// <param name="spriteName">Sprite名称</param>
        /// <param name="imageName">图片文件名,相对于项目文件夹的Animation文件夹,如Sprite_{1-8}.Png 这八帧图片就填"Sprite"</param>
        /// <param name="frameNum">动态Sprite有多少帧</param>
        /// <param name="speed">每秒播放多少帧</param>
        /// <param name="StartRoll">是否创建后是否自动开始动画</param>
        public Sprite(string spriteName, string imageName, int frameNum, int speed, bool StartRoll)
            : base()
        {
            this.Children.Add(image);
            this.SpriteName = spriteName;
            this.FrameNum = frameNum;
            this.ImageName = imageName;
            this.Speed = speed;
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(FrameNum / Speed * 1000);
            if (StartRoll)
                this.Roll();
        }


        /// <summary>
        /// 构造一个静态的Sprite
        /// </summary>
        /// <param name="spriteName">Sprite名称</param>
        /// <param name="imageName">图片名</param>
        public Sprite(string spriteName, string imageName)
            :base()
        {
            this.SpriteName = spriteName;
            this.ImageName = imageName;
            this.ImageSource = string.Format(StaticVar.Directory + "Animation\\{0}\\{0}-1.png", imageName);
        }
        /// <summary>
        /// 播放动画代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            ImageBrush IB = new ImageBrush();
            string Path = string.Format(StaticVar.Directory + "Animation\\{0}\\{0}-{1}.png", this.ImageName, count);
            this.ImageSource = Path;
            count = count == this.FrameNum ? 1 : count + 1;
        }

        /// <summary>
        /// 开始滚动动画
        /// </summary>
        public void Roll()
        {
            dispatcherTimer.Stop();
            dispatcherTimer.Interval = TimeSpan.FromMilliseconds(1000 / Speed);
            dispatcherTimer.Start();
        }

        /// <summary>
        /// 停止滚动动画
        /// </summary>
        public void RollStop()
        {
            dispatcherTimer.Stop();
            count = 1;
        }
    }
}
