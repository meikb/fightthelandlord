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
	/// Interaction logic for NewChangeMapEvent.xaml
	/// </summary>
	public partial class NewChangeMapEvent : Window
	{
        private Action<IEvent> AddEvent;

		public NewChangeMapEvent(Action<IEvent> addEvent)
		{
			this.InitializeComponent();

            this.AddEvent = addEvent;
			// Insert code required on object creation below this point.
		}

		private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            if (tbTargetMapName.Text != "" && tbX.Text != "" && tbY.Text != "")
            {
                var targetMap = StaticVar.GetMapByMapName(tbTargetMapName.Text);
                if (targetMap != null)
                {
                    AddEvent(new MapChangeEvent() { Location = new Point(double.Parse(tbX.Text), double.Parse(tbY.Text)), TargetMap = targetMap });
                    this.Close();
                }
                else
                {
                    MessageBox.Show("有这个地图么...", "出错啦~");
                }
            }
		}

		private void btnCalcel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}
	}
}