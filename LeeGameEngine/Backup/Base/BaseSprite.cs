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
using System.Windows.Media.Imaging;
using System.Collections.Generic;

namespace LeeGameEngine
{
    public class BaseSprite : BaseObject
    {
        /// <summary>
        /// 用来呈现Sprite的图像UI
        /// </summary>
        private Image _image;

        /// <summary>
        /// 用来呈现Spirte的图像UI源
        /// </summary>
        private BitmapImage _imageSource;

        /// <summary>
        /// 当前播放动画的名称
        /// </summary>
        private string _currentAnimaName;

        /// <summary>
        /// 当前播放动画的帧集合
        /// </summary>
        private List<BitmapImage> _currentAnima;

        /// <summary>
        /// 当前播放帧
        /// </summary>
        private int _currentFrame;

        /// <summary>
        /// 获取或设置当前播放帧
        /// </summary>
        public int CurrentFrame
        {
            get
            {
                return _currentFrame;
            }
            set
            {
                _currentFrame = value;
            }
        }

        /// <summary>
        /// 精灵类所有动画集合
        /// </summary>
        private Dictionary<string, List<BitmapImage>> _animations;

        /// <summary>
        /// 上一帧播放时间
        /// </summary>
        private DateTime _lastFramePlayTime = DateTime.Now;

        /// <summary>
        /// 多少毫秒播一帧
        /// </summary>
        private int _playSpeedByPerMillisecond = 100;

        /// <summary>
        /// 缩放倍数
        /// </summary>
        private double _scaleRatio = 1;

        /// <summary>
        /// 获取或设置缩放倍数
        /// </summary>
        public double ScaleRatio
        {
            get
            {
                return _scaleRatio;
            }
            set
            {
                _scaleRatio = value;
                if (!(this.RenderTransform is TransformGroup))
                {
                    RenderTransform = new TransformGroup();
                }

                var transGroup = this.RenderTransform as TransformGroup;
                foreach (var item in transGroup.Children)
                {
                    if (item is ScaleTransform)
                    {
                        var scaleTrans = (item as ScaleTransform);
                        scaleTrans.ScaleX = value; scaleTrans.ScaleY = value;
                        return;
                    }
                }
                transGroup.Children.Add(new ScaleTransform() { ScaleX = value, ScaleY = value });
            }
        }

        /// <summary>
        /// 动画类型,可以选择播一次和循环播放
        /// </summary>
        public EmAnimaType AnimaType { get; set; }

        /// <summary>
        /// 每秒多少帧
        /// </summary>
        private int _playSpeed = 10;

        public Dictionary<string, List<BitmapImage>> Animations
        {
            get
            {
                return _animations;
            }
        }

        /// <summary>
        /// 每秒多少帧
        /// </summary>
        public int PlaySpeed
        {
            get
            {
                return _playSpeed;
            }
            set
            {
                _playSpeedByPerMillisecond = 1000 / value;
                _playSpeed = value;
            }
        }

        public EmAnimaState AnimaState { get; set; }

        /// <summary>
        /// 直接设置Sprite的呈现图像,设置这个会导致动画停止
        /// </summary>
        public BitmapImage ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
                _image.Source = value;
                AnimaState = EmAnimaState.Stoped;
            }
        }

        //public new double Width
        //{
        //    set
        //    {
        //        base.Width = value;
        //        _image.Width = value;
        //    }
        //    get
        //    {
        //        return base.Width;
        //    }
        //}

        //public new double Height
        //{
        //    set
        //    {
        //        base.Height = value;
        //        _image.Height = value;
        //    }
        //    get
        //    {
        //        return base.Height;
        //    }
        //}

        /// <summary>
        /// 设置当前当前播放动画
        /// </summary>
        public string CurrentAnimaName
        {
            get { return _currentAnimaName; }
            set
            {
                if (value == _currentAnimaName)
                    return;
                if (value == string.Empty || value == "")
                    return;
                if (!_animations.ContainsKey(value))
                    return;
                _currentAnimaName = value;
                _currentAnima = _animations[_currentAnimaName];
                if (_currentAnima.Count > 0)
                    _image.Source = _currentAnima[0];
            }
        }


        public BaseSprite()
        {
            _image = new Image();
            _animations = new Dictionary<string, List<BitmapImage>>();
            Children.Add(_image);
            Width = _image.ActualWidth;
            Height = _image.ActualHeight;
        }

        /// <summary>
        /// 停止
        /// </summary>
        public void Stop()
        {
            if (_currentAnima.Count > 0)
            {
                ImageSource = _currentAnima[0];
            }
        }

        /// <summary>
        /// 播放
        /// </summary>
        public void Play()
        {
            if (AnimaState == EmAnimaState.Stoped)
            {
                _currentFrame = 0;
            }
            AnimaState = EmAnimaState.Playing;
        }

        /// <summary>
        /// 从指定帧数开始播放
        /// </summary>
        /// <param name="frame">帧数</param>
        public void PlayByFrame(int frame)
        {
            AnimaState = EmAnimaState.Playing;
            _currentFrame = frame;
        }

        public void PlayByAnimaName(string animaName)
        {
            CurrentAnimaName = animaName;
            Play();
        }

        public override void OnDraw()
        {
            try
            {
                if (AnimaState == EmAnimaState.Stoped)
                    return;
                if ((DateTime.Now - _lastFramePlayTime).Milliseconds > _playSpeedByPerMillisecond) // 距离上一帧播放时间超过多少毫秒播一帧的时间
                {
                    if (_currentAnima == null)
                        return;
                    if (_currentFrame < _currentAnima.Count)
                    {
                        _image.Source = _currentAnima[_currentFrame];
                        //this.Width = _image.ActualWidth * _scaleRatio;
                        //this.Height = _image.ActualHeight * _scaleRatio;
                        _lastFramePlayTime = DateTime.Now;
                        _currentFrame++;
                    }
                    else
                    {
                        if (AnimaType == EmAnimaType.Loop) // 如果为循环播放模式的话
                        {
                            _currentFrame = 0;
                        }
                        else
                        {
                            Stop();
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {

            }
        }

        public override Rect GetRect()
        {
            return new Rect(base.X, base.Y, Width, Height);
        }
    }

    public enum EmAnimaState
    {
        Playing,
        Stoped,
    }

    public enum EmAnimaType
    {
        Onec,
        Loop,
    }
}
