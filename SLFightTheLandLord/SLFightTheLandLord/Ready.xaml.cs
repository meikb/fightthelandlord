using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SLFightTheLandLord
{
	public partial class Ready : UserControl
	{
		public Ready()
		{
			// 为初始化变量所必需
			InitializeComponent();
		}

        public void StartAnimation()
        {
            this.Storyboard1.Begin();
        }
	}
}