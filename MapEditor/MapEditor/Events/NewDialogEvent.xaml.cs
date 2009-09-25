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
	/// Interaction logic for NewDialogEvent.xaml
	/// </summary>
	public partial class NewDialogEvent : Window
	{

        public Action<IEvent> AddDialog { get; set; }

        public NewDialogEvent(Action<IEvent> addDialog)
		{
			this.InitializeComponent();
            this.AddDialog = addDialog;
			// Insert code required on object creation below this point.
		}

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (this.tbDialog.Text != "")
            {
                var dialog = new DialogEvent() { EventName = "对话", Dialog = this.tbDialog.Text };
                AddDialog(dialog);
                this.Close();
            }
            else
            {
                MessageBox.Show("对话不能为空啊!", "...");
            }

		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}
	}
}