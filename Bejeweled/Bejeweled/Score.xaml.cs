using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Bejeweled
{
	public partial class Score : UserControl
	{
        private ImageSourceConverter ISC = new ImageSourceConverter();
        /// <summary>
        /// 提示功能
        /// </summary>
        public Action hint { get; set; }

        /// <summary>
        /// 到下一关
        /// </summary>
        public Action NextLevel { get; set; }

        /// <summary>
        /// 更新进度条
        /// </summary>
        public Action<Double> UpdateProgressBar { get; set; }

        /// <summary>
        ///是否已开始游戏
        /// </summary>
        public bool IsStart { get; set; }

        private int levelNum = 1;

        private int _score = 0;

        private int allScore = 0;

        public int ScoreNow
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
            }
        }

        private int targetScore = 1000;

		public Score()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        public void UpdateScore(int pushscore)
        {
            this.ScoreNow += pushscore;
            this.allScore += pushscore;
            tbScore.Text = allScore.ToString();
            UpdateProgressBar((double)ScoreNow / (double)targetScore * 100);
            if (ScoreNow >= targetScore)
            {
                ScoreNow = 0;
                levelNum++;
                NextLevel();
                targetScore = (int)Math.Pow(levelNum, 1.1) * 1000;
                UpdateProgressBar(0.0);
            }
        }

        public int GetScore()
        {
            return this.ScoreNow;
        }

        private void SetSource(Image image, string path)
        {
            image.Source = (ImageSource)ISC.ConvertFromString(path);
        }

		private void imageHint_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
		{
            SetSource(imageHint, "Images/hint_btn_mouseenter.png");
		}

		private void imageHint_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            SetSource(imageHint, "Images/hint_btn.png");
		}

		private void imageHint_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetSource(imageHint, "Images/hint_btn_click.png");
            if (this.IsStart)
            {
                hint();
            }
		}

		private void imageHint_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetSource(imageHint, "Images/hint_btn_mouseenter.png");
		}
    }
}