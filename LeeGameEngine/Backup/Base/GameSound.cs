using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LeeGameEngine
{
    internal class GameSound
    {
        private MediaElement _baseMedia;


        /// <summary>
        /// 基础音频对象
        /// </summary>
        public MediaElement BaseMedia
        {
            get
            {
                return _baseMedia;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        internal GameSound()
        {
            _baseMedia = new MediaElement();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="uri">音频文件的相对路径</param>
        internal GameSound(string uri)
        {
            _baseMedia = new MediaElement();
            _baseMedia.AutoPlay = false;
            _baseMedia.Source = new Uri(uri, UriKind.Relative);
        }

        internal void Play()
        {
            _baseMedia.Stop();
            _baseMedia.Play();
        }
        internal void Stop()
        {
            _baseMedia.Stop();
        }
    }
}
