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
using System.Collections.Generic;

namespace LeeGameEngine
{
    public class SoundManager : BaseObject
    {
        /// <summary>
        /// 音频字典
        /// </summary>
        private Dictionary<string, GameSound> _sounds;

        /// <summary>
        /// 当前播放的音频
        /// </summary>
        private GameSound _currentPlayingSound;

        /// <summary>
        /// 当前播放的音频
        /// </summary>
        private string _currentPlayingSoundName;

        /// <summary>
        /// 是否只能同时播放一种声音
        /// </summary>
        public bool IsSingle { get; set; }

        /// <summary>
        /// 获取或设置当前播放音频,设置新的音频后会自动播放
        /// </summary>
        public string CurrentPlayingSoundName
        {
            get
            {
                return _currentPlayingSoundName;
            }
            set
            {
                if (_sounds.ContainsKey(value))
                {
                    _currentPlayingSoundName = value;
                    if (IsSingle && _currentPlayingSound != null)
                       _currentPlayingSound.Stop();
                    _currentPlayingSound = _sounds[value];
                    _currentPlayingSound.Play();
                }
            }
        }
        
        /// <summary>
        /// 构造函数
        /// </summary>
        public SoundManager()
        {
            _sounds = new Dictionary<string, GameSound>();
        }

        /// <summary>
        /// 添加一个新的音频
        /// </summary>
        /// <param name="soundName">音频名称</param>
        /// <param name="soundPath">音频路径</param>
        public void AddSound(string soundName, string soundPath)
        {
            var newSound = new GameSound(soundPath);
            Children.Add(newSound.BaseMedia);
            _sounds.Add(soundName, newSound);
        }
    }
}
