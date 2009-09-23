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
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MapEditor
{
	/// <summary>
	/// Interaction logic for NewMap.xaml
	/// </summary>
	public partial class NewMap : Window
	{

        public string imagePath = string.Empty;

        public string imageName = string.Empty;

        public string MapName = string.Empty;

        public bool DialogResult = false;

		public NewMap()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void btnOk_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (imagePath != string.Empty && tbMapName.Text != "")
            {
                this.MapName = this.tbMapName.Text;
                DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("地图名或图片路径不能为空");
            }
		}

		private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}

		private void btnBrowser_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var openFile = new OpenFileDialog();
            openFile.Title = "打开PNG文件";
            openFile.Filter = "PNG文件(*.PNG)|*.PNG";
            if ((bool)openFile.ShowDialog())
            {
                this.imagePath = openFile.FileName;
                this.imageName = openFile.SafeFileName;
                this.tbImagePath.Text = openFile.FileName;
            }
		}
	}
}