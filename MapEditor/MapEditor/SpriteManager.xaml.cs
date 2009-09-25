using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MapEditor
{
	/// <summary>
	/// Interaction logic for SpriteManager.xaml
	/// </summary>
	public partial class SpriteManager : Window
	{

        public List<Sprite> Sprites { get; set; }

        private Sprite _selectedSprite;

        private Sprite SelectedSprite
        {
            get
            {
                return this._selectedSprite;
            }
            set
            {
                if (value != null)
                {
                    this.tbFrameNum.Text = value.FrameNum.ToString();
                    this.tbFrameSpeed.Text = value.Speed.ToString();
                    this.tbImageName.Text = value.ImageName;
                    this.tbSpriteName.Text = value.SpriteName;
                }
                this._selectedSprite = value;
            }
        }

		public SpriteManager(List<Sprite> sprites)
		{
			this.InitializeComponent();

            this.Sprites = sprites;
            RefreshListBox();

			// Insert code required on object creation below this point.
		}

		private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            string spriteName = tbSpriteName.Text;
            string imageName = tbImageName.Text;
            bool isAnimation = (bool)cbIsAnimation.IsChecked;
            string frameNum = tbFrameNum.Text;
            string frameSpeed = tbFrameSpeed.Text;
            if ((spriteName != "" && imageName != "" && isAnimation && frameNum != "" && frameSpeed != "") || (spriteName != "" && imageName != "" && !isAnimation))
            {
                if (this.SelectedSprite != null)
                {
                    this.SelectedSprite.SpriteName = spriteName;
                    this.SelectedSprite.ImageName = imageName;
                    if (isAnimation)
                    {
                        this.SelectedSprite.FrameNum = int.Parse(frameNum);
                        this.SelectedSprite.Speed = int.Parse(frameSpeed);
                    }
                }
                else
                {
                    this.SelectedSprite = new Sprite(spriteName, imageName, int.Parse(frameNum), int.Parse(frameSpeed), false);
                    this.Sprites.Add(this.SelectedSprite);
                    RefreshListBox();
                }
            }
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}

		private void btnView_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            View();
		}

		private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.SelectedSprite = null;
		}

		private void listBoxSprites_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
            string spriteName = (string)((ListBoxItem)e.AddedItems[0]).Content;
            var selectedSprite = GetSpriteBySpriteName(spriteName);
            if (selectedSprite != null)
                this.SelectedSprite = selectedSprite;
            View();
		}

		private void cbIsAnimation_Checked(object sender, System.Windows.RoutedEventArgs e)
		{
            if (this.tbFrameNum != null)
            {
                this.tbFrameNum.IsEnabled = true;
                this.tbFrameSpeed.IsEnabled = true;
            }
		}

		private void cbIsAnimation_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.tbFrameNum.IsEnabled = false;
            this.tbFrameSpeed.IsEnabled = false;
		}

        private void RefreshListBox()
        {
            foreach (var sprite in this.Sprites)
            {
                listBoxSprites.Items.Add(new ListBoxItem() { Content = sprite.SpriteName });
            }
        }

        private Sprite GetSpriteBySpriteName(string spriteName)
        {
            Sprite sprite = null;
            foreach (var tempSprite in this.Sprites)
            {
                if (tempSprite.SpriteName == spriteName)
                    sprite = tempSprite;
            }
            return sprite;
        }

        private void View()
        {
            this.canvasView.Children.Clear();
            if (this.SelectedSprite != null)
            {
                this.canvasView.Children.Add(this.SelectedSprite);
                this.SelectedSprite.Roll();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.canvasView.Children.Clear();
        }
	}
}