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

namespace MapEditer
{
	/// <summary>
	/// Interaction logic for DialogEditer.xaml
	/// </summary>
	public partial class DialogEditer : Window
	{
        public Map Map { get; set; }

        private Dialog dialogs = new Dialog();

		public DialogEditer(Map map, int x, int y)
		{
			this.InitializeComponent();
            this.Map = map;
            dialogs.X = x;
            dialogs.Y = y;
			// Insert code required on object creation below this point.
		}

		private void btnAddDialog_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            listBoxDialogs.Items.Add(new ListBoxItem() { Content = tbDialog.Text });
            tbDialog.Text = "";
		}

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            for (int i = 0; i < this.listBoxDialogs.Items.Count; i++)
            {
                var dialog = (ListBoxItem)listBoxDialogs.Items[0];
                this.dialogs.Dialogs.Add(new KeyValuePair<int, string>(i, (string)dialog.Content));
            }
            Map.Events.Add(dialogs);
            this.Close(); //todo 添加对话完成...
		}

		private void btnQuit_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}
	}
}