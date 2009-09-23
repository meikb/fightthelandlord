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
	/// Interaction logic for DialogEditor.xaml
	/// </summary>
	public partial class DialogEditor : Window
	{
        public Events Events { get; set; }

        private DialogEvent dialogs = new DialogEvent();

		public DialogEditor(Events events, int x, int y)
		{
			this.InitializeComponent();
            this.Events = events;
			// Insert code required on object creation below this point.
		}

		private void btnAddDialog_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            listBoxDialogs.Items.Add(new ListBoxItem() { Content = tbDialog.Text });
            tbDialog.Text = "";
		}

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            foreach (var item in this.listBoxDialogs.Items)
            {
                var dialog = (ListBoxItem)item;
                this.dialogs.AddDialog((string)dialog.Content);
            }
            Events.events.Add(dialogs);
            this.Close();
		}

		private void btnQuit_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}
	}
}