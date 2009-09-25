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
	/// Interaction logic for NewOnOffEvent.xaml
	/// </summary>
	public partial class NewOnOffEvent : Window
	{
        private Action<IEvent> AddEvent { get; set; }

		public NewOnOffEvent(Action<IEvent> addEvent)
		{
			this.InitializeComponent();
            this.Loaded += new RoutedEventHandler(NewOnOffEvent_Loaded);
            this.AddEvent = addEvent;
			// Insert code required on object creation below this point.
		}

        void NewOnOffEvent_Loaded(object sender, RoutedEventArgs e)
        {
            InitOnOffComboBox();
        }

        private void InitOnOffComboBox()
        {
            cbOnOff.Items.Clear();
            foreach (var onOff in StaticVar.SelectedProject.globalOnOff)
            {
                cbOnOff.Items.Add(new ComboBoxItem() { Content = onOff.ToString(), Tag = onOff.ID });
            }
        }

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (cbOnOff.SelectedItem != null)
            {
                var onOffID = (int)((ComboBoxItem)cbOnOff.SelectedItem).Tag;
                var selectedOnOff = StaticVar.GetOnOffByOnOffID(onOffID);
                if (selectedOnOff != null)
                {
                    AddEvent(new OnOffEvent() { OnOffID = onOffID, OnOffValue = true });
                    this.Close();
                }
                else
                {
                    MessageBox.Show("没有这个开关O__O", "出错了...");
                }
            }
            else
            {
                MessageBox.Show("你都没有选择开关哦o(╯□╰)o", "出错了...");
            }
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}
	}
}