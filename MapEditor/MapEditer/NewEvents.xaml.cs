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
	/// Interaction logic for NewEvents.xaml
	/// </summary>
	public partial class NewEvents : Window  //再写事件编辑器
	{
        public Project SelectedProject { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public Events SelectedEvents { get; set; }

        public NewEvents(Project sProject, int x, int y)
		{
			this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(NewEvents_Loaded);
            this.X = x;
            this.Y = y;
            this.SelectedProject = sProject;
        }

        void NewEvents_Loaded(object sender, RoutedEventArgs e)
        {
            InitSpriteCombox();
            InitOnOffCombox();
            InitEventsListBox();
        }

        private void InitSpriteCombox()
        {
            this.cbSelectSprite.Items.Clear();
            foreach (var sprite in this.SelectedProject.Sprites)
            {
                this.cbSelectSprite.Items.Add(new ComboBoxItem() { Content = sprite.SpriteName });
            }
            this.cbSelectSprite.Items.Add(new ComboBoxItem() { Content = "不使用精灵图片" });
        }

        private void InitOnOffCombox()
        {
            this.cbOnOff.Items.Clear();
            foreach (var onOff in this.SelectedProject.globalOnOff)
            {
                this.cbOnOff.Items.Add(new ComboBoxItem() { Content = onOff.OnOffName });
            }
        }

        private void InitEventsListBox()
        {
            this.listBoxEvents.Items.Clear();
            this.SelectedEvents = StaticVar.GetEventsByXY(this.X, this.Y);
            if (this.SelectedEvents == null)
                this.SelectedEvents = new Events() { X = this.X, Y = this.Y };

            foreach (var singleEvent in this.SelectedEvents.events)
            {
                this.listBoxEvents.Items.Add(new ListBoxItem() { Content = singleEvent.ToString() });
            }
        }

        private void cbOnOff_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)e.AddedItems[0];
            var selectedOnOff = SelectedProject.GetGlobalOnOffByName((string)selectedItem.Content);
            if (selectedOnOff != null)
                this.SelectedEvents.onOffs.Add(selectedOnOff);
        }

        private void cbSelectSprite_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            canvasSpriteView.Children.Clear();
            var selectedItem = (ComboBoxItem)e.AddedItems[0];
            var selectedSprite = SelectedProject.GetSpriteBySpriteName((string)selectedItem.Content);
            this.SelectedEvents.sprite = selectedSprite;
            if ((string)selectedItem.Content == "不使用精灵图片")
                this.SelectedEvents.sprite = null;

            if (this.SelectedEvents.sprite != null)
            {
                canvasSpriteView.Children.Add(this.SelectedEvents.sprite);
                this.SelectedEvents.sprite.Roll();
            }
        }
	}
}