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

        public Map SelectedMap { get; set; }

        public NewEvents(Project sProject, Map selectedMap, int x, int y)
		{
			this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(NewEvents_Loaded);
            this.X = x;
            this.Y = y;
            this.SelectedProject = sProject;
            this.SelectedMap = selectedMap;
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
            this.cbSelectSprite.Items.Add(new ComboBoxItem() { Content = "不使用精灵图片" });
            foreach (var sprite in this.SelectedProject.Sprites)
            {
                this.cbSelectSprite.Items.Add(new ComboBoxItem() { Content = sprite.SpriteName });
            }
        }

        private void InitOnOffCombox()
        {
            this.cbOnOff.Items.Clear();
            this.cbOnOff.Items.Add(new ComboBoxItem() { Content = "无条件执行" });
            foreach (var onOff in this.SelectedProject.globalOnOff)
            {
                this.cbOnOff.Items.Add(new ComboBoxItem() { Content = onOff.ToString(), Tag = onOff.ID });
            }
        }

        private void InitEventsListBox()
        {
            this.listBoxEvents.Items.Clear();
            if (this.SelectedEvents == null)
                this.SelectedEvents = StaticVar.GetEventsByXY(this.X, this.Y);
            if (this.SelectedEvents == null)
                this.SelectedEvents = new Events() { X = this.X, Y = this.Y };

            foreach (var singleEvent in this.SelectedEvents.events)
            {
                this.listBoxEvents.Items.Add(new ListBoxItem() { Content = singleEvent.ToString(), Tag = singleEvent.ID });
            }
        }

        private void cbOnOff_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
            if (selectedItem != null)
            {
                var id = (int)selectedItem.Tag;
                var selectedOnOff = StaticVar.GetOnOffByOnOffID(id);
                if (selectedOnOff != null)
                    this.SelectedEvents.onOffs.Add(selectedOnOff);
            }
        }

        private void cbSelectSprite_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            canvasSpriteView.Children.Clear();
            var selectedItem = (ComboBoxItem)e.AddedItems[0];
            var selectedSprite = SelectedProject.GetSpriteBySpriteName((string)selectedItem.Content);
            this.SelectedEvents.Sprite = selectedSprite;
            if ((string)selectedItem.Content == "不使用精灵图片")
                this.SelectedEvents.Sprite = null;

            if (this.SelectedEvents.Sprite != null)
            {
                canvasSpriteView.Children.Add(this.SelectedEvents.Sprite);
                this.SelectedEvents.Sprite.Roll();
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            this.canvasSpriteView.Children.Clear();
        }

        private void tbAddDialogEvent_Click(object sender, RoutedEventArgs e)
        {
            new NewDialogEvent(this.SelectedEvents.AddEvent).ShowDialog();
            InitEventsListBox();
        }

        private void btnMapChange_Click(object sender, RoutedEventArgs e)
        {
            new NewChangeMapEvent(this.SelectedEvents.AddEvent).ShowDialog();
            InitEventsListBox();
        }

        private void btnEditOnOff_Click(object sender, RoutedEventArgs e)
        {
            new NewOnOffEvent(this.SelectedEvents.AddEvent).ShowDialog();
            InitEventsListBox();
        }

        private void btnDeleteEvent_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            foreach (var item in this.listBoxEvents.Items)
            {
                this.SelectedEvents.RemoveEventByID((int)((ListBoxItem)item).Tag);
            }
            InitEventsListBox();
        }

        private void listBoxEvents_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            if (this.SelectedEvents.events.Count > 0)
            {
                this.SelectedMap.Events.Add(this.SelectedEvents);
            }
        }
	}
}