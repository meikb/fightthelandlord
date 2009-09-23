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
	public partial class NewEvents : Window
	{
        public Project SelectedProject { get; set; }

		public NewEvents(Project sProject)
		{
			this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(NewEvents_Loaded);
            this.SelectedProject = sProject;
			// Insert code required on object creation below this point.
		}

        void NewEvents_Loaded(object sender, RoutedEventArgs e)
        {
            InitSpriteCombox();
            InitOnOffCombox();
            InitEventsListBox();
        }

        private void InitSpriteCombox()
        {
            foreach (var sprite in this.SelectedProject.Sprites)
            {
                this.cbSelectSprite.Items.Add(new ComboBoxItem() { Content = sprite.SpriteName });
            }
        }

        private void InitOnOffCombox()
        {
            foreach (var onOff in this.SelectedProject.globalOnOff)
            {
                this.cbOnOff.Items.Add(new ComboBoxItem() { Content = onOff.OnOffName });
            }
        }

        private void InitEventsListBox()
        {
            //todo 初始化事件窗口
        }
	}
}