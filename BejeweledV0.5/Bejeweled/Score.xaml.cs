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

		public Score()
		{
			// Required to initialize variables
			InitializeComponent();
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
		}

		private void imageHint_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SetSource(imageHint, "Images/hint_btn_mouseenter.png");
		}
	}
}